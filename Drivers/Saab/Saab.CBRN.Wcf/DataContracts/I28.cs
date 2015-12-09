using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I28 : SensorBase
    {
        private I28Data _data;
        private I28State _state;

        [DataMember]
        public I28Data Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public I28State State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
