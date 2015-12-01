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
                        case "nvg enable":
                            wewent.Command = 2048;
                            break;
                        case "audible alarm disable":
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

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", _sink as INETWISEStringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", _sink as INETWISEStringCache, new AttributeGroup());
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
            LCD lcd = Converter.Convert(wlcd);
            ObjectHandle hParentObject = wlcd.Parent;
            EntityGroundVehicle parent = new EntityGroundVehicle(_sink, _hDatabase, hParentObject);
            Position pos = new Position();
            // FIXME: what order?
            pos.Longitude = parent.Position.V1;
            pos.Latitude  = parent.Position.V2;
            pos.Altitude  = parent.Position.V3;
            lcd.Position = pos;
            return lcd;
        }

        
        // Only updating of position is handled
        public void UpdateLCD(string id, LCD lcd)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);
            Converter.Convert(lcd, ref wlcd);
            ObjectHandle hParentObject = wlcd.Parent;
            EntityGroundVehicle parent = new EntityGroundVehicle(_sink, _hDatabase, hParentObject);
            Vec3 pos = parent.Position;
            pos.V1 = lcd.Position.Longitude;
            pos.V2 = lcd.Position.Latitude;
            pos.V3 = lcd.Position.Altitude;
            parent.Position = pos;
        }

        public void DeleteLCD(string id)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);

            try
            {
                result = _sink.RemoveObjectFromDatabase(_hDatabase, wlcd.Parent);
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

        #region AP2Ce

        public void CreateAP2Ce(Position p)
        {
            if (p == null) p = new Position();
            Create<EntityEquipmentSensorCBRNAP2Ce>(delegate (EntityEquipmentSensorCBRNAP2Ce wap2ce, EntityGroundVehicle parent, string objectName)
            {
                wap2ce.ExternalId = objectName;

                GroupList gp = new GroupList();

                CBRNSensorLCDData gData = new CBRNSensorLCDData("SensorData", _sink as INETWISEStringCache, new AttributeGroup());
                gData.SubstanceCategoryValue = "G";
                gp.Add(gData.Data);

                CBRNSensorLCDData hData = new CBRNSensorLCDData("SensorData", _sink as INETWISEStringCache, new AttributeGroup());
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
            AP2Ce ap2ce = Converter.Convert(wap2ce);
            ObjectHandle hParentObject = wap2ce.Parent;
            EntityGroundVehicle parent = new EntityGroundVehicle(_sink, _hDatabase, hParentObject);
            Position pos = new Position();
            pos.Longitude = parent.Position.V1;
            pos.Latitude  = parent.Position.V2;
            pos.Altitude  = parent.Position.V3;
            
            ap2ce.Position = pos;
            return ap2ce;
        }

        public void UpdateAP2Ce(string id, AP2Ce ap2ce)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNAP2Ce wap2ce = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);
            Converter.Convert(ap2ce, ref wap2ce);
            ObjectHandle hParentObject = wap2ce.Parent;
            EntityGroundVehicle parent = new EntityGroundVehicle(_sink, _hDatabase, hParentObject);
            Vec3 pos = parent.Position;
            pos.V1 = ap2ce.Position.Longitude;
            pos.V2 = ap2ce.Position.Latitude;
            pos.V3 = ap2ce.Position.Altitude;
            parent.Position = pos;
        }

        public void DeleteAP2Ce(string id)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNAP2Ce wlcd = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);

            try
            {
                result = _sink.RemoveObjectFromDatabase(_hDatabase, wlcd.Parent);
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

        public void Delete(string id)
        {
            WISE_RESULT result = WISEError.WISE_OK;

            try
            {
                ObjectHandle hObject = WISEConstants.WISE_INVALID_HANDLE;

                // Convert from external id => internal handle
                result = _sink.GetObjectHandle(_hDatabase, id, ref hObject);
                WISEError.CheckCallFailedEx(result); // Converts WISE error code => exception

                // Remove from db
                result = _sink.RemoveObjectFromDatabase(_hDatabase, hObject);
                WISEError.CheckCallFailedEx(result);

                
            }
            catch (WISEException ex)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }
        }

        #endregion
    }
}
