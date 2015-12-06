using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class I28Data
    {
        private int _currentDoseRate;
        private int _peakDoseRate;
        private int _accumulatedDoseRate;

        [DataMember]
        public int CurrentDoseRate
        {
            get { return _currentDoseRate; }
            set { _currentDoseRate = value; }
        }

        [DataMember]
        public int PeakDoseRate
        {
            get { return _peakDoseRate; }
            set { _peakDoseRate = value; }
        }

        [DataMember]
        public int AccumulatedDoseRate
        {
            get { return _accumulatedDoseRate; }
            set { _accumulatedDoseRate = value; }
        }
    }
}
