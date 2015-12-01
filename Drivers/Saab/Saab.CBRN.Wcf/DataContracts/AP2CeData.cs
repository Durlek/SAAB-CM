using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class AP2CeData
    {
        private byte _barCount;
        private double _volumeConcentration;
        private string _substanceCategory;

        [DataMember]
        public byte BarCount
        {
            get { return _barCount; }
            set { _barCount = value; }
        }

        [DataMember]
        public double VolumeConcentration
        {
            get { return _volumeConcentration; }
            set { _volumeConcentration = value;  }
        }

        [DataMember]
        public string SubstanceCategory
        {
            get { return _substanceCategory; }
            set { _substanceCategory = value; }
        }
    }
}
