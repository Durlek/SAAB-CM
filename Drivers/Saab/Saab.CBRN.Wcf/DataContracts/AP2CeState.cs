using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    class AP2CeState
    {
        private bool _hydrogenTankEmpty;
        private bool _deviceFault;
        private bool _detectorReady;
        private bool _purge;
        private bool _batteryLow;


    	[DataMember]
        public bool HydrogenTankEmpty
        {
        	get { return _hydrogenTankEmpty;  }
        	set { _hydrogenTankEmpty = value; }	
        }

    	[DataMember]
        public bool DeviceFault
        {
        	get { return _deviceFault;  }
        	set { _deviceFault = value; }	
        }

    	[DataMember]
        public bool DetectorReady
        {
        	get { return _detectorReady;  }
        	set { _detectorReady = value; }	
        }

    	[DataMember]
        public bool Purge
        {
        	get { return _purge;  }
        	set { _purge = value; }	
        }

    	[DataMember]
        public bool BatteryLow
        {
        	get { return _batteryLow;  }
        	set { _batteryLow = value; }	
        }

    }
}
