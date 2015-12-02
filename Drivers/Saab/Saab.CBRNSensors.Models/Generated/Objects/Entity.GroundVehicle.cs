using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    public partial class EntityGroundVehicle : WISEObject
    {
        #region Type definitions

        /// <summary>
        /// Enumeration of attributes in EntityGroundVehicle objects.
        /// </summary>
        public enum Attributes
        {
            Unknown,
            Active,
            Airline,
            AltitudeLockResumeAltitude,
            AltitudeLockStatus,
            AltitudeRequested,
            AngleSpeed,
            ApproachDist,
            ApproachSpeed,
            AssignedIAS,
            AssignedSpeedMach,
            AsternLineCurrDist,
            AsternLineMaster,
            AsternLineReqDist,
            AsternLineSlave,
            AviantionRules,
            ClearedToContinue,
            ClimbPerformance,
            ConflictAlert,
            Conflicts,
            Controller,
            CorrelatedCallsign,
            CurrentGroundSpeed,
            CurrentOperation,
            Departure,
            DescentPerformance,
            DescentSpeedRatio,
            DestFix,
            Destination,
            DestinationETA,
            DismissRequested,
            EngineName,
            EngineOn,
            EntityMode,
            EntityModeArgs,
            EntityType,
            Extension,
            FinalApproachDist,
            FinalApproachSpeed,
            FixedTurnRadius,
            Formation,
            FormationMaster,
            FormationPosition,
            Frequency,
            GPID,
            GroundAcceleration,
            GroundRetardation,
            GroundSpeed,
            HeadingRequested,
            Health,
            HorizontalAcceleration,
            HorizontalSpeed,
            ICAOCallsign,
            ICAOTelephoneCallsign,
            Id,
            Infotext,
            IsGarbage,
            IsHelicopter,
            IsOnGround,
            LandingDist,
            LandingGearDist,
            LandingGearName,
            LandingGearOut,
            LandingLightName,
            LandingLightsOn,
            LandingSpeed,
            LandingType,
            LayerDependentParameters,
            Length,
            MapSymbol,
            March,
            MaxAcceleration,
            MaxAltitude,
            MaxBankAngle,
            MaxClimbSpeed,
            MaxDeceleration,
            MaxDescentSpeed,
            MaxHorizontalSpeed,
            MaxTurnSpeed,
            MilitaryAffiliation,
            MinimumApproachSpeed,
            MinimumCleanSpeed,
            MissedRoute,
            ModeC,
            Model3D,
            Mover,
            NPBreakType,
            NPClose,
            Name,
            NavLightName,
            NavigationalLightsOn,
            NormalClimbSpeed,
            NormalDescentSpeed,
            OrbitStatus,
            Orientation,
            OverridedClimbSpeed,
            OverridedClimbSpeedFactor,
            OverridedDescentSpeed,
            OverridedDescentSpeedFactor,
            Overshoot,
            Parent,
            PlaneIndication,
            Position,
            PositionKind,
            PresentedOrientation,
            PresentedPosition,
            PresentedVelocity,
            QNH,
            RadarCrossSection,
            RadioCallname,
            Radius,
            ReferencePoint,
            ResetSpinn,
            Reversed,
            RolePilot,
            RoleTrainee,
            RouteName,
            Routes,
            Runway,
            SensorVisible,
            Setting_Bottom_Layer_Climb_Speed,
            Setting_Lift_Off_Height,
            Setting_Lift_Off_Speed,
            Setting_MaxBankingAngle,
            Setting_Max_ClimbSpeed,
            Setting_Max_DescentSpeed,
            Setting_NormalBankingAngle,
            Setting_Normal_ClimbSpeed,
            Setting_Normal_DescentSpeed,
            Setting_Normal_Speed_Ground,
            ShadowName,
            SlaveIndex,
            SlowDownRetardation,
            SlowDownSpeed,
            Smoke,
            SpeedPerformance,
            SpinAngleSpeed,
            SquawkActive,
            TakeoffSpeed,
            TargetAltitude,
            TargetClimbSpeed,
            TargetDescendSpeed,
            TargetHeading,
            TargetHorizontalSpeed,
            TargetHorizontalSpeedType,
            Template3DModels,
            TemplatedObject,
            TemporaryMaxSpeed,
            TouchAndGo,
            TransponderCode,
            TransponderState,
            TurbulenceCategory,
            TurnDirection,
            TurnRadius,
            TypeDescription,
            Unit,
            UpdateRate,
            UseAnticollision,
            UseCorrelated,
            VerticalAcceleration,
            VerticalSpeed,
            VirtualPilot,
            timestamp,
        } ;

        #endregion

        #region Static Members

        protected static BiDirectionalIndex<string, EntityGroundVehicle.Attributes> _nameIdIndex = new BiDirectionalIndex<string, Attributes>();
        protected static BiDirectionalIndex<EntityGroundVehicle.Attributes, AttributeHandle> _idHandleIndex = new BiDirectionalIndex<Attributes, AttributeHandle>();
        protected static ClassHandle _classHandle = WISEConstants.WISE_INVALID_HANDLE;

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "Entity.GroundVehicle"; }
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
            get { return CBRNSensorsEntityTypes.EntityGroundVehicle; }
        }

        #endregion

        #region Constructors

        public EntityGroundVehicle() : base() {}

        public EntityGroundVehicle(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
            : base(WISE, databaseHandle, objectHandle) {}

        public EntityGroundVehicle(INETWISEDriverSink2 WISE, DatabaseHandle databaseHandle, ObjectHandle objectHandle, TransactionHandle transactionHandle)
            : base(WISE, databaseHandle, objectHandle, transactionHandle) {}

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
                    _nameIdIndex.Add("Active", Attributes.Active);
                    _nameIdIndex.Add("Airline", Attributes.Airline);
                    _nameIdIndex.Add("AltitudeLockResumeAltitude", Attributes.AltitudeLockResumeAltitude);
                    _nameIdIndex.Add("AltitudeLockStatus", Attributes.AltitudeLockStatus);
                    _nameIdIndex.Add("AltitudeRequested", Attributes.AltitudeRequested);
                    _nameIdIndex.Add("AngleSpeed", Attributes.AngleSpeed);
                    _nameIdIndex.Add("ApproachDist", Attributes.ApproachDist);
                    _nameIdIndex.Add("ApproachSpeed", Attributes.ApproachSpeed);
                    _nameIdIndex.Add("AssignedIAS", Attributes.AssignedIAS);
                    _nameIdIndex.Add("AssignedSpeedMach", Attributes.AssignedSpeedMach);
                    _nameIdIndex.Add("AsternLineCurrDist", Attributes.AsternLineCurrDist);
                    _nameIdIndex.Add("AsternLineMaster", Attributes.AsternLineMaster);
                    _nameIdIndex.Add("AsternLineReqDist", Attributes.AsternLineReqDist);
                    _nameIdIndex.Add("AsternLineSlave", Attributes.AsternLineSlave);
                    _nameIdIndex.Add("AviantionRules", Attributes.AviantionRules);
                    _nameIdIndex.Add("ClearedToContinue", Attributes.ClearedToContinue);
                    _nameIdIndex.Add("ClimbPerformance", Attributes.ClimbPerformance);
                    _nameIdIndex.Add("ConflictAlert", Attributes.ConflictAlert);
                    _nameIdIndex.Add("Conflicts", Attributes.Conflicts);
                    _nameIdIndex.Add("Controller", Attributes.Controller);
                    _nameIdIndex.Add("CorrelatedCallsign", Attributes.CorrelatedCallsign);
                    _nameIdIndex.Add("CurrentGroundSpeed", Attributes.CurrentGroundSpeed);
                    _nameIdIndex.Add("CurrentOperation", Attributes.CurrentOperation);
                    _nameIdIndex.Add("Departure", Attributes.Departure);
                    _nameIdIndex.Add("DescentPerformance", Attributes.DescentPerformance);
                    _nameIdIndex.Add("DescentSpeedRatio", Attributes.DescentSpeedRatio);
                    _nameIdIndex.Add("DestFix", Attributes.DestFix);
                    _nameIdIndex.Add("Destination", Attributes.Destination);
                    _nameIdIndex.Add("DestinationETA", Attributes.DestinationETA);
                    _nameIdIndex.Add("DismissRequested", Attributes.DismissRequested);
                    _nameIdIndex.Add("EngineName", Attributes.EngineName);
                    _nameIdIndex.Add("EngineOn", Attributes.EngineOn);
                    _nameIdIndex.Add("EntityMode", Attributes.EntityMode);
                    _nameIdIndex.Add("EntityModeArgs", Attributes.EntityModeArgs);
                    _nameIdIndex.Add("EntityType", Attributes.EntityType);
                    _nameIdIndex.Add("Extension", Attributes.Extension);
                    _nameIdIndex.Add("FinalApproachDist", Attributes.FinalApproachDist);
                    _nameIdIndex.Add("FinalApproachSpeed", Attributes.FinalApproachSpeed);
                    _nameIdIndex.Add("FixedTurnRadius", Attributes.FixedTurnRadius);
                    _nameIdIndex.Add("Formation", Attributes.Formation);
                    _nameIdIndex.Add("FormationMaster", Attributes.FormationMaster);
                    _nameIdIndex.Add("FormationPosition", Attributes.FormationPosition);
                    _nameIdIndex.Add("Frequency", Attributes.Frequency);
                    _nameIdIndex.Add("GPID", Attributes.GPID);
                    _nameIdIndex.Add("GroundAcceleration", Attributes.GroundAcceleration);
                    _nameIdIndex.Add("GroundRetardation", Attributes.GroundRetardation);
                    _nameIdIndex.Add("GroundSpeed", Attributes.GroundSpeed);
                    _nameIdIndex.Add("HeadingRequested", Attributes.HeadingRequested);
                    _nameIdIndex.Add("Health", Attributes.Health);
                    _nameIdIndex.Add("HorizontalAcceleration", Attributes.HorizontalAcceleration);
                    _nameIdIndex.Add("HorizontalSpeed", Attributes.HorizontalSpeed);
                    _nameIdIndex.Add("ICAOCallsign", Attributes.ICAOCallsign);
                    _nameIdIndex.Add("ICAOTelephoneCallsign", Attributes.ICAOTelephoneCallsign);
                    _nameIdIndex.Add("Id", Attributes.Id);
                    _nameIdIndex.Add("Infotext", Attributes.Infotext);
                    _nameIdIndex.Add("IsGarbage", Attributes.IsGarbage);
                    _nameIdIndex.Add("IsHelicopter", Attributes.IsHelicopter);
                    _nameIdIndex.Add("IsOnGround", Attributes.IsOnGround);
                    _nameIdIndex.Add("LandingDist", Attributes.LandingDist);
                    _nameIdIndex.Add("LandingGearDist", Attributes.LandingGearDist);
                    _nameIdIndex.Add("LandingGearName", Attributes.LandingGearName);
                    _nameIdIndex.Add("LandingGearOut", Attributes.LandingGearOut);
                    _nameIdIndex.Add("LandingLightName", Attributes.LandingLightName);
                    _nameIdIndex.Add("LandingLightsOn", Attributes.LandingLightsOn);
                    _nameIdIndex.Add("LandingSpeed", Attributes.LandingSpeed);
                    _nameIdIndex.Add("LandingType", Attributes.LandingType);
                    _nameIdIndex.Add("LayerDependentParameters", Attributes.LayerDependentParameters);
                    _nameIdIndex.Add("Length", Attributes.Length);
                    _nameIdIndex.Add("MapSymbol", Attributes.MapSymbol);
                    _nameIdIndex.Add("March", Attributes.March);
                    _nameIdIndex.Add("MaxAcceleration", Attributes.MaxAcceleration);
                    _nameIdIndex.Add("MaxAltitude", Attributes.MaxAltitude);
                    _nameIdIndex.Add("MaxBankAngle", Attributes.MaxBankAngle);
                    _nameIdIndex.Add("MaxClimbSpeed", Attributes.MaxClimbSpeed);
                    _nameIdIndex.Add("MaxDeceleration", Attributes.MaxDeceleration);
                    _nameIdIndex.Add("MaxDescentSpeed", Attributes.MaxDescentSpeed);
                    _nameIdIndex.Add("MaxHorizontalSpeed", Attributes.MaxHorizontalSpeed);
                    _nameIdIndex.Add("MaxTurnSpeed", Attributes.MaxTurnSpeed);
                    _nameIdIndex.Add("MilitaryAffiliation", Attributes.MilitaryAffiliation);
                    _nameIdIndex.Add("MinimumApproachSpeed", Attributes.MinimumApproachSpeed);
                    _nameIdIndex.Add("MinimumCleanSpeed", Attributes.MinimumCleanSpeed);
                    _nameIdIndex.Add("MissedRoute", Attributes.MissedRoute);
                    _nameIdIndex.Add("ModeC", Attributes.ModeC);
                    _nameIdIndex.Add("Model3D", Attributes.Model3D);
                    _nameIdIndex.Add("Mover", Attributes.Mover);
                    _nameIdIndex.Add("NPBreakType", Attributes.NPBreakType);
                    _nameIdIndex.Add("NPClose", Attributes.NPClose);
                    _nameIdIndex.Add("Name", Attributes.Name);
                    _nameIdIndex.Add("NavLightName", Attributes.NavLightName);
                    _nameIdIndex.Add("NavigationalLightsOn", Attributes.NavigationalLightsOn);
                    _nameIdIndex.Add("NormalClimbSpeed", Attributes.NormalClimbSpeed);
                    _nameIdIndex.Add("NormalDescentSpeed", Attributes.NormalDescentSpeed);
                    _nameIdIndex.Add("OrbitStatus", Attributes.OrbitStatus);
                    _nameIdIndex.Add("Orientation", Attributes.Orientation);
                    _nameIdIndex.Add("OverridedClimbSpeed", Attributes.OverridedClimbSpeed);
                    _nameIdIndex.Add("OverridedClimbSpeedFactor", Attributes.OverridedClimbSpeedFactor);
                    _nameIdIndex.Add("OverridedDescentSpeed", Attributes.OverridedDescentSpeed);
                    _nameIdIndex.Add("OverridedDescentSpeedFactor", Attributes.OverridedDescentSpeedFactor);
                    _nameIdIndex.Add("Overshoot", Attributes.Overshoot);
                    _nameIdIndex.Add("Parent", Attributes.Parent);
                    _nameIdIndex.Add("PlaneIndication", Attributes.PlaneIndication);
                    _nameIdIndex.Add("Position", Attributes.Position);
                    _nameIdIndex.Add("PositionKind", Attributes.PositionKind);
                    _nameIdIndex.Add("PresentedOrientation", Attributes.PresentedOrientation);
                    _nameIdIndex.Add("PresentedPosition", Attributes.PresentedPosition);
                    _nameIdIndex.Add("PresentedVelocity", Attributes.PresentedVelocity);
                    _nameIdIndex.Add("QNH", Attributes.QNH);
                    _nameIdIndex.Add("RadarCrossSection", Attributes.RadarCrossSection);
                    _nameIdIndex.Add("RadioCallname", Attributes.RadioCallname);
                    _nameIdIndex.Add("Radius", Attributes.Radius);
                    _nameIdIndex.Add("ReferencePoint", Attributes.ReferencePoint);
                    _nameIdIndex.Add("ResetSpinn", Attributes.ResetSpinn);
                    _nameIdIndex.Add("Reversed", Attributes.Reversed);
                    _nameIdIndex.Add("RolePilot", Attributes.RolePilot);
                    _nameIdIndex.Add("RoleTrainee", Attributes.RoleTrainee);
                    _nameIdIndex.Add("RouteName", Attributes.RouteName);
                    _nameIdIndex.Add("Routes", Attributes.Routes);
                    _nameIdIndex.Add("Runway", Attributes.Runway);
                    _nameIdIndex.Add("SensorVisible", Attributes.SensorVisible);
                    _nameIdIndex.Add("Setting_Bottom_Layer_Climb_Speed", Attributes.Setting_Bottom_Layer_Climb_Speed);
                    _nameIdIndex.Add("Setting_Lift_Off_Height", Attributes.Setting_Lift_Off_Height);
                    _nameIdIndex.Add("Setting_Lift_Off_Speed", Attributes.Setting_Lift_Off_Speed);
                    _nameIdIndex.Add("Setting_MaxBankingAngle", Attributes.Setting_MaxBankingAngle);
                    _nameIdIndex.Add("Setting_Max_ClimbSpeed", Attributes.Setting_Max_ClimbSpeed);
                    _nameIdIndex.Add("Setting_Max_DescentSpeed", Attributes.Setting_Max_DescentSpeed);
                    _nameIdIndex.Add("Setting_NormalBankingAngle", Attributes.Setting_NormalBankingAngle);
                    _nameIdIndex.Add("Setting_Normal_ClimbSpeed", Attributes.Setting_Normal_ClimbSpeed);
                    _nameIdIndex.Add("Setting_Normal_DescentSpeed", Attributes.Setting_Normal_DescentSpeed);
                    _nameIdIndex.Add("Setting_Normal_Speed_Ground", Attributes.Setting_Normal_Speed_Ground);
                    _nameIdIndex.Add("ShadowName", Attributes.ShadowName);
                    _nameIdIndex.Add("SlaveIndex", Attributes.SlaveIndex);
                    _nameIdIndex.Add("SlowDownRetardation", Attributes.SlowDownRetardation);
                    _nameIdIndex.Add("SlowDownSpeed", Attributes.SlowDownSpeed);
                    _nameIdIndex.Add("Smoke", Attributes.Smoke);
                    _nameIdIndex.Add("SpeedPerformance", Attributes.SpeedPerformance);
                    _nameIdIndex.Add("SpinAngleSpeed", Attributes.SpinAngleSpeed);
                    _nameIdIndex.Add("SquawkActive", Attributes.SquawkActive);
                    _nameIdIndex.Add("TakeoffSpeed", Attributes.TakeoffSpeed);
                    _nameIdIndex.Add("TargetAltitude", Attributes.TargetAltitude);
                    _nameIdIndex.Add("TargetClimbSpeed", Attributes.TargetClimbSpeed);
                    _nameIdIndex.Add("TargetDescendSpeed", Attributes.TargetDescendSpeed);
                    _nameIdIndex.Add("TargetHeading", Attributes.TargetHeading);
                    _nameIdIndex.Add("TargetHorizontalSpeed", Attributes.TargetHorizontalSpeed);
                    _nameIdIndex.Add("TargetHorizontalSpeedType", Attributes.TargetHorizontalSpeedType);
                    _nameIdIndex.Add("Template3DModels", Attributes.Template3DModels);
                    _nameIdIndex.Add("TemplatedObject", Attributes.TemplatedObject);
                    _nameIdIndex.Add("TemporaryMaxSpeed", Attributes.TemporaryMaxSpeed);
                    _nameIdIndex.Add("TouchAndGo", Attributes.TouchAndGo);
                    _nameIdIndex.Add("TransponderCode", Attributes.TransponderCode);
                    _nameIdIndex.Add("TransponderState", Attributes.TransponderState);
                    _nameIdIndex.Add("TurbulenceCategory", Attributes.TurbulenceCategory);
                    _nameIdIndex.Add("TurnDirection", Attributes.TurnDirection);
                    _nameIdIndex.Add("TurnRadius", Attributes.TurnRadius);
                    _nameIdIndex.Add("TypeDescription", Attributes.TypeDescription);
                    _nameIdIndex.Add("Unit", Attributes.Unit);
                    _nameIdIndex.Add("UpdateRate", Attributes.UpdateRate);
                    _nameIdIndex.Add("UseAnticollision", Attributes.UseAnticollision);
                    _nameIdIndex.Add("UseCorrelated", Attributes.UseCorrelated);
                    _nameIdIndex.Add("VerticalAcceleration", Attributes.VerticalAcceleration);
                    _nameIdIndex.Add("VerticalSpeed", Attributes.VerticalSpeed);
                    _nameIdIndex.Add("VirtualPilot", Attributes.VirtualPilot);
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
            return (className == EntityGroundVehicle.ClassName);
        }

        static public bool IsTypeOf(ClassHandle hClass)
        {
            return (hClass == EntityGroundVehicle.Class);
        }

        #endregion

        #region Object creation methods

        public override uint CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase)
        {
            return CreateInstance(WISE, hDatabase, "");
        }

        public override uint CreateInstance(INETWISEDriverSink2 WISE, DatabaseHandle hDatabase, string objectName)
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
                result = WISE.CreateObjectFromTemplate(hDatabase, objectName, EntityGroundVehicle.ClassName, ref objectHandle, ref attributes);
            }

            if (WISEError.CheckCallSucceeded(result))
            {
                this.WISE = WISE;
                this.Database = WISEConstants.WISE_INVALID_HANDLE;
                this.Object = objectHandle;
            }

            return result;
        }

        public override uint AddToDatabase(DatabaseHandle databaseHandle)
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
// OBJECTIMPL: Byte
        public byte Active
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Active);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Active);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Airline
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Airline);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Airline);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double AltitudeLockResumeAltitude
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeLockResumeAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeLockResumeAltitude);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte AltitudeLockStatus
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeLockStatus);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeLockStatus);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string AltitudeRequested
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeRequested);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double AngleSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AngleSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AngleSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double ApproachDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ApproachDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ApproachDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double ApproachSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ApproachSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double AssignedIAS
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AssignedIAS);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AssignedIAS);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte AssignedSpeedMach
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AssignedSpeedMach);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AssignedSpeedMach);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double AsternLineCurrDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineCurrDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineCurrDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle AsternLineMaster
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineMaster);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineMaster);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double AsternLineReqDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineReqDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineReqDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle AsternLineSlave
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineSlave);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineSlave);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte AviantionRules
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AviantionRules);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AviantionRules);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte ClearedToContinue
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ClearedToContinue);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ClearedToContinue);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte ClimbPerformance
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ClimbPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ClimbPerformance);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte ConflictAlert
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ConflictAlert);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ConflictAlert);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: AttributeGroupList
        public STS.WISE.GroupList Conflicts
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.GroupList value = new STS.WISE.GroupList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Conflicts);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Conflicts);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Controller
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Controller);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Controller);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string CorrelatedCallsign
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CorrelatedCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CorrelatedCallsign);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
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
        public string CurrentOperation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CurrentOperation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CurrentOperation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Departure
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Departure);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Departure);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte DescentPerformance
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DescentPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DescentPerformance);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double DescentSpeedRatio
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DescentSpeedRatio);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DescentSpeedRatio);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle DestFix
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DestFix);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DestFix);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Destination
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Destination);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Destination);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string DestinationETA
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DestinationETA);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DestinationETA);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte DismissRequested
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DismissRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DismissRequested);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string EngineName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EngineName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EngineName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte EngineOn
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EngineOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EngineOn);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte EntityMode
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityMode);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityMode);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle EntityModeArgs
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityModeArgs);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityModeArgs);
                
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
        public double Extension
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Extension);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Extension);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double FinalApproachDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FinalApproachDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FinalApproachDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double FinalApproachSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FinalApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FinalApproachSpeed);
                
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
        public double Frequency
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Frequency);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Frequency);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Long
        public int GPID
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GPID);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GPID);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double GroundAcceleration
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundAcceleration);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundAcceleration);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double GroundRetardation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundRetardation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundRetardation);
                
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
// OBJECTIMPL: String
        public string HeadingRequested
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HeadingRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HeadingRequested);
                
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
// OBJECTIMPL: String
        public string ICAOCallsign
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ICAOCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ICAOCallsign);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string ICAOTelephoneCallsign
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ICAOTelephoneCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ICAOTelephoneCallsign);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string Id
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Id);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Id);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string Infotext
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Infotext);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Infotext);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte IsGarbage
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsGarbage);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsGarbage);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte IsHelicopter
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsHelicopter);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsHelicopter);
                
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
        public double LandingDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double LandingGearDist
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearDist);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string LandingGearName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte LandingGearOut
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearOut);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearOut);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string LandingLightName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingLightName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingLightName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte LandingLightsOn
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingLightsOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingLightsOn);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double LandingSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte LandingType
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingType);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: AttributeGroupList
        public STS.WISE.GroupList LayerDependentParameters
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.GroupList value = new STS.WISE.GroupList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LayerDependentParameters);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LayerDependentParameters);
                
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
// OBJECTIMPL: Byte
        public byte MapSymbol
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MapSymbol);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MapSymbol);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte March
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.March);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.March);
                
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
        public double MaxAltitude
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxAltitude);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxBankAngle
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxBankAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxBankAngle);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MaxClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxClimbSpeed);
                
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
        public double MaxDescentSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxDescentSpeed);
                
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
        public STS.WISE.ObjectHandle MilitaryAffiliation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MilitaryAffiliation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MilitaryAffiliation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MinimumApproachSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MinimumApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MinimumApproachSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double MinimumCleanSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MinimumCleanSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MinimumCleanSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle MissedRoute
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MissedRoute);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MissedRoute);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte ModeC
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ModeC);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ModeC);
                
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
// OBJECTIMPL: Byte
        public byte NPBreakType
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NPBreakType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NPBreakType);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte NPClose
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NPClose);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NPClose);
                
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
// OBJECTIMPL: String
        public string NavLightName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NavLightName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NavLightName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte NavigationalLightsOn
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NavigationalLightsOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NavigationalLightsOn);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double NormalClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NormalClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NormalClimbSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double NormalDescentSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NormalDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NormalDescentSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string OrbitStatus
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OrbitStatus);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OrbitStatus);
                
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
// OBJECTIMPL: Float
        public double OverridedClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedClimbSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double OverridedClimbSpeedFactor
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedClimbSpeedFactor);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedClimbSpeedFactor);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double OverridedDescentSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedDescentSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double OverridedDescentSpeedFactor
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedDescentSpeedFactor);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedDescentSpeedFactor);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Overshoot
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Overshoot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Overshoot);
                
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
// OBJECTIMPL: Float
        public double PlaneIndication
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PlaneIndication);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PlaneIndication);
                
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
// OBJECTIMPL: Byte
        public byte PositionKind
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PositionKind);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PositionKind);
                
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
        public double QNH
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.QNH);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.QNH);
                
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
// OBJECTIMPL: String
        public string RadioCallname
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RadioCallname);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RadioCallname);
                
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
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle ReferencePoint
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ReferencePoint);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ReferencePoint);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte ResetSpinn
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ResetSpinn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ResetSpinn);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Reversed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Reversed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Reversed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle RolePilot
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RolePilot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RolePilot);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle RoleTrainee
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RoleTrainee);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RoleTrainee);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string RouteName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RouteName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RouteName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: HandleList
        public STS.WISE.ObjectHandleList Routes
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandleList value = new STS.WISE.ObjectHandleList();
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Routes);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Routes);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Handle
        public STS.WISE.ObjectHandle Runway
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Runway);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Runway);
                
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
        public double Setting_Bottom_Layer_Climb_Speed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Bottom_Layer_Climb_Speed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Bottom_Layer_Climb_Speed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Lift_Off_Height
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Lift_Off_Height);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Lift_Off_Height);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Lift_Off_Speed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Lift_Off_Speed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Lift_Off_Speed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_MaxBankingAngle
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_MaxBankingAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_MaxBankingAngle);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Max_ClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Max_ClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Max_ClimbSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Max_DescentSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Max_DescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Max_DescentSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_NormalBankingAngle
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_NormalBankingAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_NormalBankingAngle);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Normal_ClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_ClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_ClimbSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Normal_DescentSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_DescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_DescentSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double Setting_Normal_Speed_Ground
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_Speed_Ground);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_Speed_Ground);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: String
        public string ShadowName
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ShadowName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ShadowName);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Long
        public int SlaveIndex
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlaveIndex);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlaveIndex);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double SlowDownRetardation
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlowDownRetardation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlowDownRetardation);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double SlowDownSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlowDownSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlowDownSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Smoke
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Smoke);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Smoke);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte SpeedPerformance
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SpeedPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SpeedPerformance);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double SpinAngleSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SpinAngleSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SpinAngleSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte SquawkActive
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SquawkActive);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SquawkActive);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TakeoffSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TakeoffSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TakeoffSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TargetAltitude
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetAltitude);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TargetClimbSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetClimbSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Float
        public double TargetDescendSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetDescendSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetDescendSpeed);
                
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
// OBJECTIMPL: Byte
        public byte TargetHorizontalSpeedType
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHorizontalSpeedType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHorizontalSpeedType);
                
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
// OBJECTIMPL: Float
        public double TemporaryMaxSpeed
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TemporaryMaxSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TemporaryMaxSpeed);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte TouchAndGo
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TouchAndGo);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TouchAndGo);
                
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
        public byte TransponderState
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TransponderState);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TransponderState);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte TurbulenceCategory
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurbulenceCategory);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurbulenceCategory);
                
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
// OBJECTIMPL: String
        public string TypeDescription
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TypeDescription);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TypeDescription);
                
                if (this.WISE != null)
                {
                    this.WISE.SetAttributeValue(this.Database, this.Object, attributeHandle, value, DateTime.Now, 0, AttributeQuality.Good);
                }
            }
        }
// OBJECTIMPL: Byte
        public byte Unit
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Unit);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Unit);
                
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
// OBJECTIMPL: Byte
        public byte UseCorrelated
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UseCorrelated);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UseCorrelated);
                
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
// OBJECTIMPL: Byte
        public byte VirtualPilot
        {
            get
            {
                uint result = WISEError.WISE_ERROR;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VirtualPilot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VirtualPilot);
                
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
