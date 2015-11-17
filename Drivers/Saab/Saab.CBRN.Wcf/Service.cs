using Saab.CBRN.Generated;
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

namespace Saab.CBRN.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private INETWISEDriverSink2 _sink;
        private DatabaseHandle _databaseHandle;

        #region Constructors

        public Service(INETWISEDriverSink2 sink, DatabaseHandle databaseHandle)
        {
            this._sink = sink;
            this._databaseHandle = databaseHandle;
        }

        #endregion // Constructors

        #region LCD

        public void CreateLCD(LCD lcd)
        {
            throw new NotImplementedException();                       
        }

        public IEnumerable<LCD> GetLCD()
        {
            return new List<LCD>();
        }

        public Position GetLCDById(string id)
        {
            ObjectHandle objectHandle = ObjectHandle.Invalid;

            _sink.GetObjectHandle(_databaseHandle, id, ref objectHandle);

            EntityEquipmentSensorCBRNLCD lcd = new EntityEquipmentSensorCBRNLCD(_sink, _databaseHandle, objectHandle);
            
            //if (objectHandle == ObjectHandle.Invalid)
           // {
            //    throw new WebFaultException(System.Net.HttpStatusCode.NotFound);
            //}
            Position pos = new Position();
            pos.Latitude = 1;
            pos.Longitude = 1;
            pos.Altitude = 1;
            return pos;
            //return Converter.Convert(lcd);
        }

        public void UpdateLCD(LCD lcd)
        {
            throw new NotImplementedException();
        }

        public void DeleteLCD(string id)
        {
            throw new NotImplementedException();
        }

        #endregion // LCD
    }
}
