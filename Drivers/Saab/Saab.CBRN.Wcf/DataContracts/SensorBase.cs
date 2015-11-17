using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Saab.CBRN.Wcf.DataContracts
{
    [DataContract]
    public abstract class SensorBase
    {
        private string _id;
        private string _name;
        private string _description;
        private object _equipmentType;
        private object _parent;
        private Position _position;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
