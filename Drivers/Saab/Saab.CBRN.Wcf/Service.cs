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

        public int MagicNumber()
        {
            return 123;
        }

        #region LCD

        public void CreateLCD(LCD lcd)
        {
            Create<EntityEquipmentSensorCBRNLCD>(delegate(EntityEquipmentSensorCBRNLCD w, string objectName)
            {
                lcd.Id = objectName;
                Converter.Convert(lcd, ref w);
                return w;
            });
        }

        public LCD GetLCDById(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);
            return Converter.Convert(wlcd);
        }

        public void UpdateLCD(LCD lcd)
        {
            throw new NotImplementedException();
        }

        public void DeleteLCD(string id)
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

        #region AP2Ce

        public void CreateAP2Ce(AP2Ce ap2ce)
        {
            Create<EntityEquipmentSensorCBRNAP2Ce>(delegate (EntityEquipmentSensorCBRNAP2Ce w, string objectName)
            {
                ap2ce.Id = objectName;
                Converter.Convert(ap2ce, ref w);
                return w;
            });
        }

        public void DeleteAP2Ce(string id)  {}
        public void UpdateAP2Ce(AP2Ce ap2ce) {}

        public AP2Ce GetAP2CeById(string id)
        {
            ObjectHandle hObject = GetHandleFromId(id);
            EntityEquipmentSensorCBRNAP2Ce wap2ce = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);
            return Converter.Convert(wap2ce);
        }

        #endregion

        #region helpers
        
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
        
        private void Create<T>(Func<T, string, T> convert) where T : WISEObject, new() {

            WISE_RESULT result = WISEError.WISE_OK;
            try
            {
                string objectName = Guid.NewGuid().ToString();
                T wiseObj = new T();
                result = wiseObj.CreateInstance(_sink, _hDatabase, objectName);
                WISEError.CheckCallFailedEx(result);

                wiseObj = convert(wiseObj, objectName);

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

        #endregion
    }
}
