using Saab.CBRNSensors.Models;
using Saab.CBRN.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STS.WISE;

// TODO: lots of duplicated code
// TODO: better error handling (look in sdk for info)

namespace Saab.CBRN.Wcf
{
    public class Converter
    {
        #region LCD

        internal static LCD Convert(EntityEquipmentSensorCBRNLCD input)
        {
            LCD output = new LCD();

            output.Id = input.ExternalId;
            output.Name = input.Name;
            output.Description = input.Description;
            output.Data = ConvertLCDData(input.SensorData, input.StringCache);
            output.State = Convert(input.SensorState);
            output.DetectionMode = (LCDDetectionMode)Enum.Parse(typeof(LCDDetectionMode), input.DetectionMode.ToString());
            output.Position = getPosition(input.WISE, input.Database, input.Parent);
            return output;
        }

        internal static void Convert(LCD input, ref EntityEquipmentSensorCBRNLCD output)
        {
            output.ExternalId  = input.Id;
            output.Name        = input.Name;
            output.Description = input.Description;
            output.SensorData  = ConvertLCDData(input.Data, output.StringCache);
            output.SensorState = Convert(input.State, output.SensorState);
            output.DetectionMode = (byte)((LCDDetectionMode)Enum.Parse(typeof(LCDDetectionMode), input.DetectionMode.ToString()));
            setPosition(output.WISE, output.Database, output.Parent, input.Position);
        }

        private static LCDState Convert(CBRNSensorLCDState wstate)
        {
            LCDState state = new LCDState();

            state.GAlert                 = wstate.GAlertValue                 == 1;
            state.HAlert                 = wstate.HAlertValue                 == 1;
            state.TICAlert               = wstate.TICAlertValue               == 1;
            state.TICMode                = wstate.TICModeValue                == 1;
            state.LowSieve               = wstate.LowSieveValue               == 1;
            state.ChangeSievePack        = wstate.ChangeSievePackValue        == 1;
            state.LowBattery             = wstate.LowBatteryValue             == 1;
            state.ChangeBattery          = wstate.ChangeBatteryValue          == 1;
            state.GHighDoseAlert         = wstate.GHighDoseAlertValue         == 1;
            state.GMediumDoseAlert       = wstate.GMediumDoseAlertValue       == 1;
            state.HHighDoseAlert         = wstate.HHighDoseAlertValue         == 1;
            state.InitialSelfTest        = wstate.InitialSelfTestValue        == 1;
            state.CoronaBurnOff          = wstate.CoronaBurnOffValue          == 1;
            state.PTOutOfRange           = wstate.PTOutOfRangeValue           == 1;
            state.AudioFault             = wstate.AudioFaultValue             == 1;
            state.FatalError             = wstate.FatalErrorValue             == 1;
            state.CRAboveLimit           = wstate.CRAboveLimitValue           == 1;
            state.FanCAboveLimit         = wstate.FanCAboveLimitValue         == 1;
            state.InitialSelfTestFailure = wstate.InitialSelfTestFailureValue == 1;
            state.HealthCheckFailure     = wstate.HealthCheckFailureValue     == 1;
            state.CodeChecksumError      = wstate.CodeChecksumErrorValue      == 1;
            state.EEPROMChecksumError    = wstate.EEPROMChecksumErrorValue    == 1;
            state.HTOutSideLimits        = wstate.HTOutSideLimitsValue        == 1;
            state.AudibleAlarm           = wstate.AudibleAlarmValue           == 1;

            return state;
        }

        // You might be surprised by this wonky function. Why not take the `wstate` as a ref for example?
        //
        // Well, thats actually impossible.
        //
        // w.SensorState evokes a getter that fetches the attributes from the WISE-API and wrapps them in a (new) state object.
        // This means that you are just modifying a temporary object when you do seemingly normal things
        // like w.SensorState.PurgeValue = 1. Instead, you need to save the created state object, make your changes,
        // then evoke the setter of w.SensorState (eg w.SensorState = wstate).
        //
        // Yes, this is actually how it works. No, this is not documented (none of the generated files are, you need to read them to use them).
        private static CBRNSensorLCDState Convert(LCDState state, CBRNSensorLCDState wstate)
        {
            wstate.GAlertValue                 = (byte)(state.GAlert                 ? 1 : 0);
            wstate.HAlertValue                 = (byte)(state.HAlert                 ? 1 : 0);
            wstate.TICAlertValue               = (byte)(state.TICAlert               ? 1 : 0);
            wstate.TICModeValue                = (byte)(state.TICMode                ? 1 : 0);
            wstate.LowSieveValue               = (byte)(state.LowSieve               ? 1 : 0);
            wstate.ChangeSievePackValue        = (byte)(state.ChangeSievePack        ? 1 : 0);
            wstate.LowBatteryValue             = (byte)(state.LowBattery             ? 1 : 0);
            wstate.ChangeBatteryValue          = (byte)(state.ChangeBattery          ? 1 : 0);
            wstate.GHighDoseAlertValue         = (byte)(state.GHighDoseAlert         ? 1 : 0);
            wstate.GMediumDoseAlertValue       = (byte)(state.GMediumDoseAlert       ? 1 : 0);
            wstate.HHighDoseAlertValue         = (byte)(state.HHighDoseAlert         ? 1 : 0);
            wstate.InitialSelfTestValue        = (byte)(state.InitialSelfTest        ? 1 : 0);
            wstate.CoronaBurnOffValue          = (byte)(state.CoronaBurnOff          ? 1 : 0);
            wstate.PTOutOfRangeValue           = (byte)(state.PTOutOfRange           ? 1 : 0);
            wstate.AudioFaultValue             = (byte)(state.AudioFault             ? 1 : 0);
            wstate.FatalErrorValue             = (byte)(state.FatalError             ? 1 : 0);
            wstate.CRAboveLimitValue           = (byte)(state.CRAboveLimit           ? 1 : 0);
            wstate.FanCAboveLimitValue         = (byte)(state.FanCAboveLimit         ? 1 : 0);
            wstate.InitialSelfTestFailureValue = (byte)(state.InitialSelfTestFailure ? 1 : 0);
            wstate.HealthCheckFailureValue     = (byte)(state.HealthCheckFailure     ? 1 : 0);
            wstate.CodeChecksumErrorValue      = (byte)(state.CodeChecksumError      ? 1 : 0);
            wstate.EEPROMChecksumErrorValue    = (byte)(state.EEPROMChecksumError    ? 1 : 0);
            wstate.HTOutSideLimitsValue        = (byte)(state.HTOutSideLimits        ? 1 : 0);
            wstate.AudibleAlarmValue           = (byte)(state.AudibleAlarm           ? 1 : 0);

            return wstate;
        }

        private static IEnumerable<LCDData> ConvertLCDData(GroupList wDataList, INETWISEStringCache stringCache)
        {
            return Convert<LCDData>(wDataList, delegate(AttributeGroup attrGroup)
            {
                CBRNSensorLCDData wdata = new CBRNSensorLCDData("SensorData", stringCache, attrGroup);
                LCDData data = new LCDData();
                data.BarCount = wdata.BarCountValue;
                data.VolumeConcentration = wdata.VolumeConcentrationValue;
                data.SubstanceCategory = wdata.SubstanceCategoryValue;
                return data;
            });
        }

        private static GroupList ConvertLCDData(IEnumerable<LCDData> dataList, INETWISEStringCache stringCache)
        {
            return Convert<LCDData>(dataList, delegate(LCDData data)
            {
                CBRNSensorLCDData wdata = new CBRNSensorLCDData("SensorData", stringCache, new AttributeGroup());
                wdata.BarCountValue = data.BarCount;
                wdata.VolumeConcentrationValue = data.VolumeConcentration;
                return wdata.Data;
            });
        }

        #endregion

        #region AP2Ce

        internal static AP2Ce Convert(EntityEquipmentSensorCBRNAP2Ce input)
        {
            AP2Ce output = new AP2Ce();
            output.Id          = input.ExternalId;
            output.Name        = input.Name;
            output.Description = input.Description;
            output.Position    = getPosition(input.WISE, input.Database, input.Parent);
            output.Data        = ConvertAP2CeData(input.SensorData, input.StringCache);
            output.State       = Convert(input.SensorState);

            return output;
        }

        internal static void Convert(AP2Ce input, ref EntityEquipmentSensorCBRNAP2Ce output)
        {
            output.ExternalId  = input.Id;
            output.Name        = input.Name;
            output.Description = input.Description;
            output.SensorState = Convert(input.State, output.SensorState);
            output.SensorData  = ConvertAP2CeData(input.Data, output.StringCache);
            setPosition(output.WISE, output.Database, output.Parent, input.Position);
        }

        internal static AP2CeState Convert(CBRNSensorAP2CeState wstate)
        {
            AP2CeState state = new AP2CeState();

            state.BatteryLow        = wstate.BatteryLowValue        == 1;
            state.DetectorReady     = wstate.DetectorReadyValue     == 1;
            state.DeviceFault       = wstate.DeviceFaultValue       == 1;
            state.HydrogenTankEmpty = wstate.HydrogenTankEmptyValue == 1;
            state.Purge             = wstate.PurgeValue             == 1;

            return state;
        }

        internal static CBRNSensorAP2CeState Convert(AP2CeState state, CBRNSensorAP2CeState wstate)
        {
            wstate.PurgeValue             = (byte)(state.Purge             ? 1 : 0);
            wstate.BatteryLowValue        = (byte)(state.BatteryLow        ? 1 : 0);
            wstate.DetectorReadyValue     = (byte)(state.DetectorReady     ? 1 : 0);
            wstate.HydrogenTankEmptyValue = (byte)(state.HydrogenTankEmpty ? 1 : 0);
            wstate.DeviceFaultValue       = (byte)(state.DeviceFault       ? 1 : 0);
            return wstate;
        }

        private static IEnumerable<AP2CeData> ConvertAP2CeData(GroupList wDataList, INETWISEStringCache stringCache)
        {
            return Convert<AP2CeData>(wDataList, delegate(AttributeGroup attrGroup)
            {
                CBRNSensorAP2CeData wdata = new CBRNSensorAP2CeData("SensorData", stringCache, attrGroup);
                AP2CeData data = new AP2CeData();
                data.BarCount = wdata.BarCountValue;
                data.VolumeConcentration = wdata.VolumeConcentrationValue;
                data.SubstanceCategory = wdata.SubstanceCategoryValue;
                return data;
            });
        }

        private static GroupList ConvertAP2CeData(IEnumerable<AP2CeData> dataList, INETWISEStringCache stringCache)
        {
            return Convert<AP2CeData>(dataList, delegate(AP2CeData data)
            {
                CBRNSensorAP2CeData wdata = new CBRNSensorAP2CeData("SensorData", stringCache, new AttributeGroup());
                wdata.BarCountValue = data.BarCount;
                wdata.VolumeConcentrationValue = data.VolumeConcentration;
                return wdata.Data;
            });
        }

        #endregion

        #region generic helpers

        private static GroupList Convert<DataContract>(IEnumerable<DataContract> dataList, Func<DataContract, AttributeGroup> loadDataInto)
        {
            GroupList wDataList = new GroupList();
            foreach (DataContract data in dataList) wDataList.Add(loadDataInto(data));
            return wDataList;
        }

        private static IEnumerable<DataContract> Convert<DataContract>(GroupList wDataList, Func<AttributeGroup, DataContract> loadDataInto)
        {
            List<DataContract> dataList = new List<DataContract>();
            foreach (AttributeGroup attrGroup in wDataList) dataList.Add(loadDataInto(attrGroup));
            return dataList;
        }

        private static Position getPosition(INETWISEDriverSink2 sink, DatabaseHandle hDatabase, ObjectHandle hParent)
        {
            EntityGroundVehicle parent = new EntityGroundVehicle(sink, hDatabase, hParent);
            Position pos = new Position();
            pos.Longitude = parent.Position.V1;
            pos.Latitude = parent.Position.V2;
            pos.Altitude = parent.Position.V3;
            return pos;
        }

        private static void setPosition(INETWISEDriverSink2 sink, DatabaseHandle hDatabase, ObjectHandle hParent, Position pos)
        {
            EntityGroundVehicle parent = new EntityGroundVehicle(sink, hDatabase, hParent);
            parent.Position = new Vec3(pos.Longitude, pos.Latitude, pos.Altitude);
        }

        #endregion
    }
}
