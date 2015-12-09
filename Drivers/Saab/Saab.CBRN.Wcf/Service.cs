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
        #region Private properties

        private INETWISEDriverSink2 _sink;
        private DatabaseHandle _hDatabase;
        private WISEObjectFactory _factory;

        private enum LCDEvents {
            SILENT_CURRENT_ALARM       = 8
        ,   AUDIBLE_ALARM_TOGGLE       = 9
        ,   RESET_SIEVE_PACK_TIMER     = 10
        ,   NVG_TOGGLE                 = 11
        ,   RESTART                    = 12
        }

        #endregion

        #region Constructors

        public Service(INETWISEDriverSink2 sink, DatabaseHandle databaseHandle)
        {
            _sink = sink;
            _hDatabase = databaseHandle;
            _factory = new WISEObjectFactory(_sink, _hDatabase);
        }

        #endregion // Constructors

        #region Checker & events

        // This is used to verify that the user has given a correct url.
        public int MagicNumber()
        {
            return 123;
        }

        public void CreateEvent(Event ewent)
        {
            ObjectHandle hObject = ObjectHandle.Invalid;
            _sink.GetObjectHandle(_hDatabase, ewent.Id, ref hObject);
            if (hObject == ObjectHandle.Invalid) throw new WebFaultException(System.Net.HttpStatusCode.NotFound);

            switch (ewent.Sensor)
            {
                case "lcd":  LCDEvent(ewent, hObject);  break;
                case "raid": RAIDEvent(ewent, hObject); break;
                case "i28":  I28Event(ewent, hObject);  break;
                case "i27":  I27Event(ewent, hObject); break;
                default: throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
            }
        }

        public void LCDEvent(Event ewent, ObjectHandle hObject)
        {
            CBRNLCDControl wewent = new CBRNLCDControl();
            wewent.CreateInstance(_sink, _hDatabase);
            wewent.ExternalId = hObject;

            CBRNSensorLCDState wstate = (new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject)).SensorState;
            int audibleAlarm = wstate.AudibleAlarmValue;
            int nvg          = wstate.NVGValue;
            
            int bitmask = 
                wstate.AudibleAlarmValue * (1 << (int)LCDEvents.AUDIBLE_ALARM_TOGGLE)
            |   wstate.NVGValue          * (1 << (int)LCDEvents.NVG_TOGGLE);

            switch (ewent.Command)
            {
                case "silent current alarm":
                    bitmask |= (int)LCDEvents.SILENT_CURRENT_ALARM;
                    break;
                case "audible alarm toggle":
                    bitmask ^= (1 << (int)LCDEvents.AUDIBLE_ALARM_TOGGLE);
                    break;
                case "reset sieve pack timer":
                    bitmask |= (int)LCDEvents.RESET_SIEVE_PACK_TIMER;
                    break;
                case "nvg toggle":
                    bitmask ^= (1 << (int)LCDEvents.NVG_TOGGLE);
                    break;
                case "restart":
                    bitmask |= (int)LCDEvents.RESTART;
                    break;
                default:
                    throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
            }

            wewent.Command = bitmask;
            wewent.SendEventToDatabase(_hDatabase);
        }

        public void RAIDEvent(Event ewent, ObjectHandle hObject)
        {
            CBRNRAIDControl wewent = new CBRNRAIDControl();
            wewent.CreateInstance(_sink, _hDatabase);
            wewent.ExternalId = hObject;

            switch (ewent.Command)
            {
                case "toggle lib":
                    wewent.Command = "|q";
                    break;
                case "stop/start":
                    wewent.Command = "|o";
                    break;
                case "cleaning on":
                    wewent.Command = "1,M_HEAT,1";
                    break;
                case "cleaning off":
                    wewent.Command = "1,_RESET_";
                    break;
                default:
                    throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
            }

            wewent.SendEventToDatabase(_hDatabase);
        }

        public void I28Event(Event ewent, ObjectHandle hObject)
        {
            CBRNI28Control wewent = new CBRNI28Control();
            wewent.CreateInstance(_sink, _hDatabase);
            wewent.ExternalId = hObject;

            switch (ewent.Command)
            {
                case "reset accumulated dose rate":
                    wewent.Command = "CD";
                    break;
                case "reset peak dose rate":
                    wewent.Command = "E000E0000";
                    break;
                default:
                    throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
            }

            wewent.SendEventToDatabase(_hDatabase);
        }

        public void I27Event(Event ewent, ObjectHandle hObject)
        {
            CBRNI27Control wewent = new CBRNI27Control();
            wewent.CreateInstance(_sink, _hDatabase);
            wewent.ExternalId = hObject;

            switch (ewent.Command)
            {
                case "reset accumulated dose rate":
                    wewent.Command = "CD";
                    break;
                default:
                    throw new WebFaultException(System.Net.HttpStatusCode.NotImplemented);
            }

            wewent.SendEventToDatabase(_hDatabase);
        }

        #endregion

        #region LCD

        public void CreateLCD(Position p)
        {
            if (p == null) p = new Position();

            Create<EntityEquipmentSensorCBRNLCD>(p, delegate(EntityEquipmentSensorCBRNLCD wlcd, ObjectHandle hParent, string id)
            {
                wlcd.ExternalId = id;
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

        #region I28

        public void CreateI28(Position p)
        {
            if (p == null) p = new Position();

            Create<EntityEquipmentSensorCBRNI28>(p, delegate(EntityEquipmentSensorCBRNI28 wi28, ObjectHandle hParent, string id)
            {
                wi28.ExternalId = id;
                wi28.Parent = hParent;
                return wi28;
            });
        }

        public I28 GetI28ById(string id)
        {
            EntityEquipmentSensorCBRNI28 wi28 = (EntityEquipmentSensorCBRNI28)GetObjectFromId(SensorTypes.i28, id);
            return Converter.Convert(wi28);
        }

        public void UpdateI28(string id, I28 raid)
        {
            EntityEquipmentSensorCBRNI28 wi28 = (EntityEquipmentSensorCBRNI28)GetObjectFromId(SensorTypes.i28, id);
            Converter.Convert(raid, ref wi28);
        }

        public void DeleteI28(string id)
        {
            EntityEquipmentSensorCBRNI28 wi28 = (EntityEquipmentSensorCBRNI28)GetObjectFromId(SensorTypes.i28, id);
            Delete(wi28.Object, wi28.Parent);
        }

        #endregion

        #region I27

        public void CreateI27(Position p)
        {
            if (p == null) p = new Position();

            Create<EntityEquipmentSensorCBRNI28>(p, delegate(EntityEquipmentSensorCBRNI28 wi27, ObjectHandle hParent, string id)
            {
                wi27.ExternalId = id;
                wi27.Parent = hParent;
                return wi27;
            });
        }

        public I27 GetI27ById(string id)
        {
            EntityEquipmentSensorCBRNI27 wi27 = (EntityEquipmentSensorCBRNI27)GetObjectFromId(SensorTypes.i27, id);
            return Converter.Convert(wi27);
        }

        public void UpdateI27(string id, I27 raid)
        {
            EntityEquipmentSensorCBRNI27 wi27 = (EntityEquipmentSensorCBRNI27)GetObjectFromId(SensorTypes.i27, id);
            Converter.Convert(raid, ref wi27);
        }

        public void DeleteI27(string id)
        {
            EntityEquipmentSensorCBRNI27 wi27 = (EntityEquipmentSensorCBRNI27)GetObjectFromId(SensorTypes.i27, id);
            Delete(wi27.Object, wi27.Parent);
        }

        #endregion


        #region Generic methods

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
