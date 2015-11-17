using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    public class Position
    {
        private double _longitude;
        private double _latitude;
        private double _altitud;

        [DataMember]
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        [DataMember]
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        [DataMember]
        public double Altitude
        {
            get { return _altitud; }
            set { _altitud = value; }
        }
    }
}
