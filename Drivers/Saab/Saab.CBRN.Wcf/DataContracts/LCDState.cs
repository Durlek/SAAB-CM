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
        private bool _cRAboveLimit;
        private bool _fanCAboveLimit;
        private bool _initialSelfTestFailed;
        private bool _healthCheckFailur;
        private bool _codeChecksumError;
        private bool _eEPROMChecksumError;
        private bool _hTOutSideLimits;

        [DataMember]
        public bool GAlert
        {
            get { return _gAlert; }
            set { _gAlert = value; }
        }

        [DataMember]
        public bool HAlert
        {
            get { return _hAlert; }
            set { _hAlert = value; }
        }

        [DataMember]
        public bool TicAlert
        {
            get { return _ticAlert; }
            set { _ticAlert = value; }
        }

        [DataMember]
        public bool TicMode
        {
            get { return _ticMode; }
            set { _ticMode = value; }
        }

        [DataMember]
        public bool LowSieve
        {
            get { return _lowSieve; }
            set { _lowSieve = value; }
        }

        [DataMember]
        public bool ChangeSievePack
        {
            get { return _changeSievePack; }
            set { _changeSievePack = value; }
        }

        [DataMember]
        public bool LowBattery
        {
            get { return _lowBattery; }
            set { _lowBattery = value; }
        }

        [DataMember]
        public bool ChangeBattery
        {
            get { return _changeBattery; }
            set { _changeBattery = value; }
        }

        [DataMember]
        public bool GHighDoseAlert
        {
            get { return _gHighDoseAlert; }
            set { _gHighDoseAlert = value; }
        }

        [DataMember]
        public bool GMediumDoseAlert
        {
            get { return _gMediumDoseAlert; }
            set { _gMediumDoseAlert = value; }
        }

        [DataMember]
        public bool HHighDoseAlert
        {
            get { return _hHighDoseAlert; }
            set { _hHighDoseAlert = value; }
        }

        [DataMember]
        public bool InitialSelfTest
        {
            get { return _initialSelfTest; }
            set { _initialSelfTest = value; }
        }

        [DataMember]
        public bool CoronaBurnOff
        {
            get { return _coronaBurnOff; }
            set { _coronaBurnOff = value; }
        }

        [DataMember]
        public bool PTOutOfRange
        {
            get { return _pTOutOfRange; }
            set { _pTOutOfRange = value; }
        }

        [DataMember]
        public bool AudioFault
        {
            get { return _audioFault; }
            set { _audioFault = value; }
        }

        [DataMember]
        public bool FatalError
        {
            get { return _fatalError; }
            set { _fatalError = value; }
        }

        [DataMember]
        public bool CRAboveLimit
        {
            get { return _cRAboveLimit; }
            set { _cRAboveLimit = value; }
        }

        [DataMember]
        public bool FanCAboveLimit
        {
            get { return _fanCAboveLimit; }
            set { _fanCAboveLimit = value; }
        }

        [DataMember]
        public bool InitialSeltTestFailed
        {
            get { return _initialSelfTestFailed; }
            set { _initialSelfTestFailed = value; }
        }

        [DataMember]
        public bool HealthCheckFailur
        {
            get { return _healthCheckFailur; }
            set { _healthCheckFailur = value; }
        }

        [DataMember]
        public bool CodeChecksumError
        {
            get { return _codeChecksumError; }
            set { _codeChecksumError = value; }
        }

        [DataMember]
        public bool EEPROMChecksumError
        {
            get { return _eEPROMChecksumError; }
            set { _eEPROMChecksumError = value; }
        }

        [DataMember]
        public bool HTOutSideLimits
        {
            get { return _hTOutSideLimits; }
            set { _hTOutSideLimits = value; }
        }
    }
}
