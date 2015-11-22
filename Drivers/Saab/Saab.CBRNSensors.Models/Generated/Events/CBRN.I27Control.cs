using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public partial class CBRNI27Control
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in CBRNI27Control events.
        /// </summary>
        public enum Attributes
        {
            Unknown,
            Command,
            ExternalId,
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, CBRNI27Control.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<CBRNI27Control.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();
        protected static ClassHandle _classHandle = WISEConstants.WISE_INVALID_HANDLE;

        #endregion

        #region Members


        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "CBRN.I27Control"; }
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

        public CBRNI27Control()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public CBRNI27Control(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, EventHandle eventHandle)
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
            return (className == CBRNI27Control.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == CBRNI27Control.Class);
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
                result = WISE.CreateEventFromTemplate(hDatabase, CBRNI27Control.ClassName, ref eventHandle, ref attributes);
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

            result = this.WISE.SendEvent(databaseHandle, this.Handle);

            if (WISEError.CheckCallSucceeded(result))
            {
                this.Database = databaseHandle;                
            }
            return result;
        }

        #endregion

        #region Attribute value properties

// EVENTIMPL: String
        public string Command
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Command);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return string.Empty;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Command);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                

// EVENTIMPL: Handle
        public STS.WISE.ObjectHandle ExternalId
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ExternalId);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetEventAttributeValue(this.Database, this.Handle, attributeHandle, ref value);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return WISEConstants.WISE_INVALID_HANDLE;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ExternalId);
                
                if (this.WISE != null)
                {
                    this.WISE.SetEventAttributeValue(this.Database, this.Handle, attributeHandle, value, 0);
                }
            }
        }                

        #endregion

    }
}
