using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    class RAID : SensorBase
    {
        private IEnumerable<RAIDData> _data;
        private RAIDState _state;

        public IEnumerable<RAIDData> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public RAIDState State
        {
            get { return _state; }
            set { _state = value; }
        }

    }
}
