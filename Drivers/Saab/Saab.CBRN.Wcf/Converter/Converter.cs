using Saab.CBRNSensors.Models;
using Saab.CBRN.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// TODO: lots of duplicated code

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
            output.Position = null; // TODO: Get from parent (input.Parent)
            output.Data = Convert(input.SensorData);
            output.DetectionMode = (LCDDetectionMode)Enum.Parse(typeof(LCDDetectionMode), input.DetectionMode.ToString());
            output.State = Convert(input.SensorState);

            return output;
        }

        internal static void Convert(LCD input, ref EntityEquipmentSensorCBRNLCD output)
        {
            output.ExternalId = input.Id;
            output.Name = input.Name;
            output.Description = input.Description;
            output.SensorData = Convert(input.Data);
        }

        private static LCDState Convert(CBRNSensorLCDState wstate)
        {
            LCDState state = new LCDState();

            // TODO: In the example code, `state` uses booleans and `wstate` uses bytes. 
            //       I have no idea if this is intentional, and since we don't have any real data
            //       it's hard to know what the bytes represent (are they really only bools in disguise?)
            //       I'm 30% sure that bools don't exist in wise, so it seems likely.
            state.GAlert = wstate.GAlertValue == 0 ? false : true;
            state.HAlert = wstate.HAlertValue == 0 ? false : true;
            state.TicAlert = wstate.TICAlertValue == 0 ? false : true;
            state.TicMode = wstate.TICModeValue == 0 ? false : true;
            state.LowSieve = wstate.LowSieveValue == 0 ? false : true;
            state.ChangeSievePack = wstate.ChangeSievePackValue == 0 ? false : true;
            state.LowBattery = wstate.LowBatteryValue == 0 ? false : true;
            state.ChangeBattery = wstate.ChangeBatteryValue == 0 ? false : true;
            state.GHighDoseAlert = wstate.GHighDoseAlertValue == 0 ? false : true;
            state.GMediumDoseAlert = wstate.GMediumDoseAlertValue == 0 ? false : true;
            state.HHighDoseAlert = wstate.HHighDoseAlertValue == 0 ? false : true;
            state.InitialSelfTest = wstate.InitialSelfTestValue == 0 ? false : true;
            state.CoronaBurnOff = wstate.CoronaBurnOffValue == 0 ? false : true;
            state.PTOutOfRange = wstate.PTOutOfRangeValue == 0 ? false : true;
            state.AudioFault = wstate.AudioFaultValue == 0 ? false : true;
            state.FatalError = wstate.FatalErrorValue == 0 ? false : true;
            state.CRAboveLimit = wstate.CRAboveLimitValue == 0 ? false : true;
            state.FanCAboveLimit = wstate.FanCAboveLimitValue == 0 ? false : true;
            state.InitialSeltTestFailed = wstate.InitialSelfTestFailureValue == 0 ? false : true;
            state.HealthCheckFailur = wstate.HealthCheckFailureValue == 0 ? false : true;
            state.CodeChecksumError = wstate.CodeChecksumErrorValue == 0 ? false : true;
            state.EEPROMChecksumError = wstate.EEPROMChecksumErrorValue == 0 ? false : true;
            state.HTOutSideLimits = wstate.HTOutSideLimitsValue == 0 ? false : true;


            return state;
        }

        private static IEnumerable<LCDData> Convert(STS.WISE.GroupList groupList)
        {
            //
            // TODO: Convert
            //

            return new List<LCDData>(3);
        }

        private static STS.WISE.GroupList Convert(IEnumerable<LCDData> data)
        {
            //
            // TODO: Convert
            //

            return new STS.WISE.GroupList();
        }

        #endregion

        #region AP2Ce

        internal static AP2Ce Convert(EntityEquipmentSensorCBRNAP2Ce input)
        {
            AP2Ce output = new AP2Ce();
            output.Id = input.ExternalId;
            output.Name = input.Name;
            output.Description = input.Description;
            output.Position = null; // TODO: Get from parent (input.Parent)
            //output.Data = Convert(input.SensorData);
            //output.DetectionMode = (LCDDetectionMode)Enum.Parse(typeof(LCDDetectionMode), input.DetectionMode.ToString());
            //output.State = Convert(input.SensorState);

            return output;
        }

        internal static void Convert(AP2Ce input, ref EntityEquipmentSensorCBRNAP2Ce output)
        {
            output.ExternalId  = input.Id;
            output.Name        = input.Name;
            output.Description = input.Description;
            //output.SensorData = Convert(input.Data);
        }

        #endregion
    }
}
