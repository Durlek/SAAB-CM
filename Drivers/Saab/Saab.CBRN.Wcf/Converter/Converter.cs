using Saab.CBRN.Generated;
using Saab.CBRN.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal static EntityEquipmentSensorCBRNLCD Convert(LCD input)
        {

            EntityEquipmentSensorCBRNLCD output = new EntityEquipmentSensorCBRNLCD();
            output.ExternalId = input.Id;
            output.Name = input.Name;
            output.Description = input.Description;
            output.SensorData = Convert(input.Data);
            return output;
        }

        private static LCDState Convert(CBRNSensorLCDState wstate)
        {
            LCDState state = new LCDState();

            // TODO: In the example code, `state` uses booleans and `wstate` uses bytes. 
            //       I have no idea if this is intentional, and since we don't have any real data
            //       it's hard to know what the bytes represent (are they really only bools in disguise?)
            //       I'm 30% sure that bools don't exist in wise, so it seems likely.
            state.GAlert = wstate.GAlert == 0 ? false : true;
            state.HAlert = wstate.HAlert == 0 ? false : true;
            state.TicAlert = wstate.TICAlert == 0 ? false : true;
            state.TicMode = wstate.TICMode == 0 ? false : true;
            state.LowSieve = wstate.LowSieve == 0 ? false : true;
            state.ChangeSievePack = wstate.ChangeSievePack == 0 ? false : true;
            state.LowBattery = wstate.LowBattery == 0 ? false : true;
            state.ChangeBattery = wstate.ChangeBattery == 0 ? false : true;
            state.GHighDoseAlert = wstate.GHighDoseAlert == 0 ? false : true;
            state.GMediumDoseAlert = wstate.GMediumDoseAlert == 0 ? false : true;
            state.HHighDoseAlert = wstate.HHighDoseAlert == 0 ? false : true;
            state.InitialSelfTest = wstate.InitialSelfTest == 0 ? false : true;
            state.CoronaBurnOff = wstate.CoronaBurnOff == 0 ? false : true;
            state.PTOutOfRange = wstate.PTOutOfRange == 0 ? false : true;
            state.AudioFault = wstate.AudioFault == 0 ? false : true;
            state.FatalError = wstate.FatalError == 0 ? false : true;
            state.CRAboveLimit = wstate.CRAboveLimit == 0 ? false : true;
            state.FanCAboveLimit = wstate.FanCAboveLimit == 0 ? false : true;
            state.InitialSeltTestFailed = wstate.InitialSelfTestFailure == 0 ? false : true;
            state.HealthCheckFailur = wstate.HealthCheckFailure == 0 ? false : true;
            state.CodeChecksumError = wstate.CodeChecksumError == 0 ? false : true;
            state.EEPROMChecksumError = wstate.EEPROMChecksumError == 0 ? false : true;
            state.HTOutSideLimits = wstate.HTOutSideLimits == 0 ? false : true;


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

        #endregion
    }
}
