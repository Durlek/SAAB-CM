using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I28State
    {
        private int _errorcode;

        [DataMember]
        public int ErrorCode
        {
            get { return _errorcode; }
            set { _errorcode = value; }
        }
    }
}
