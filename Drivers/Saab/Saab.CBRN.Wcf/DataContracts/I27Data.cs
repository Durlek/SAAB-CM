using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I27Data
    {
        private int _leftProseDoseRate;
        private int _internalDoseRate;
        private int _rightProbeDoseRate;
        private int _accumulatedDose;
        private string _timeOfLastReset;

        [DataMember]
        public int LeftProbeDoseRate
        {
            get { return _leftProseDoseRate; }
            set { _leftProseDoseRate = value; }
        }

        [DataMember]
        public int InternalDoseRate
        {
            get { return _internalDoseRate; }
            set { _internalDoseRate = value; }
        }

        [DataMember]
        public int RightProbeDoseRate
        {
            get { return _rightProbeDoseRate; }
            set { _rightProbeDoseRate = value; }
        }

        [DataMember]
        public int AccumulatedDose
        {
            get { return _accumulatedDose; }
            set { _accumulatedDose = value; }
        }

        [DataMember]
        public string TimeOfLastReset
        {
            get { return _timeOfLastReset; }
            set { _timeOfLastReset = value; }
        }
    }
}
