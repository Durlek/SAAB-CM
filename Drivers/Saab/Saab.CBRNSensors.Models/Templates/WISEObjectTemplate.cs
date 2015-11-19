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
        /// Enumeration of attributes in <#EntityClassMerged#> objects.
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

        #region Class Properties

        static public string ClassName
        {
            get { return "<#EntityClass#>"; }
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

        public <#FileName#>EntityTypes ClassEntityType
        {
            get { return <#FileName#>EntityTypes.<#EntityClassMerged#>; }
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

        public <#EntityClassMerged#>()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Object = WISEConstants.WISE_INVALID_HANDLE;
            this.Transaction = TransactionHandle.None;            
        }

        public <#EntityClassMerged#>(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = TransactionHandle.None;
        }

        public <#EntityClassMerged#>(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle, TransactionHandle transactionHandle)
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
            return (className == <#EntityClassMerged#>.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == <#EntityClassMerged#>.Class);
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
                result = WISE.CreateObjectFromTemplate(hDatabase, objectName, <#EntityClassMerged#>.ClassName, ref objectHandle, ref attributes);
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
///#### BEGIN FOREACH_ATTRIBUTE
///#### BEGIN CONDITION AttributeWISEType = AttributeGroup
// OBJECTIMPL: AttributeGroup
        public <#AttributeDataType#> <#AttributeName#>   
        {
            get
            {
                AttributeGroup value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.<#AttributeName#>);
                }

                if (this.WISE != null)
                {   
                    this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);
                }
                return new <#AttributeDataType#>(attributeHandle, this.StringCache, value);
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.<#AttributeName#>);
                AttributeGroup newValue = new AttributeGroup();
                
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(
                        "Attribute '{0}' cannot be set to null.",
                        GetAttributeNameFromId(Attributes.<#AttributeName#>)));
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
                    <#AttributeDataType#>.ChangeParent(value.ParentAttribute, value.Data, attributeHandle, newValue);
                }

                // Write attribute...
                this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, newValue, DateTime.Now, 0, AttributeQuality.Good);
            }
        }
///#### END CONDITION AttributeWISEType = AttributeGroup
///#### BEGIN CONDITION AttributeWISEType = Blob
// OBJECTIMPL: Blob
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Blob
///#### BEGIN CONDITION AttributeWISEType = Byte
// OBJECTIMPL: Byte
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Byte
///#### BEGIN CONDITION AttributeWISEType = Float
// OBJECTIMPL: Float
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Float
///#### BEGIN CONDITION AttributeWISEType = Long
// OBJECTIMPL: Long
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Long
///#### BEGIN CONDITION AttributeWISEType = LongLong
// OBJECTIMPL: LongLong
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = LongLong
///#### BEGIN CONDITION AttributeWISEType = Handle
// OBJECTIMPL: Handle
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Handle
///#### BEGIN CONDITION AttributeWISEType = String
// OBJECTIMPL: String
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = String
///#### BEGIN CONDITION AttributeWISEType = Vec3
// OBJECTIMPL: Vec3
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Vec3
///#### BEGIN CONDITION AttributeWISEType = ByteList
// OBJECTIMPL: ByteList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = ByteList
///#### BEGIN CONDITION AttributeWISEType = FloatList
// OBJECTIMPL: FloatList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = FloatList
///#### BEGIN CONDITION AttributeWISEType = AttributeGroupList
// OBJECTIMPL: AttributeGroupList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = AttributeGroupList
///#### BEGIN CONDITION AttributeWISEType = LongList
// OBJECTIMPL: LongList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = LongList
///#### BEGIN CONDITION AttributeWISEType = HandleList
// OBJECTIMPL: HandleList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = HandleList
///#### BEGIN CONDITION AttributeWISEType = StringList
// OBJECTIMPL: StringList
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = StringList
///#### BEGIN CONDITION AttributeWISEType = Vec3List
// OBJECTIMPL: Vec3List
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
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

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
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
///#### END CONDITION AttributeWISEType = Vec3List
///#### END FOREACH_ATTRIBUTE

        #endregion

    }
}
