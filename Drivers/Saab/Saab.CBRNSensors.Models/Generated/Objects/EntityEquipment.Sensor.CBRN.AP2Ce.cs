using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public partial class EntityEquipmentSensorCBRNAP2Ce
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in EntityEquipmentSensorCBRNAP2Ce objects.
        /// </summary>
        public enum Attributes
        {
            Unknown,
            Description,
            EquipmentType,
            ExternalId,
            Name,
            Parent,
            RelativeLocation,
            SensorData,
            SensorRawData,
            SensorState,
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, EntityEquipmentSensorCBRNAP2Ce.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<EntityEquipmentSensorCBRNAP2Ce.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();
        protected static ClassHandle _classHandle = WISEConstants.WISE_INVALID_HANDLE;

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "EntityEquipment.Sensor.CBRN.AP2Ce"; }
        }

        static public ClassHandle Class
        {
            get { return _classHandle; }
        }

        public string ObjectName
        {
            get
            {
                string objectName = "";

                if (this.Object != WISEConstants.WISE_INVALID_HANDLE)
                {
                    this.WISE.GetObjectName(this.Database, this.Object, ref objectName);
                }
                return objectName;
            }
        }

        public CBRNSensorsEntityTypes ClassEntityType
        {
            get { return CBRNSensorsEntityTypes.EntityEquipmentSensorCBRNAP2Ce; }
        }

        public INETWISEDriverSink2 WISE { get; private set; }

        public INETWISEStringCache StringCache
        {
            get { return (this.WISE as INETWISEStringCache); }
        }

        public DatabaseHandle Database { get; private set; }

        public ObjectHandle Object { get; private set; }

        public TransactionHandle Transaction { get; private set; }

        #endregion

        #region Constructors

        public EntityEquipmentSensorCBRNAP2Ce()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Object = WISEConstants.WISE_INVALID_HANDLE;
            this.Transaction = TransactionHandle.None;            
        }

        public EntityEquipmentSensorCBRNAP2Ce(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = TransactionHandle.None;
        }

        public EntityEquipmentSensorCBRNAP2Ce(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle, TransactionHandle transactionHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = transactionHandle;
        }

        #endregion

        #region Initialization methods

        static public bool Initialize(INETWISEStringCache cache)
        {
            if (cache == null)
            {
                return false;
            }

            if (!IsInitialized())
            {
                // Generate the class handle
                uint classId = 0;
                
                cache.AddString(ClassName, ref classId);
                
                _classHandle = classId;
                
                lock (_nameIdIndex)
                {
                    _nameIdIndex.Add("Description", Attributes.Description);
                    _nameIdIndex.Add("EquipmentType", Attributes.EquipmentType);
                    _nameIdIndex.Add("ExternalId", Attributes.ExternalId);
                    _nameIdIndex.Add("Name", Attributes.Name);
                    _nameIdIndex.Add("Parent", Attributes.Parent);
                    _nameIdIndex.Add("RelativeLocation", Attributes.RelativeLocation);
                    _nameIdIndex.Add("SensorData", Attributes.SensorData);
                    _nameIdIndex.Add("SensorRawData", Attributes.SensorRawData);
                    _nameIdIndex.Add("SensorState", Attributes.SensorState);

                    lock (_idHandleIndex)
                    {
                        if (_nameIdIndex.Count > 0 && _idHandleIndex.Count == 0)
                        {
                            foreach (KeyValuePair<string, Attributes> item in _nameIdIndex.FirstToSecond)
                            {
                                uint attrId = 0;
                                cache.AddString(item.Key, ref attrId);
                                _idHandleIndex.Add(item.Value, new AttributeHandle(attrId));
                            }
                        }
                    }
                }
            }
            return true;
        }
		
		static public void UnInitialize()
		{
			lock (_nameIdIndex)
            {
				lock (_idHandleIndex)
				{
					_nameIdIndex.Clear();
					_idHandleIndex.Clear();
					
				}
			}
		}

        static private bool IsInitialized()
        {
            lock (_idHandleIndex)
            {
                return ((_idHandleIndex != null) && (_idHandleIndex.Count > 0));
            }
        }

        public void Clear()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Object = WISEConstants.WISE_INVALID_HANDLE;
        }

        #endregion

        #region Attribute lookup helpers

        public Attributes GetAttributeIdFromHandle(AttributeHandle hAttribute)
        {
            if(_idHandleIndex.ExistSecond(hAttribute))
            {
                return _idHandleIndex.GetBySecond(hAttribute);
            }

            return Attributes.Unknown;
        }

        public Attributes GetAttributeIdFromName(string strAttrName)
        {
            try
            {
                Attributes attr = _nameIdIndex.GetByFirst(strAttrName);
                return attr;
            }
            catch
            {
                return Attributes.Unknown;
            }
        }

        public AttributeHandle GetHandleFromAttributeId(Attributes attr)
        {
            try
            {
                AttributeHandle hAttr = _idHandleIndex.GetByFirst(attr);
                return hAttr;
            }
            catch
            {
                return WISEConstants.WISE_INVALID_HANDLE;
            }
        }

        public AttributeHandle GetHandleFromAttributeName(string strAttrName)
        {
            Attributes attr = GetAttributeIdFromName(strAttrName);
            return GetHandleFromAttributeId(attr);
        }

        public string GetAttributeNameFromId(Attributes attribute)
        {
            lock (_nameIdIndex)
            {
                if(_nameIdIndex.ExistSecond(attribute))
                {
                    return _nameIdIndex.GetBySecond(attribute);
                }
            }
            return string.Empty;
        }
    
        public string GetAttributeNameFromHandle(AttributeHandle hAttribute)
        {
            Attributes attr = GetAttributeIdFromHandle(hAttribute);
            return GetAttributeNameFromId(attr);
        }
    
        #endregion

        #region Type methods

        static public bool IsTypeOf(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, ObjectHandle hObject)
        {
            uint result = WISEError.WISE_ERROR;
            AttributeHandle hAttr = WISEConstants.WISE_INVALID_HANDLE;
            string strEntityType = string.Empty;

            if ((WISE == null) || (hObject == WISEConstants.WISE_INVALID_HANDLE))
            {
                return false;
            }

            result = WISE.GetAttributeHandle(hDatabase, hObject, WISEConstants.WISE_TEMPLATE_OBJECT_TYPE, ref hAttr);
            if (WISEError.CheckCallFailed(result))
            {
                return false;
            }

            result = WISE.GetAttributeValue(hDatabase, hObject, hAttr, ref strEntityType);
            
            return WISEError.CheckCallSucceeded(result) && IsTypeOf(strEntityType);
        }

        static public bool IsTypeOf(string className)
        {
            return (className == EntityEquipmentSensorCBRNAP2Ce.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == EntityEquipmentSensorCBRNAP2Ce.Class);
        }

        #endregion

        #region Object creation methods

        public uint CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase)
        {
            return CreateInstance(WISE, hDatabase, "");
        }

        public uint CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, string objectName)
        {
            uint result = WISEError.WISE_ERROR;
            ObjectHandle objectHandle = this.Object;

            if (WISE == null)
            {
                result = WISEError.WISE_E_INVALID_ARG;
                return result;
            }

            if (objectHandle == WISEConstants.WISE_INVALID_HANDLE)
            {
                // Create object from template, if none exist.
                Dictionary<string, AttributeHandle> attributes = new Dictionary<string, AttributeHandle>(); // it's set from Template
                result = WISE.CreateObjectFromTemplate(hDatabase, objectName, EntityEquipmentSensorCBRNAP2Ce.ClassName, ref objectHandle, ref attributes);
            }

            if (WISEError.CheckCallSucceeded(result))
            {
                this.WISE = WISE;
                this.Database = WISEConstants.WISE_INVALID_HANDLE;
                this.Object = objectHandle;
            }

            return result;
        }

        public uint AddToDatabase(DatabaseHandle databaseHandle)
        {
            uint result = WISEError.WISE_ERROR;
            ObjectHandle hObjectTemp = this.Object;

            if (this.WISE == null)
            {
                result = WISEError.WISE_E_INVALID_ARG;
                return result;
            }

            result = this.WISE.AddObjectToDatabase(databaseHandle, hObjectTemp);

            if (WISEError.CheckCallSucceeded(result))
            {
                this.Database = databaseHandle;
                this.Object = hObjectTemp;
            }

            return result;
        }

        #endregion

        #region Attribute value properties
// OBJECTIMPL: String
        public string Description
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Description);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Description);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string EquipmentType
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EquipmentType);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EquipmentType);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string ExternalId
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ExternalId);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ExternalId);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string Name
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Name);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Name);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Parent
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Parent);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return WISEConstants.WISE_INVALID_HANDLE;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Parent);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 RelativeLocation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RelativeLocation);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return Vec3.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RelativeLocation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: AttributeGroupList
        public STS.WISE.GroupList SensorData
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.GroupList value = new STS.WISE.GroupList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorData);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return null;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorData);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: AttributeGroupList
        public STS.WISE.GroupList SensorRawData
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.GroupList value = new STS.WISE.GroupList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorRawData);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return null;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorRawData);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: AttributeGroup
        public CBRNSensorAP2CeState SensorState   
        {
            get
            {
                AttributeGroup value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorState);
                }

                if (this.WISE != null)
                {   
                    this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);
                }
                return new CBRNSensorAP2CeState(attributeHandle, this.StringCache, value);
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorState);
                AttributeGroup newValue = new AttributeGroup();
                
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(
                        "Attribute '{0}' cannot be set to null.",
                        GetAttributeNameFromId(Attributes.SensorState)));
                }

                if (value.ParentAttribute == attributeHandle)
                {
                    newValue = value.Data;
                }
                else if (value.ParentAttribute != attributeHandle)
                {
                    // Copy attribute values
                    // Since the parent attributes differ we need to convert 
                    // the handles of the incoming group to the corresponding 
                    // handle values for this group
                    // This occurs when a composite is used in multiple groups/attributes
                    // for instance two attributes named "A" and "B" are defined on the same object.
                    // These attributes are composites of type "Composite1" which has the fields
                    // "Field1" and "Field2".
                    // The fields in attribute "A" will be named "A.Field1" and "A.Field2"
                    // The fields in attribute "B" will be named "B.Field1" and "B.Field2"
                    // Using this property setter we can now to A = B
                    CBRNSensorAP2CeState.ChangeParent(value.ParentAttribute, value.Data, attributeHandle, newValue);
                }

                // Write attribute...
                this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, newValue, DateTime.Now, 0, AttributeQuality.Good);
            }
        }

        #endregion

    }
}
