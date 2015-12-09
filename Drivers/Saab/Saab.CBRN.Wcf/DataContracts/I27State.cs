using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I27State
    {
        private bool _batteryLow;
        private bool _temperatureLow;

        [DataMember]
        public bool BatteryLow
        {
            get { return _batteryLow; }
            set { _batteryLow = value; }
        }

        [DataMember]
        public bool TemperatureError
        {
            get { return _temperatureLow; }
            set { _temperatureLow = value; }
        }
    }
}
