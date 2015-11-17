using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class LCD : SensorBase
    {
        private IEnumerable<LCDData> _data;
        private LCDState _state;
        private LCDDetectionMode _detectionMode;

        [DataMember]
        public IEnumerable<LCDData> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public LCDState State
        {
            get { return _state; }
            set { _state = value; }
        }

        [DataMember]
        public LCDDetectionMode DetectionMode
        {
            get { return _detectionMode; }
            set { _detectionMode = value; }
        }
    }
}
