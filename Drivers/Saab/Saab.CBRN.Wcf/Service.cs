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
            EntityEquipmentSensorCBRNLCD wlcd = Converter.Convert(lcd);
            wlcd.CreateInstance(_sink, _hDatabase); // TODO: how do we choose the id? maybe leave it out and let the class handle it?
            wlcd.AddToDatabase(_hDatabase);
        }

        public LCD GetLCDById(string id)
        {
            ObjectHandle hObject = ObjectHandle.Invalid;

            // Find WISE object in db.
            _sink.GetObjectHandle(_hDatabase, id, ref hObject);
            EntityEquipmentSensorCBRNLCD wlcd = new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);

            // If it wasn't found then 404
            if (hObject == ObjectHandle.Invalid)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }

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
            EntityEquipmentSensorCBRNAP2Ce wap2ce = Converter.Convert(ap2ce);
            wap2ce.CreateInstance(_sink, _hDatabase); // TODO: how do we choose the id? maybe leave it out and let the class handle it?
            wap2ce.AddToDatabase(_hDatabase);
        }
        public void DeleteAP2Ce(string id)  {}
        public void UpdateAP2Ce(AP2Ce ap2ce) {}

        public AP2Ce GetAP2CeById(string id)
        {
            ObjectHandle hObject = ObjectHandle.Invalid;

            // Find WISE object in db.
            _sink.GetObjectHandle(_hDatabase, id, ref hObject);
            EntityEquipmentSensorCBRNAP2Ce wap2ce = new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);

            // If it wasn't found then 404
            if (hObject == ObjectHandle.Invalid)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            }

            return Converter.Convert(wap2ce);
        }

        #endregion
    }
}
