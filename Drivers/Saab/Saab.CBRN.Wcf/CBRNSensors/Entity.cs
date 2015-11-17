using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace CBRNSensors
{
    public class Entity
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in Entity objects.
        /// </summary>
        public enum Attributes
        {
            Unknown,
            CurrentGroundSpeed,
            EntityType,
            FixedTurnRadius,
            Formation,
            FormationMaster,
            FormationPosition,
            GroundSpeed,
            Health,
            HorizontalAcceleration,
            HorizontalSpeed,
            IsOnGround,
            Length,
            MaxAcceleration,
            MaxDeceleration,
            MaxHorizontalSpeed,
            MaxTurnSpeed,
            Model3D,
            Mover,
            Name,
            Orientation,
            Position,
            PresentedOrientation,
            PresentedPosition,
            PresentedVelocity,
            RadarCrossSection,
            Radius,
            SensorVisible,
            TargetHeading,
            TargetHorizontalSpeed,
            Template3DModels,
            TemplatedObject,
            TransponderCode,
            TurnDirection,
            TurnRadius,
            UpdateRate,
            UseAnticollision,
            VerticalAcceleration,
            VerticalSpeed,
            timestamp,
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, Entity.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<Entity.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "Entity"; }
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

        public Entity()
        {
            this.WISESink = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public Entity(INETWISEDriverSink sink, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
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
                    _nameIdIndex.Add("CurrentGroundSpeed", Attributes.CurrentGroundSpeed);
                    _nameIdIndex.Add("EntityType", Attributes.EntityType);
                    _nameIdIndex.Add("FixedTurnRadius", Attributes.FixedTurnRadius);
                    _nameIdIndex.Add("Formation", Attributes.Formation);
                    _nameIdIndex.Add("FormationMaster", Attributes.FormationMaster);
                    _nameIdIndex.Add("FormationPosition", Attributes.FormationPosition);
                    _nameIdIndex.Add("GroundSpeed", Attributes.GroundSpeed);
                    _nameIdIndex.Add("Health", Attributes.Health);
                    _nameIdIndex.Add("HorizontalAcceleration", Attributes.HorizontalAcceleration);
                    _nameIdIndex.Add("HorizontalSpeed", Attributes.HorizontalSpeed);
                    _nameIdIndex.Add("IsOnGround", Attributes.IsOnGround);
                    _nameIdIndex.Add("Length", Attributes.Length);
                    _nameIdIndex.Add("MaxAcceleration", Attributes.MaxAcceleration);
                    _nameIdIndex.Add("MaxDeceleration", Attributes.MaxDeceleration);
                    _nameIdIndex.Add("MaxHorizontalSpeed", Attributes.MaxHorizontalSpeed);
                    _nameIdIndex.Add("MaxTurnSpeed", Attributes.MaxTurnSpeed);
                    _nameIdIndex.Add("Model3D", Attributes.Model3D);
                    _nameIdIndex.Add("Mover", Attributes.Mover);
                    _nameIdIndex.Add("Name", Attributes.Name);
                    _nameIdIndex.Add("Orientation", Attributes.Orientation);
                    _nameIdIndex.Add("Position", Attributes.Position);
                    _nameIdIndex.Add("PresentedOrientation", Attributes.PresentedOrientation);
                    _nameIdIndex.Add("PresentedPosition", Attributes.PresentedPosition);
                    _nameIdIndex.Add("PresentedVelocity", Attributes.PresentedVelocity);
                    _nameIdIndex.Add("RadarCrossSection", Attributes.RadarCrossSection);
                    _nameIdIndex.Add("Radius", Attributes.Radius);
                    _nameIdIndex.Add("SensorVisible", Attributes.SensorVisible);
                    _nameIdIndex.Add("TargetHeading", Attributes.TargetHeading);
                    _nameIdIndex.Add("TargetHorizontalSpeed", Attributes.TargetHorizontalSpeed);
                    _nameIdIndex.Add("Template3DModels", Attributes.Template3DModels);
                    _nameIdIndex.Add("TemplatedObject", Attributes.TemplatedObject);
                    _nameIdIndex.Add("TransponderCode", Attributes.TransponderCode);
                    _nameIdIndex.Add("TurnDirection", Attributes.TurnDirection);
                    _nameIdIndex.Add("TurnRadius", Attributes.TurnRadius);
                    _nameIdIndex.Add("UpdateRate", Attributes.UpdateRate);
                    _nameIdIndex.Add("UseAnticollision", Attributes.UseAnticollision);
                    _nameIdIndex.Add("VerticalAcceleration", Attributes.VerticalAcceleration);
                    _nameIdIndex.Add("VerticalSpeed", Attributes.VerticalSpeed);
                    _nameIdIndex.Add("timestamp", Attributes.timestamp);

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
            return (className == Entity.ClassName);
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
                wResult = sink.CreateObjectFromTemplate(hDatabase, objectName, Entity.ClassName, ref objectHandle, ref attributes);
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

        public double CurrentGroundSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CurrentGroundSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CurrentGroundSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string EntityType
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityType);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double FixedTurnRadius
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FixedTurnRadius);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FixedTurnRadius);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Formation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Formation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Formation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle FormationMaster
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FormationMaster);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FormationMaster);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public int FormationPosition
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FormationPosition);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FormationPosition);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double GroundSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Health
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Health);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Health);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double HorizontalAcceleration
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HorizontalAcceleration);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HorizontalAcceleration);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double HorizontalSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HorizontalSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HorizontalSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte IsOnGround
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsOnGround);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsOnGround);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Length
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Length);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Length);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxAcceleration
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxAcceleration);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxAcceleration);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxDeceleration
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxDeceleration);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxDeceleration);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxHorizontalSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxHorizontalSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxHorizontalSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxTurnSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxTurnSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxTurnSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Model3D
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Model3D);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Model3D);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Mover
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Mover);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Mover);
                
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

        public STS.WISE.Vec3 Orientation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Orientation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Orientation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.Vec3 Position
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Position);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Position);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.Vec3 PresentedOrientation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedOrientation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedOrientation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.Vec3 PresentedPosition
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedPosition);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedPosition);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.Vec3 PresentedVelocity
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedVelocity);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedVelocity);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double RadarCrossSection
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RadarCrossSection);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RadarCrossSection);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Radius
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Radius);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Radius);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte SensorVisible
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorVisible);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorVisible);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TargetHeading
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHeading);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHeading);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TargetHorizontalSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHorizontalSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHorizontalSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandleList Template3DModels
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandleList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Template3DModels);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Template3DModels);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string TemplatedObject
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TemplatedObject);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TemplatedObject);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public int TransponderCode
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TransponderCode);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TransponderCode);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte TurnDirection
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurnDirection);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurnDirection);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TurnRadius
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurnRadius);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurnRadius);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double UpdateRate
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UpdateRate);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UpdateRate);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte UseAnticollision
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UseAnticollision);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UseAnticollision);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double VerticalAcceleration
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VerticalAcceleration);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VerticalAcceleration);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double VerticalSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VerticalSpeed);
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
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VerticalSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public long timestamp
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                long value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.timestamp);
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
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.timestamp);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        #endregion

    }
}
