using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRN.Generated
{
    public class CBRNSensorLCDState
    {
        #region Types
        public enum Fields
        {
            Unknown,
            GAlert,
            HAlert,
            TICAlert,
            TICMode,
            LowSieve,
            ChangeSievePack,
            LowBattery,
            ChangeBattery,
            GHighDoseAlert,
            GMediumDoseAlert,
            HHighDoseAlert,
            InitialSelfTest,
            CoronaBurnOff,
            PTOutOfRange,
            AudioFault,
            FatalError,
            CRAboveLimit,
            FanCAboveLimit,
            InitialSelfTestFailure,
            HealthCheckFailure,
            CodeChecksumError,
            EEPROMChecksumError,
            HTOutSideLimits,
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
        public CBRNSensorLCDState(string parentAttribute, INETWISEStringCache cache, AttributeGroup data)
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

        public CBRNSensorLCDState(AttributeHandle parentAttribute, INETWISEStringCache cache, AttributeGroup data)
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

                        _nameIdIndex[hAttribute].Add(strAttributeName + ".GAlert", Fields.GAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".HAlert", Fields.HAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".TICAlert", Fields.TICAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".TICMode", Fields.TICMode);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".LowSieve", Fields.LowSieve);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".ChangeSievePack", Fields.ChangeSievePack);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".LowBattery", Fields.LowBattery);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".ChangeBattery", Fields.ChangeBattery);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".GHighDoseAlert", Fields.GHighDoseAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".GMediumDoseAlert", Fields.GMediumDoseAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".HHighDoseAlert", Fields.HHighDoseAlert);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".InitialSelfTest", Fields.InitialSelfTest);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".CoronaBurnOff", Fields.CoronaBurnOff);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".PTOutOfRange", Fields.PTOutOfRange);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".AudioFault", Fields.AudioFault);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".FatalError", Fields.FatalError);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".CRAboveLimit", Fields.CRAboveLimit);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".FanCAboveLimit", Fields.FanCAboveLimit);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".InitialSelfTestFailure", Fields.InitialSelfTestFailure);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".HealthCheckFailure", Fields.HealthCheckFailure);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".CodeChecksumError", Fields.CodeChecksumError);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".EEPROMChecksumError", Fields.EEPROMChecksumError);
                        _nameIdIndex[hAttribute].Add(strAttributeName + ".HTOutSideLimits", Fields.HTOutSideLimits);
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

        public byte GAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.GAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.GAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte HAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.HAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.HAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte TICAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.TICAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.TICAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte TICMode
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.TICMode, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.TICMode, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte LowSieve
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.LowSieve, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.LowSieve, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte ChangeSievePack
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.ChangeSievePack, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.ChangeSievePack, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte LowBattery
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.LowBattery, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.LowBattery, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte ChangeBattery
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.ChangeBattery, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.ChangeBattery, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte GHighDoseAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.GHighDoseAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.GHighDoseAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte GMediumDoseAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.GMediumDoseAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.GMediumDoseAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte HHighDoseAlert
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.HHighDoseAlert, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.HHighDoseAlert, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte InitialSelfTest
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.InitialSelfTest, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.InitialSelfTest, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte CoronaBurnOff
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.CoronaBurnOff, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.CoronaBurnOff, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte PTOutOfRange
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.PTOutOfRange, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.PTOutOfRange, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte AudioFault
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.AudioFault, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.AudioFault, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte FatalError
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.FatalError, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.FatalError, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte CRAboveLimit
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.CRAboveLimit, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.CRAboveLimit, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte FanCAboveLimit
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.FanCAboveLimit, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.FanCAboveLimit, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte InitialSelfTestFailure
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.InitialSelfTestFailure, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.InitialSelfTestFailure, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte HealthCheckFailure
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.HealthCheckFailure, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.HealthCheckFailure, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte CodeChecksumError
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.CodeChecksumError, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.CodeChecksumError, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte EEPROMChecksumError
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.EEPROMChecksumError, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.EEPROMChecksumError, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
                }
            }
        }

        public byte HTOutSideLimits
        {
            get
            {
                AttributeHandle hAttribute = GetFieldHandle(Fields.HTOutSideLimits, this.ParentAttribute);

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
                AttributeHandle hAttribute = GetFieldHandle(Fields.HTOutSideLimits, this.ParentAttribute);

                lock (this.Data)
                {
                    this.Data.Bytes[hAttribute] = value;
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
