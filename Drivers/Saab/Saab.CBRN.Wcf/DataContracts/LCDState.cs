using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class LCDState
    {
        private bool _gAlert;
        private bool _hAlert;
        private bool _ticAlert;
        private bool _ticMode;
        private bool _lowSieve;
        private bool _changeSievePack;
        private bool _lowBattery;
        private bool _changeBattery;
        private bool _gHighDoseAlert;
        private bool _gMediumDoseAlert;
        private bool _hHighDoseAlert;
        private bool _initialSelfTest;
        private bool _coronaBurnOff;
        private bool _pTOutOfRange;
        private bool _audioFault;
        private bool _fatalError;
        private bool _crAboveLimit;
        private bool _fanCAboveLimit;
        private bool _initialSelftTestFailed;
        private bool _healthCheckFailur;
        private bool _codeCheckFailur;
        private bool _codeChecksumError;
        private bool _eEPROMCHecksumError;
        private bool _htOutSideLimits;

        [DataMember]
        public bool GAlert
        {
            get { return _gAlert; }
            set { _gAlert = value; }
        }

        // TODO: Add data member for each state
    }
}
