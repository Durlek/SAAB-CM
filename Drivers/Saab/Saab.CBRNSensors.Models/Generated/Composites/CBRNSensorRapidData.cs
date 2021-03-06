using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public class CBRNSensorRapidData
    {
        #region Types
        public enum Fields
        {
            Unknown,
            Substance,
            Concentration,
            incbottom,
            inctop,
            azibottom,
            azitop,
            SubstanceClass,
            Trend,
            DetectionTime,
        }
        #endregion

        #region Static members
        protected static Dictionary<AttributeHandle, BiDirectionalIndex<string, Fields>> _nameIdIndex = 
                            new Dictionary<AttributeHandle, BiDirectionalIndex<string, Fields>>();
        protected static Dictionary<AttributeHandle, BiDirectionalIndex<Fields, AttributeHandle>> _idHandleIndex = 
                            new Dictionary<AttributeHandle, BiDirectionalIndex<Fields, AttributeHandle>>();
        #endregion

        #region Private members
        private AttributeGroup _data = null;
        #endregion

        #region Constructors
        public CBRNSensorRapidData(string parentAttribute, INETWISEStringCache cache, AttributeGroup data)
        {
            if (string.IsNullOrEmpty(parentAttribute))
            {
                throw new WISEInvalidArgumentException(
                    "Invalid argument 'parentAttribute'. Attribute name cannot be null or empty.");
            }
            if (cache == null)
            {
                throw new NullReferenceException("Invalid argument 'cache'. Interface reference cannot be null.");
            }

            uint attribHandle = WISEConstants.WISE_INVALID_HANDLE;
            cache.AddString(parentAttribute, ref attribHandle);
            this.ParentAttribute = new AttributeHandle(attribHandle);
            this.Data = data;
            this.StringCache = cache;

            Initialize(this.StringCache, this.ParentAttribute);
        }

        public CBRNSensorRapidData(AttributeHandle parentAttribute, INETWISEStringCache cache, AttributeGroup data)
        {
            if (parentAttribute == WISEConstants.WISE_INVALID_HANDLE)
            {
                throw new WISEInvalidArgumentException(
                    "Invalid argument 'parentAttribute'. Attribute handle cannot be WISE_INVALID_HANDLE.");
            }
            if (cache == null)
            {
                throw new NullReferenceException("Invalid argument 'cache'. Interface reference cannot be null.");
            }

            this.ParentAttribute = parentAttribute;
            this.Data = data;
            this.StringCache = cache;

            Initialize(this.StringCache, this.ParentAttribute);
        }
        #endregion

        #region Initialization
        static public WISE_RESULT Initialize(INETWISEStringCache cache, string groupName)
        {
            if (cache == null)
            {
                return CreateErrorCode(WISEError.WISE_NOT_INITIATED);
            }

            uint hAttribute = WISEConstants.WISE_INVALID_HANDLE;
            cache.AddString(groupName, ref hAttribute);

            return Initialize(cache, new AttributeHandle(hAttribute));
        }

        static public WISE_RESULT Initialize(INETWISEStringCache cache, AttributeHandle hAttribute)
        {
            if (cache == null)
            {
                return CreateErrorCode(WISEError.WISE_NOT_INITIATED);
            }

            if (!IsInitialized(hAttribute))
            {
                string strAttributeName = "";

                cache.StringFromId(hAttribute.Value, ref strAttributeName);

                lock (_nameIdIndex)
                {
                    if (!_nameIdIndex.ContainsKey(hAttribute))
                    {
                        _nameIdIndex.Add(hAttribute, new BiDirectionalIndex<string, Fields>());

                        _nameIdIndex[hAttribute].Add(strAttributeName + ".Substance", Fields.Substance);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".Concentration", Fields.Concentration);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".incbottom", Fields.incbottom);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".inctop", Fields.inctop);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".azibottom", Fields.azibottom);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".azitop", Fields.azitop);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".SubstanceClass", Fields.SubstanceClass);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".Trend", Fields.Trend);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".DetectionTime", Fields.DetectionTime);
                    }

                    lock (_idHandleIndex)
                    {
                        if (_nameIdIndex.ContainsKey(hAttribute) && !_idHandleIndex.ContainsKey(hAttribute))
                        {
                            _idHandleIndex.Add(hAttribute, new BiDirectionalIndex<Fields, AttributeHandle>());

                            foreach (KeyValuePair<string, Fields> item in _nameIdIndex[hAttribute].FirstToSecond)
                            {
                                uint fieldId = 0;
                                cache.AddString(item.Key, ref fieldId);
                                _idHandleIndex[hAttribute].Add(item.Value, new AttributeHandle(fieldId));
                            }
                        }
                    }
                }
            }
            return WISEError.WISE_OK;
        }

        static public bool IsInitialized(AttributeHandle hAttribute)
        {
            lock(_idHandleIndex)
            {
                return (_idHandleIndex.ContainsKey(hAttribute));
            }
        }
        #endregion

        #region Generic group properties
        public AttributeHandle ParentAttribute { get; private set; }
        
        public AttributeGroup Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new AttributeGroup();

                    // TODO: Initialize group fields with default values
                }
                return _data;
            }
            set { _data = value; }
        }

        protected INETWISEStringCache StringCache;
        #endregion

        #region Field properties

        public string SubstanceValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Substance, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Strings.ContainsKey(hAttribute))
                    {
                        return this.Data.Strings[hAttribute];
                    }
                }
                return string.Empty;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Substance, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Strings[hAttribute] = value;
                }
            }
        }

        public double ConcentrationValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Concentration, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Doubles.ContainsKey(hAttribute))
                    {
                        return this.Data.Doubles[hAttribute];
                    }
                }
                return 0.0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Concentration, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Doubles[hAttribute] = value;
                }
            }
        }

        public double incbottomValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.incbottom, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Doubles.ContainsKey(hAttribute))
                    {
                        return this.Data.Doubles[hAttribute];
                    }
                }
                return 0.0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.incbottom, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Doubles[hAttribute] = value;
                }
            }
        }

        public double inctopValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.inctop, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Doubles.ContainsKey(hAttribute))
                    {
                        return this.Data.Doubles[hAttribute];
                    }
                }
                return 0.0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.inctop, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Doubles[hAttribute] = value;
                }
            }
        }

        public double azibottomValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.azibottom, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Doubles.ContainsKey(hAttribute))
                    {
                        return this.Data.Doubles[hAttribute];
                    }
                }
                return 0.0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.azibottom, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Doubles[hAttribute] = value;
                }
            }
        }

        public double azitopValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.azitop, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Doubles.ContainsKey(hAttribute))
                    {
                        return this.Data.Doubles[hAttribute];
                    }
                }
                return 0.0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.azitop, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Doubles[hAttribute] = value;
                }
            }
        }

        public byte SubstanceClassValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.SubstanceClass, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Bytes.ContainsKey(hAttribute))
                    {
                        return this.Data.Bytes[hAttribute];
                    }
                }
                return 0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.SubstanceClass, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte TrendValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Trend, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Bytes.ContainsKey(hAttribute))
                    {
                        return this.Data.Bytes[hAttribute];
                    }
                }
                return 0;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.Trend, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public string DetectionTimeValue
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.DetectionTime, this.ParentAttribute);

                lock (this.Data)
                {
                    if (this.Data.Strings.ContainsKey(hAttribute))
                    {
                        return this.Data.Strings[hAttribute];
                    }
                }
                return string.Empty;
            }
            set
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.DetectionTime, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Strings[hAttribute] = value;
                }
            }
        }

        #endregion

        #region Field helper methods

        public static AttributeHandle GetFieldHandle(Fields field, AttributeHandle parentAttribute)
        {
            AttributeHandle hAttribute = WISEConstants.WISE_INVALID_HANDLE;
            lock (_idHandleIndex)
            {
                hAttribute = _idHandleIndex[parentAttribute].GetByFirst(field);
            }
            return hAttribute;
        }

        public static Fields GetFieldId(AttributeHandle field, AttributeHandle parentAttribute)
        {
            Fields fieldId = Fields.Unknown;
            lock (_idHandleIndex)
            {
                fieldId = _idHandleIndex[parentAttribute].GetBySecond(field);
            }
            return fieldId;
        }

        public static Fields GetFieldId(string fieldName, AttributeHandle parentAttribute)
        {
            Fields fieldId = Fields.Unknown;
            lock (_idHandleIndex)
            {
                fieldId = _nameIdIndex[parentAttribute].GetByFirst(fieldName);
            }
            return fieldId;
        }

        public static string GetFieldName(Fields field, AttributeHandle parentAttribute)
        {
            string fieldName = "";

            lock (_nameIdIndex)
            {
                fieldName = _nameIdIndex[parentAttribute].GetBySecond(field);
            }
            return fieldName;
        }

        public static void ChangeParent(AttributeHandle sourceParent, AttributeGroup source,
                AttributeHandle destinationParent, AttributeGroup target)
        {
            ChangeParentHelper(sourceParent, source.Bytes, destinationParent, target.Bytes);
            ChangeParentHelper(sourceParent, source.Ints, destinationParent, target.Ints);
            ChangeParentHelper(sourceParent, source.Longs, destinationParent, target.Longs);
            ChangeParentHelper(sourceParent, source.Doubles, destinationParent, target.Doubles);
            ChangeParentHelper(sourceParent, source.Strings, destinationParent, target.Strings);
            ChangeParentHelper(sourceParent, source.Handles, destinationParent, target.Handles);
            ChangeParentHelper(sourceParent, source.Vec3s, destinationParent, target.Vec3s);
            ChangeParentHelper(sourceParent, source.Blobs, destinationParent, target.Blobs);
            ChangeParentHelper(sourceParent, source.ByteLists, destinationParent, target.ByteLists);
            ChangeParentHelper(sourceParent, source.IntLists, destinationParent, target.IntLists);
            ChangeParentHelper(sourceParent, source.LongLists, destinationParent, target.LongLists);
            ChangeParentHelper(sourceParent, source.DoubleLists, destinationParent, target.DoubleLists);
            ChangeParentHelper(sourceParent, source.StringLists, destinationParent, target.StringLists);
            ChangeParentHelper(sourceParent, source.HandleLists, destinationParent, target.HandleLists);
            ChangeParentHelper(sourceParent, source.Vec3Lists, destinationParent, target.Vec3Lists);
            ChangeParentHelper(sourceParent, source.GroupLists, destinationParent, target.GroupLists);
        }

        #endregion

        #region Private helper methods

        private static AttributeHandle ConvertFieldHandle(AttributeHandle sourceHandle, AttributeHandle sourceParent, AttributeHandle destinationParent)
        {
            lock (_idHandleIndex)
            {
                Fields fieldId = _idHandleIndex[sourceParent].GetBySecond(sourceHandle);
                return GetFieldHandle(fieldId, destinationParent);
            }
        }

        private static void ChangeParentHelper<T>(AttributeHandle sourceParent, Dictionary<AttributeHandle, T> source,
            AttributeHandle destinationParent, Dictionary<AttributeHandle, T> target)
        {
            foreach (KeyValuePair<AttributeHandle, T> keyValuePair in source)
            {
                AttributeHandle newHandle = ConvertFieldHandle(keyValuePair.Key, sourceParent, destinationParent);
                target[newHandle] = keyValuePair.Value;
            }
        }

        private static WISE_RESULT CreateErrorCode(UInt32 error)
        {
            return WISEError.CreateResultCode(WISEErrorSeverity.Error,
                                              WISEError.WISE_FACILITY_COM_ADAPTER,
                                              error);
        }
        #endregion
    }
}
