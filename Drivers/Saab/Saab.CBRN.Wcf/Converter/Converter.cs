using CBRNSensors;
using Saab.CBRN.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf
{
    public class Converter
    {
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

        private static LCDState Convert(CBRNSensorLCDState cBRNSensorLCDState)
        {
            //
            // TODO: Convert
            //

            return new LCDState();
        }

        private static IEnumerable<LCDData> Convert(STS.WISE.GroupList groupList)
        {
            //
            // TODO: Convert
            //

            return new List<LCDData>(3);
        }
    }
}
