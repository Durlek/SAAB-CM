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
        EntityGroundVehicle,
        EntityEquipmentSensorCBRN,
        EntityEquipmentSensorCBRNAP2Ce,
        EntityEquipmentSensorCBRNI27,
        EntityEquipmentSensorCBRNI28,
        EntityEquipmentSensorCBRNLCD,
        EntityEquipmentSensorCBRNRAID,
        EntityEquipmentSensorCBRNRapid,
        CBRNI27Control,
        CBRNI28Control,
        CBRNLCDControl,
        CBRNRAIDControl,
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

            EntityGroundVehicle.UnInitialize();
            bResult = EntityGroundVehicle.Initialize( stringCache );
                
            EntityEquipmentSensorCBRN.UnInitialize();
            bResult = EntityEquipmentSensorCBRN.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNAP2Ce.UnInitialize();
            bResult = EntityEquipmentSensorCBRNAP2Ce.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNI27.UnInitialize();
            bResult = EntityEquipmentSensorCBRNI27.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNI28.UnInitialize();
            bResult = EntityEquipmentSensorCBRNI28.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNLCD.UnInitialize();
            bResult = EntityEquipmentSensorCBRNLCD.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNRAID.UnInitialize();
            bResult = EntityEquipmentSensorCBRNRAID.Initialize( stringCache );
                
            EntityEquipmentSensorCBRNRapid.UnInitialize();
            bResult = EntityEquipmentSensorCBRNRapid.Initialize( stringCache );
                
            CBRNI27Control.UnInitialize();
            bResult = CBRNI27Control.Initialize( stringCache );
                
            CBRNI28Control.UnInitialize();
            bResult = CBRNI28Control.Initialize( stringCache );
                
            CBRNLCDControl.UnInitialize();
            bResult = CBRNLCDControl.Initialize( stringCache );
                
            CBRNRAIDControl.UnInitialize();
            bResult = CBRNRAIDControl.Initialize( stringCache );
                

            return bResult;
        }

        public static CBRNSensorsEntityTypes GetEntityType(ClassHandle classHandle)
        {
            if (EntityGroundVehicle.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityGroundVehicle;
            }
            if (EntityEquipmentSensorCBRN.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRN;
            }
            if (EntityEquipmentSensorCBRNAP2Ce.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNAP2Ce;
            }
            if (EntityEquipmentSensorCBRNI27.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNI27;
            }
            if (EntityEquipmentSensorCBRNI28.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNI28;
            }
            if (EntityEquipmentSensorCBRNLCD.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNLCD;
            }
            if (EntityEquipmentSensorCBRNRAID.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNRAID;
            }
            if (EntityEquipmentSensorCBRNRapid.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNRapid;
            }
            if (CBRNI27Control.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.CBRNI27Control;
            }
            if (CBRNI28Control.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.CBRNI28Control;
            }
            if (CBRNLCDControl.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.CBRNLCDControl;
            }
            if (CBRNRAIDControl.IsTypeOf(classHandle))
            {
                return CBRNSensorsEntityTypes.CBRNRAIDControl;
            }
            return CBRNSensorsEntityTypes.Unknown;
        }

    }
}
