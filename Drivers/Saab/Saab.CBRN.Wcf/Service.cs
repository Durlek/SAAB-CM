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

// TODO: Lots of duplicated code in this class
// TODO: if the codegenerator is updated so that all objects inherit from
// ..... an abstract class wich implements the 3 constructors,
// ..... this class becomes a lot easier to write.

namespace Saab.CBRN.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private INETWISEDriverSink2 _sink;
        private DatabaseHandle _hDatabase;

        #region Constructors

        public Service(INETWISEDriverSink2 sink, DatabaseHandle databaseHandle)
        {
            this._sink = sink;
            this._hDatabase = databaseHandle;
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

            Create<EntityEquipmentSensorCBRNLCD>(delegate(EntityEquipmentSensorCBRNLCD wlcd, EntityGroundVehicle parent, string objectName)
            {
                wlcd.ExternalId = objectName;

                GroupList gp = new GroupList();

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", wlcd.StringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", wlcd.StringCache, new AttributeGroup());
                hData.SubstanceCategoryValue = "H";
                gp.Add(hData.Data);

                wlcd.SensorData = gp;

                parent.Position = new Vec3(p.Longitude, p.Latitude, p.Altitude);
                WISE_RESULT result = parent.AddToDatabase(_hDatabase);
                WISEError.CheckCallFailedEx(result);
                wlcd.Parent = parent.Object;
                return wlcd;
            });
        }

        // TODO: break out code to generic function
        public LCD GetLCDById(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);
            return Converter.Convert(wlcd);
        }

        public void UpdateLCD(string id, LCD lcd)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);
            Converter.Convert(lcd, ref wlcd);
        }

        public void DeleteLCD(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            Delete(hObject, (new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject)).Parent);
        }

        #endregion

        #region AP2Ce

        public void CreateAP2Ce(Position p)
        {
            if (p == null) p = new Position();
            Create<EntityEquipmentSensorCBRNAP2Ce>(delegate (EntityEquipmentSensorCBRNAP2Ce wap2ce, EntityGroundVehicle parent, string objectName)
            {
                wap2ce.ExternalId = objectName;

                GroupList gp = new GroupList();

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", wap2ce.StringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", wap2ce.StringCache, new AttributeGroup());
                hData.SubstanceCategoryValue = "H";
                gp.Add(hData.Data);

                wap2ce.SensorData = gp;

                parent.Position = new Vec3(p.Longitude, p.Latitude, p.Altitude);
                WISE_RESULT result = parent.AddToDatabase(_hDatabase);
                WISEError.CheckCallFailedEx(result);
                wap2ce.Parent = parent.Object;
                return wap2ce;
            });
        }

        public AP2Ce GetAP2CeById(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNAP2Ce wap2ce = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);
            return Converter.Convert(wap2ce);
        }

        public void UpdateAP2Ce(string id, AP2Ce ap2ce)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNAP2Ce wap2ce = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);
            Converter.Convert(ap2ce, ref wap2ce);
        }

        public void DeleteAP2Ce(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            Delete(hObject, (new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject)).Parent);
        }

        #endregion

        #region generic methods
        
        private ObjectHandle GetHandleFromId(string id)
        {
            ObjectHandle hObject = ObjectHandle.Invalid;

            // Find WISE object in db.
            _sink.GetObjectHandle(_hDatabase, id, ref hObject);

            // If it wasn't found then 404
            if (hObject == ObjectHandle.Invalid)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }

            return hObject;
        }
        
        private void Create<T>(Func<T, EntityGroundVehicle, string, T> loadDataInto) where T : WISEObject, new() {

            WISE_RESULT result = WISEError.WISE_OK;
            try
            {
                string objectName = Guid.NewGuid().ToString();
                T wiseObj = new T();
                EntityGroundVehicle parent = new EntityGroundVehicle();

                result = wiseObj.CreateInstance(_sink, _hDatabase, objectName);
                WISEError.CheckCallFailedEx(result);
                result = parent.CreateInstance(_sink, _hDatabase, Guid.NewGuid().ToString());
                WISEError.CheckCallFailedEx(result);

                wiseObj = loadDataInto(wiseObj, parent, objectName);

                result = wiseObj.AddToDatabase(_hDatabase);
                WISEError.CheckCallFailedEx(result);

                // Notify creator of object id.
                WebOperationContext.Current.OutgoingResponse.Headers.Add(HttpResponseHeader.Location, objectName);
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;
            }
            catch (WISEException ex)
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
            catch (WISEException ex)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.ServiceUnavailable);
            }
        }

        #endregion
    }
}
