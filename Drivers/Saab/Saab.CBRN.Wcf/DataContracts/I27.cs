using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I27 : SensorBase
    {
        private I27Data _data;
        private I27State _state;

        [DataMember]
        public I27Data Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public I27State State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
