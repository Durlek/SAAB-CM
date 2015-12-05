using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    class RAIDData
    {
        private string _substance;
        private int _barCount;
        private int _substanceClass;
        private int _concentrationUnit;
        private double _concentration;

		public string Substance {
			get { return _substance; }
			set { _substance = value; }
		}

		public int BarCount {
			get { return _barCount; }
			set { _barCount = value; }
		}

		public int SubstanceClass {
			get { return _substanceClass; }
			set { _substanceClass = value; }
		}

		public int ConcentrationUnit {
			get { return _concentrationUnit; }
			set { _concentrationUnit = value; }
		}

		public double Concentration {
			get { return _concentration; }
			set { _concentration = value; }
		}
    }
}
