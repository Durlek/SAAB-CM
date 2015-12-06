using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Saab.CBRNSensors.Models;
using STS.WISE;

namespace Saab.CBRN.Wcf
{
    // A basic factory for creating WISE objects,
    // existing only to make writing generic code a bit easier in Service.cs.

    public enum SensorTypes { lcd, ap2ce, raid, i28 };

    public class NotImplementedException : Exception { }

    class WISEObjectFactory
    {
        private INETWISEDriverSink2 _sink;
        private DatabaseHandle _hDatabase;

        public WISEObjectFactory(INETWISEDriverSink2 sink, DatabaseHandle hDatabase)
        {
            _sink = sink;
            _hDatabase = hDatabase;
        }

        public WISEObject CreateObject(SensorTypes sensorType, ObjectHandle hObject)
        {
            switch (sensorType)
            {
                case SensorTypes.lcd:   return new EntityEquipmentSensorCBRNLCD(_sink, _hDatabase, hObject);
                case SensorTypes.ap2ce: return new EntityEquipmentSensorCBRNAP2Ce(_sink, _hDatabase, hObject);
                case SensorTypes.raid:  return new EntityEquipmentSensorCBRNRAID(_sink, _hDatabase, hObject);
                case SensorTypes.i28:   return new EntityEquipmentSensorCBRNI28(_sink, _hDatabase, hObject);
            }
            throw new NotImplementedException();
        }
    }
}
