using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace CBRNSensors
{
    public class CBRNLCDControl
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in CBRNLCDControl events.
        /// </summary>
        public enum Attributes
        {
            Unknown,
            Command,
            ExternalId,
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, CBRNLCDControl.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<CBRNLCDControl.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();

        #endregion

        #region Members


        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "CBRN.LCDControl"; }
        }

        public INETWISEDriverSink WISESink { get; private set; }

        public INETWISEStringCache StringCache
        {
            get { return (this.WISESink as INETWISEStringCache); }
        }

        public DatabaseHandle Database { get; private set; }

        public EventHandle Handle { get; private set; }

        #endregion

        #region Constructors

        public CBRNLCDControl()
        {
            this.WISESink = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public CBRNLCDControl(INETWISEDriverSink sink, DatabaseHandle databaseHandle, EventHandle eventHandle)
        {
            this.WISESink = sink;
            this.Database = databaseHandle;
            this.Handle = eventHandle;
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
                    _nameIdIndex.Add("Command", Attributes.Command);
                    _nameIdIndex.Add("ExternalId", Attributes.ExternalId);

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

        static public bool IsTypeOf(INETWISEDriverSink sink, DatabaseHandle hDatabase, EventHandle hEvent)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;
            AttributeHandle hAttr = WISEConstants.WISE_INVALID_HANDLE;
            string strEntityType = string.Empty;

            if ((sink == null) || (hEvent == WISEConstants.WISE_INVALID_HANDLE))
            {
                return false;
            }

            // Initialize handle cache
            Initialize(sink as INETWISEStringCache);

            wResult = sink.GetEventAttributeHandle(hDatabase, hEvent, WISEConstants.WISE_TEMPLATE_EVENT_TYPE, ref hAttr,
                                                   DataType.String);
            bool bResult = WISEError.CheckCallFailed(wResult);

            wResult = sink.GetEventAttributeValue(hDatabase, hEvent, hAttr, ref strEntityType);
            bResult = WISEError.CheckCallSucceeded(wResult);

            return bResult && IsTypeOf(strEntityType);
        }

        static public bool IsTypeOf(string className)
        {
            return (className == CBRNLCDControl.ClassName);
        }

        #endregion

        #region Event creation methods

        public WISE_RESULT CreateInstance(INETWISEDriverSink sink, DatabaseHandle hDatabase)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;
            EventHandle eventHandle = this.Handle;

            if (sink == null)
            {
                return CreateErrorCode(WISEError.WISE_INVALID_ARG);
            }

            // Initialize handle cache
            Initialize(sink as INETWISEStringCache);

            if (eventHandle == WISEConstants.WISE_INVALID_HANDLE)
            {
                // Create event from template, if none exist.
                Dictionary<string, AttributeHandle> attributes = null; // it's set from Template
                wResult = sink.CreateEventFromTemplate(hDatabase, CBRNLCDControl.ClassName, ref eventHandle, ref attributes);
            }

            if (WISEError.CheckCallSucceeded(wResult))
            {
                this.WISESink = sink;
                this.Database = WISEConstants.WISE_INVALID_HANDLE;
                this.Handle = eventHandle;
            }
            return wResult;
        }

        public WISE_RESULT SendEventToDatabase(DatabaseHandle databaseHandle)
        {
            WISE_RESULT wResult = WISEError.WISE_OK;

            if (this.WISESink == null)
            {
                return CreateErrorCode(WISEError.WISE_NOT_INITIATED);
            }

            wResult = this.WISESink.SendEvent(databaseHandle, this.Handle);

            if (WISEError.CheckCallSucceeded(wResult))
            {
                this.Database = databaseHandle;
                this.Handle = WISEConstants.WISE_INVALID_HANDLE;
            }
            return wResult;
        }

        #endregion

        #region Attribute value properties

        public int Command
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Command);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Command);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }

        public long ExternalId
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                long value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ExternalId);
                }

                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    wResult = this.WISESink.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(wResult))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ExternalId);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }

        #endregion

    }
}
