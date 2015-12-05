using Saab.CBRNSensors.Models;
using Saab.CBRN.Wcf.DataContracts;
using Saab.CBRN.Wcf.ServiceContracts;
using STS.WISE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WISE_RESULT = System.UInt32;
using System.Net;

// Implements all the sensors webb interface.
// Most of the code that interacts with WISE is placed in generic methods,
// declared at the end of this file.

namespace Saab.CBRN.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private INETWISEDriverSink2 _sink;
        private DatabaseHandle _hDatabase;
        private WISEObjectFactory _factory;

        #region Constructors

        public Service(INETWISEDriverSink2 sink, DatabaseHandle databaseHandle)
        {
            _sink = sink;
            _hDatabase = databaseHandle;
            _factory = new WISEObjectFactory(_sink, _hDatabase);
        }

        #endregion // Constructors

        #region checker & events

        // This is used to verify that the user has given a correct url.
        public int MagicNumber()
        {
            return 123;
        }

        // TODO: break out code to generic function, might have to modify code generator
        public void CreateEvent(Event ewent)
        {
            switch (ewent.Sensor)
            {
                case "lcd":
                    CBRNLCDControl wewent = new CBRNLCDControl();
                    wewent.CreateInstance(_sink, _hDatabase);

                    ObjectHandle hObject = ObjectHandle.Invalid;
                    _sink.GetObjectHandle(_hDatabase, ewent.Id, ref hObject);
                    if (hObject == ObjectHandle.Invalid)  throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
                    wewent.ExternalId = hObject;

                    // NOTE: Probably doesn't work. Perhaps the command-bit is a toggle?
                    switch (ewent.Command)
                    {
                        case "nvg toggle":
                            wewent.Command = 2048;
                            break;
                        case "audible alarm toggle":
                            wewent.Command = 512;
                            break;
                        //default:
                        // TODO: return a good status code, 405 maybe?
                    }

                    wewent.SendEventToDatabase(_hDatabase);
                    break;
                default:
                    throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }
        }

        #endregion

        #region LCD

        public void CreateLCD(Position p)
        {
            if (p == null) p = new Position();

            Create<EntityEquipmentSensorCBRNLCD>(p, delegate(EntityEquipmentSensorCBRNLCD wlcd, ObjectHandle hParent, string id)
            {
                wlcd.ExternalId = id;

                GroupList gp = new GroupList();

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", wlcd.StringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", wlcd.StringCache, new AttributeGroup());
                hData.SubstanceCategoryValue = "H";
                gp.Add(hData.Data);

                wlcd.SensorData = gp;
                wlcd.Parent = hParent;
                return wlcd;
            });
        }

        public LCD GetLCDById(string id)
        {
            EntityEquipmentSensorCBRNLCD wlcd = (EntityEquipmentSensorCBRNLCD)GetObjectFromId(SensorTypes.lcd, id);
            return Converter.Convert(wlcd);
        }

        public void UpdateLCD(string id, LCD lcd)
        {
            EntityEquipmentSensorCBRNLCD wlcd = (EntityEquipmentSensorCBRNLCD)GetObjectFromId(SensorTypes.lcd, id);
            Converter.Convert(lcd, ref wlcd);
        }

        public void DeleteLCD(string id)
        {
            EntityEquipmentSensorCBRNLCD wlcd = (EntityEquipmentSensorCBRNLCD)GetObjectFromId(SensorTypes.lcd, id);
            Delete(wlcd.Object, wlcd.Parent);
        }

        #endregion

        #region AP2Ce

        public void CreateAP2Ce(Position p)
        {
            if (p == null) p = new Position();
            Create<EntityEquipmentSensorCBRNAP2Ce>(p, delegate (EntityEquipmentSensorCBRNAP2Ce wap2ce, ObjectHandle hParent, string id)
            {
                wap2ce.ExternalId = id;

                GroupList gp = new GroupList();

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", wap2ce.StringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", wap2ce.StringCache, new AttributeGroup());
                hData.SubstanceCategoryValue = "H";
                gp.Add(hData.Data);

                wap2ce.SensorData = gp;
                wap2ce.Parent = hParent;
                return wap2ce;
            });
        }

        public AP2Ce GetAP2CeById(string id)
        {
            EntityEquipmentSensorCBRNAP2Ce wap2ce = (EntityEquipmentSensorCBRNAP2Ce)GetObjectFromId(SensorTypes.ap2ce, id);
            return Converter.Convert(wap2ce);
        }

        public void UpdateAP2Ce(string id, AP2Ce ap2ce)
        {
            EntityEquipmentSensorCBRNAP2Ce wap2ce = (EntityEquipmentSensorCBRNAP2Ce)GetObjectFromId(SensorTypes.ap2ce, id);
            Converter.Convert(ap2ce, ref wap2ce);
        }

        public void DeleteAP2Ce(string id)
        {
            EntityEquipmentSensorCBRNAP2Ce wap2ce = (EntityEquipmentSensorCBRNAP2Ce)GetObjectFromId(SensorTypes.ap2ce, id);
            Delete(wap2ce.Object, wap2ce.Parent);
        }

        #endregion

        #region RAID

        public void CreateRAID(Position p)
        {
            if (p == null) p = new Position();

            Create<EntityEquipmentSensorCBRNRAID>(p, delegate(EntityEquipmentSensorCBRNRAID wraid, ObjectHandle hParent, string id)
            {
                wraid.ExternalId = id;
                GroupList gp = new GroupList();
                wraid.SensorData = gp;
                wraid.Parent = hParent;
                return wraid;
            });
        }

        public RAID GetRAIDById(string id)
        {
            EntityEquipmentSensorCBRNRAID wraid = (EntityEquipmentSensorCBRNRAID)GetObjectFromId(SensorTypes.raid, id);
            return Converter.Convert(wraid);
        }

        public void UpdateRAID(string id, RAID raid)
        {
            EntityEquipmentSensorCBRNRAID wraid = (EntityEquipmentSensorCBRNRAID)GetObjectFromId(SensorTypes.raid, id);
            Converter.Convert(raid, ref wraid);
        }

        public void DeleteRAID(string id)
        {
            EntityEquipmentSensorCBRNRAID wraid = (EntityEquipmentSensorCBRNRAID)GetObjectFromId(SensorTypes.raid, id);
            Delete(wraid.Object, wraid.Parent);
        }

        #endregion
        
        #region generic methods

        private WISEObject GetObjectFromId(SensorTypes sensorType, string id)
        {
            ObjectHandle hObject = ObjectHandle.Invalid;

            // Find WISE object in db.
            _sink.GetObjectHandle(_hDatabase, id, ref hObject);

            // If it wasn't found then 404
            if (hObject == ObjectHandle.Invalid)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }

            return _factory.CreateObject(sensorType, hObject);
        }
        
        private void Create<T>(Position p, Func<T, ObjectHandle, string, T> initializeObject) where T : WISEObject, new() {

            WISE_RESULT result = WISEError.WISE_OK;
            try
            {
                string id = Guid.NewGuid().ToString();
                T wiseObj = new T();
                EntityGroundVehicle parent = new EntityGroundVehicle();

                result = wiseObj.CreateInstance(_sink, _hDatabase, id);
                WISEError.CheckCallFailedEx(result);
                result = parent.CreateInstance(_sink, _hDatabase, Guid.NewGuid().ToString());
                WISEError.CheckCallFailedEx(result);

                wiseObj = initializeObject(wiseObj, parent.Object, id);

                parent.Position = new Vec3(p.Longitude, p.Latitude, p.Altitude);
                
                result = parent.AddToDatabase(_hDatabase);
                WISEError.CheckCallFailedEx(result);
                result = wiseObj.AddToDatabase(_hDatabase);
                WISEError.CheckCallFailedEx(result);

                // Notify creator of object id.
                WebOperationContext.Current.OutgoingResponse.Headers.Add(HttpResponseHeader.Location, id);
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
            }
            catch (WISEException)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }

        public void Delete(ObjectHandle hObject, ObjectHandle hParent)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            try
            {
                result = _sink.RemoveObjectFromDatabase(_hDatabase, hParent);
                WISEError.CheckCallFailedEx(result);
                result = _sink.RemoveObjectFromDatabase(_hDatabase, hObject);
                WISEError.CheckCallFailedEx(result);
            }
            catch (WISEException)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }

        #endregion
    }
}
