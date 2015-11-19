using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public partial class Entity
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
        protected static ClassHandle _classHandle = WISEConstants.WISE_INVALID_HANDLE;

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "Entity"; }
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
            get { return CBRNSensorsEntityTypes.Entity; }
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

        public Entity()
        {
            this.WISE = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Object = WISEConstants.WISE_INVALID_HANDLE;
            this.Transaction = TransactionHandle.None;            
        }

        public Entity(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
        {
            this.WISE = WISE;
            this.Database = databaseHandle;
            this.Object = objectHandle;
            this.Transaction = TransactionHandle.None;
        }

        public Entity(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle, TransactionHandle transactionHandle)
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
            return (className == Entity.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == Entity.Class);
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
                result = WISE.CreateObjectFromTemplate(hDatabase, objectName, Entity.ClassName, ref objectHandle, ref attributes);
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
// OBJECTIMPL: Float
        public double CurrentGroundSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CurrentGroundSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CurrentGroundSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string EntityType
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityType);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double FixedTurnRadius
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FixedTurnRadius);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FixedTurnRadius);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Formation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Formation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Formation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle FormationMaster
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FormationMaster);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FormationMaster);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Long
        public int FormationPosition
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FormationPosition);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FormationPosition);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double GroundSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Health
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Health);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Health);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double HorizontalAcceleration
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HorizontalAcceleration);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HorizontalAcceleration);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double HorizontalSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HorizontalSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HorizontalSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte IsOnGround
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsOnGround);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsOnGround);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Length
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Length);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Length);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxAcceleration
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxAcceleration);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxAcceleration);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxDeceleration
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxDeceleration);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxDeceleration);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxHorizontalSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxHorizontalSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxHorizontalSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxTurnSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxTurnSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxTurnSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Model3D
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Model3D);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Model3D);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Mover
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Mover);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Mover);
                
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
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 Orientation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Orientation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Orientation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 Position
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Position);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Position);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 PresentedOrientation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedOrientation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedOrientation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 PresentedPosition
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedPosition);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedPosition);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Vec3
        public STS.WISE.Vec3 PresentedVelocity
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.Vec3 value = Vec3.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PresentedVelocity);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PresentedVelocity);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double RadarCrossSection
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RadarCrossSection);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RadarCrossSection);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Radius
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Radius);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Radius);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte SensorVisible
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SensorVisible);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SensorVisible);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TargetHeading
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHeading);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHeading);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TargetHorizontalSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHorizontalSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHorizontalSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: HandleList
        public STS.WISE.ObjectHandleList Template3DModels
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandleList value = new STS.WISE.ObjectHandleList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Template3DModels);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Template3DModels);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string TemplatedObject
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TemplatedObject);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TemplatedObject);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Long
        public int TransponderCode
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TransponderCode);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TransponderCode);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte TurnDirection
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurnDirection);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurnDirection);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TurnRadius
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurnRadius);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurnRadius);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double UpdateRate
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UpdateRate);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UpdateRate);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte UseAnticollision
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UseAnticollision);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UseAnticollision);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double VerticalAcceleration
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VerticalAcceleration);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VerticalAcceleration);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double VerticalSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VerticalSpeed);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0.0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VerticalSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: LongLong
        public long timestamp
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                long value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.timestamp);
                }

                if (this.WISE != null)
                {
                    result = this.WISE.GetAttributeValue(this.Database, this.Object, attributeHandle, out value, this.Transaction);

                    if (WISEError.CheckCallSucceeded(result))
                    {
                        return value;
                    }
                }
                return 0;
            }
            
            set
            {
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.timestamp);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }

        #endregion

    }
}
