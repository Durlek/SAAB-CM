using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Xml;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public enum CBRNSensorsEntityTypes
    {
        Unknown,
        Entity,
        EntityGroundVehicle,
        EntityEquipment,
        EntityEquipmentSensor,
        EntityEquipmentSensorCBRN,
        EntityEquipmentSensorCBRNAP2Ce,
        EntityEquipmentSensorCBRNLCD,
        CBRNLCDControl,
    }

    /// <summary>
    /// Static class for initialization of object end event lookup dictionaries.
    /// </summary>
    public static class Model
    {   
        public static bool InitializeModel(INETWISEDriverSink2 wiseAccess)
        {
            bool bResult = false;
            INETWISEStringCache stringCache = wiseAccess as INETWISEStringCache;
            
            // The UnInitialize call is needed to clear string cache when WISE restarts

            Entity.UnInitialize();
            bResult = Entity.Initialize( stringCache );
                
            EntityGroundVehicle.UnInitialize();
            bResult = EntityGroundVehicle.Initialize( stringCache );
                
            EntityEquipment.UnInitialize();
            bResult = EntityEquipment.Initialize( stringCache );
                
            EntityEquipmentSensor.UnInitialize();
            bResult = EntityEquipmentSensor.Initialize( stringCache );
                
            EntityEquipmentSensorCBRN.UnInitialize();
            bResult = EntityEquipmentSensorCBRN.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNAP2Ce.UnInitialize();
            bResult = EntityEquipmentSensorCBRNAP2Ce.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNLCD.UnInitialize();
            bResult = EntityEquipmentSensorCBRNLCD.Initialize( stringCache );
                
            CBRNLCDControl.UnInitialize();
            bResult = CBRNLCDControl.Initialize( stringCache );
                

            return bResult;
        }

        public static CBRNSensorsEntityTypes GetEntityType(ClassHandle classHandle)
        {
            if (Entity.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.Entity;
            }
            if (EntityGroundVehicle.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityGroundVehicle;
            }
            if (EntityEquipment.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipment;
            }
            if (EntityEquipmentSensor.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensor;
            }
            if (EntityEquipmentSensorCBRN.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRN;
            }
            if (EntityEquipmentSensorCBRNAP2Ce.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNAP2Ce;
            }
            if (EntityEquipmentSensorCBRNLCD.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNLCD;
            }
            if (CBRNLCDControl.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.CBRNLCDControl;
            }
            return CBRNSensorsEntityTypes.Unknown;
        }

    }
}
