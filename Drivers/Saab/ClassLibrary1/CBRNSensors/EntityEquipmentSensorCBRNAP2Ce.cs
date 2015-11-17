using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRN.Generated
{
    public class EntityEquipmentSensorCBRNAP2Ce
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

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "EntityEquipment.Sensor.CBRN.AP2Ce"; }
        }

        public string ObjectName
        {
            get
            {
                string objectName = "";

                // Initialize handle cache
                Initialize(this.StringCache);

                if (this.Handle != WISEConstants.WISE_INVALID_HANDLE)
                {
                    this.WISESink.GetObjectName(this.Database, this.Handle, ref objectName);
                }
                return objectName;
            }
        }

        public INETWISEDriverSink WISESink { get; private set; }

        public INETWISEStringCache StringCache
        {
            get { return (this.WISESink as INETWISEStringCache); }
        }

        public DatabaseHandle Database { get; private set; }

        public ObjectHandle Handle { get; private set; }

        #endregion

        #region Constructors

        public EntityEquipmentSensorCBRNAP2Ce()
        {
            this.WISESink = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public EntityEquipmentSensorCBRNAP2Ce(INETWISEDriverSink sink, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
        {
            this.WISESink = sink;
            this.Database = databaseHandle;
            this.Handle = objectHandle;
        }

        #endregion

        #region Initialization methods

        static public WISE_RESULT CreateErrorCode(UInt32 wiseError)
        {
            return WISEError.CreateResultCode(WISEErrorSeverity.Error,
                                              WISEError.WISE_FACILITY_COM_ADAPTER,
                                              wiseError);
        }

        static public WISE_RESULT Initialize(INETWISEStringCache cache)
        {
            if (cache == null)
            {
                return CreateErrorCode(WISEError.WISE_W_NOT_INITIATED);
            }

            if (!IsInitialized())
            {
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
            return WISEError.WISE_OK;
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
            this.WISESink = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
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

        static public bool IsTypeOf(INETWISEDriverSink sink, DatabaseHandle hDatabase, ObjectHandle hObject)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;
            AttributeHandle hAttr = WISEConstants.WISE_INVALID_HANDLE;
            string strEntityType = string.Empty;

            if ((sink == null) || (hObject == WISEConstants.WISE_INVALID_HANDLE))
            {
                return false;
            }

            // Initialize handle cache
            Initialize(sink as INETWISEStringCache);

            wResult = sink.GetAttributeHandle(hDatabase, hObject, WISEConstants.WISE_TEMPLATE_OBJECT_TYPE, ref hAttr,
                                                   DataType.String);
            bool bResult = WISEError.CheckCallFailed(wResult);

            wResult = sink.GetAttributeValue(hDatabase, hObject, hAttr, ref strEntityType);
            bResult = WISEError.CheckCallSucceeded(wResult);

            return bResult && IsTypeOf(strEntityType);
        }

        static public bool IsTypeOf(string className)
        {
            return (className == EntityEquipmentSensorCBRNAP2Ce.ClassName);
        }

        #endregion

        #region Object creation methods

        public WISE_RESULT CreateInstance(INETWISEDriverSink sink, DatabaseHandle hDatabase)
        {
            return CreateInstance(sink, hDatabase, "");
        }

        public WISE_RESULT CreateInstance(INETWISEDriverSink sink, DatabaseHandle hDatabase, string objectName)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;
            ObjectHandle objectHandle = this.Handle;

            if (sink == null)
            {
                return CreateErrorCode(WISEError.WISE_INVALID_ARG);
            }

            // Initialize handle cache
            Initialize(sink as INETWISEStringCache);

            if (objectHandle == WISEConstants.WISE_INVALID_HANDLE)
            {
                // Create object from template, if none exist.
                Dictionary<string, AttributeHandle> attributes = null; // it's set from Template
                wResult = sink.CreateObjectFromTemplate(hDatabase, objectName, EntityEquipmentSensorCBRNAP2Ce.ClassName, ref objectHandle, ref attributes);
            }

            if (WISEError.CheckCallSucceeded(wResult))
            {
                this.WISESink = sink;
                this.Database = WISEConstants.WISE_INVALID_HANDLE;
                this.Handle = objectHandle;
            }
            return wResult;
        }

        public WISE_RESULT AddToDatabase(DatabaseHandle databaseHandle)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;

            if (this.WISESink == null)
            {
                return CreateErrorCode(WISEError.WISE_NOT_INITIATED);
            }

            wResult = this.WISESink.AddObjectToDatabase(databaseHandle, this.Handle);

            if (WISEError.CheckCallSucceeded(wResult))
            {
                this.Database = databaseHandle;
            }
            return wResult;
        }

        #endregion

        #region Attribute value properties

        public string Description
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Description);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Description);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string EquipmentType
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EquipmentType);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EquipmentType);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string ExternalId
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ExternalId);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ExternalId);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string Name
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Name);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Name);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Parent
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Parent);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return WISEConstants.WISE_INVALID_HANDLE;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Parent);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.Vec3 RelativeLocation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RelativeLocation);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return Vec3.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RelativeLocation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.GroupList SensorData
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.GroupList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorData);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return null;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorData);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.GroupList SensorRawData
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.GroupList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorRawData);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return null;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorRawData);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

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

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.GetAttributeValue(this.Database, this.Handle, attributeHandle, ref value);
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

                // Initialize handle cache
                CBRNSensorAP2CeState.Initialize(this.StringCache, attributeHandle);

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
                this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, newValue, DateTime.Now, 0);
            }
        }

        #endregion

    }
}
