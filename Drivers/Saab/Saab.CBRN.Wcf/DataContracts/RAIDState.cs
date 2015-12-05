using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class RAIDState
    {
        private int _substanceLibrary;
        private int _deviceState;
        private int _deviceError;
        private RAIDInternalState _internalState;

        public int SubstanceLibrary {
        	get { return _substanceLibrary; }
        	set { _substanceLibrary = value; }
        }
        public int DeviceState {
        	get { return _deviceState; }
        	set { _deviceState = value; }
        }
        public int DeviceError {
        	get { return _deviceError; }
        	set { _deviceError = value; }
        }
        public RAIDInternalState InternalState {
        	get { return _internalState; }
        	set { _internalState = value; }
        }
    }
}
