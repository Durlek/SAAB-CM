using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace <#CompanyName#>.<#FileName#>.Models
{
    public partial class <#EntityClassMerged#>
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in <#EntityClassMerged#> events.
        /// </summary>
        public enum Attributes
        {
            Unknown,
///#### BEGIN FOREACH_ATTRIBUTE
            <#AttributeName#>,
///#### END FOREACH_ATTRIBUTE
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, <#EntityClassMerged#>.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<<#EntityClassMerged#>.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();
        protected static ClassHandle _classHandle = WISEConstants.WISE_INVALID_HANDLE;

        #endregion

        #region Members

///#### BEGIN FOREACH_ATTRIBUTE
///#### BEGIN CONDITION AttributeWISEType = AttributeGroup
        private <#AttributeDataType#> _<#AttributeName#>;
///#### END CONDITION AttributeWISEType = AttributeGroup
///#### END FOREACH_ATTRIBUTE

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "<#EntityClass#>"; }
        }

        static public ClassHandle Class
        {
            get { return _classHandle; }
        }

        public INETWISEDriverSink2 WISE { get; private set; }

        public INETWISEStringCache StringCache
        {
            get { return (this.WISE as INETWISEStringCache); }
        }

        public DatabaseHandle Database { get; private set; }

        public EventHandle Handle { get; private set; }

        #endregion

        #region Constructors

        public <#EntityClassMerged#>()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public <#EntityClassMerged#>(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, EventHandle eventHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Handle = eventHandle;
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
///#### BEGIN FOREACH_ATTRIBUTE
                    _nameIdIndex.Add("<#AttributeName#>", Attributes.<#AttributeName#>);
///#### END FOREACH_ATTRIBUTE

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
					_idHandleIndex.Clear();
					_nameIdIndex.Clear();
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

        static public bool IsTypeOf(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, EventHandle hEvent)
        {
            uint result = WISEError.WISE_ERROR;
            AttributeHandle hAttr = WISEConstants.WISE_INVALID_HANDLE;
            string strEntityType = string.Empty;

            if ((WISE == null) || (hEvent == WISEConstants.WISE_INVALID_HANDLE))
            {
                return false;
            }

            result = WISE.GetEventAttributeHandle(hDatabase, hEvent, WISEConstants.WISE_TEMPLATE_EVENT_TYPE, ref hAttr);
            if (WISEError.CheckCallFailed(result))
            {
                return false;
            }

            result = WISE.GetEventAttributeValue(hDatabase, hEvent, hAttr, ref strEntityType);
            return WISEError.CheckCallSucceeded(result) && IsTypeOf(strEntityType);
        }

        static public bool IsTypeOf(string className)
        {
            return (className == <#EntityClassMerged#>.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == <#EntityClassMerged#>.Class);
        }

        #endregion

        #region Event creation methods

        public uint CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase)
        {
            uint result = WISEError.WISE_ERROR;
            EventHandle eventHandle = this.Handle;

            if (WISE == null)
            {
                result = WISEError.WISE_E_INVALID_ARG;
                return result;
            }

            if (eventHandle == WISEConstants.WISE_INVALID_HANDLE)
            {
                // Create event from template, if none exist.
                Dictionary<string, AttributeHandle> attributes = new Dictionary<string, AttributeHandle>();
                result = WISE.CreateEventFromTemplate(hDatabase, <#EntityClassMerged#>.ClassName, ref eventHandle, ref attributes);
            }

            if (WISEError.CheckCallSucceeded(result))
            {
                this.WISE = WISE;
                this.Database = WISEConstants.WISE_INVALID_HANDLE;
                this.Handle = eventHandle;
            }

            return result;
        }

        public uint SendEventToDatabase(DatabaseHandle databaseHandle)
        {
            uint result = WISEError.WISE_ERROR;

            if (this.WISE == null)
            {
                result = WISEError.WISE_E_INVALID_ARG;
                return result;
            }

///#### BEGIN FOREACH_ATTRIBUTE
///#### BEGIN CONDITION AttributeWISEType = AttributeGroup
            if (_<#AttributeName#> != null)
            {
                result = WISE.SetEventAttributeValue(WISEConstants.WISE_TRANSITION_CACHE_DATABASE,
                            this.Handle, _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>),
                            _<#AttributeName#>.Data, 0);
            }

///#### END CONDITION AttributeWISEType = AttributeGroup
///#### END FOREACH_ATTRIBUTE
            result = this.WISE.SendEvent(databaseHandle, this.Handle);

            if (WISEError.CheckCallSucceeded(result))
            {
                this.Database = databaseHandle;                
            }
            return result;
        }

        #endregion

        #region Attribute value properties
///#### BEGIN FOREACH_ATTRIBUTE

///#### BEGIN CONDITION AttributeWISEType = AttributeGroup
// EVENTIMPL: AttributeGroup
        public <#AttributeDataType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                AttributeGroup value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        _<#AttributeName#> = new <#AttributeDataType#>(attributeHandle, this.StringCache, value);
                    }
                }
                return _<#AttributeName#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(
                        "Attribute '{0}' cannot be set to null.",
                        GetAttributeNameFromId(Attributes.<#AttributeName#>)));
                }

                if (_<#AttributeName#> == null)
                {
                    _<#AttributeName#> = new <#AttributeDataType#>(attributeHandle, this.StringCache, null);
                }

                if (_<#AttributeName#>.Data != null)
                {
                    if (value.ParentAttribute == attributeHandle)
                    {
                        _<#AttributeName#>.Data.Merge(value.Data);
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
                        <#AttributeDataType#>.ChangeParent(value.ParentAttribute, value.Data, attributeHandle, <#AttributeName#>.Data);
                    }

                    // Attribute is written on Send...
                }
            }
        }
///#### END CONDITION AttributeWISEType = AttributeGroup
///#### BEGIN CONDITION AttributeWISEType = Blob
// EVENTIMPL: Blob
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }        
///#### END CONDITION AttributeWISEType = Blob
///#### BEGIN CONDITION AttributeWISEType = Byte
// EVENTIMPL: Byte
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Byte
///#### BEGIN CONDITION AttributeWISEType = Float
// EVENTIMPL: Float
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Float
///#### BEGIN CONDITION AttributeWISEType = Long
// EVENTIMPL: Long
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Long
///#### BEGIN CONDITION AttributeWISEType = LongLong
// EVENTIMPL: LongLong
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = LongLong
///#### BEGIN CONDITION AttributeWISEType = Handle
// EVENTIMPL: Handle
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Handle
///#### BEGIN CONDITION AttributeWISEType = String
// EVENTIMPL: String
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = String
///#### BEGIN CONDITION AttributeWISEType = Vec3
// EVENTIMPL: Vec3
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = <#AttributeNullValue#>;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Vec3
///#### BEGIN CONDITION AttributeWISEType = AttributeGroupList
// EVENTIMPL: AttributeGroupList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = AttributeGroupList
///#### BEGIN CONDITION AttributeWISEType = ByteList
// EVENTIMPL: ByteList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = ByteList
///#### BEGIN CONDITION AttributeWISEType = FloatList
// EVENTIMPL: FloatList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = FloatList
///#### BEGIN CONDITION AttributeWISEType = HandleList
// EVENTIMPL: HandleList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = HandleList
///#### BEGIN CONDITION AttributeWISEType = LongList
// EVENTIMPL: LongList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = LongList
///#### BEGIN CONDITION AttributeWISEType = StringList
// EVENTIMPL: StringList
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = StringList
///#### BEGIN CONDITION AttributeWISEType = Vec3List
// EVENTIMPL: Vec3List
        public <#AttributeCSType#> <#AttributeName#>
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                <#AttributeCSType#> value = new <#AttributeCSType#>();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return <#AttributeNullValue#>;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                
///#### END CONDITION AttributeWISEType = Vec3List
///#### END FOREACH_ATTRIBUTE

        #endregion

    }
}
