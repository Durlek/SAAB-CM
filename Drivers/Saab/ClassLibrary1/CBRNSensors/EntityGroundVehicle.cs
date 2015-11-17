using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRN.Generated
{
    public class EntityGroundVehicle
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

        #endregion

        #region Class Properties

        static public string ClassName
        {
            get { return "Entity.GroundVehicle"; }
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

        public EntityGroundVehicle()
        {
            this.WISESink = null;
            this.Database = WISEConstants.WISE_TRANSITION_CACHE_DATABASE;
            this.Handle = WISEConstants.WISE_INVALID_HANDLE;
        }

        public EntityGroundVehicle(INETWISEDriverSink sink, DatabaseHandle databaseHandle, ObjectHandle objectHandle)
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
            return (className == EntityGroundVehicle.ClassName);
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
                wResult = sink.CreateObjectFromTemplate(hDatabase, objectName, EntityGroundVehicle.ClassName, ref objectHandle, ref attributes);
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

        public byte Active
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Active);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Active);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Airline
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Airline);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Airline);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double AltitudeLockResumeAltitude
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeLockResumeAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeLockResumeAltitude);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte AltitudeLockStatus
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeLockStatus);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeLockStatus);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string AltitudeRequested
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AltitudeRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AltitudeRequested);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double AngleSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AngleSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AngleSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double ApproachDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ApproachDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ApproachDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double ApproachSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ApproachSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double AssignedIAS
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AssignedIAS);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AssignedIAS);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte AssignedSpeedMach
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AssignedSpeedMach);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AssignedSpeedMach);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double AsternLineCurrDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineCurrDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineCurrDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle AsternLineMaster
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineMaster);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineMaster);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double AsternLineReqDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineReqDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineReqDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle AsternLineSlave
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AsternLineSlave);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AsternLineSlave);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte AviantionRules
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.AviantionRules);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.AviantionRules);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte ClearedToContinue
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ClearedToContinue);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ClearedToContinue);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte ClimbPerformance
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ClimbPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ClimbPerformance);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte ConflictAlert
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ConflictAlert);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ConflictAlert);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.GroupList Conflicts
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.GroupList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Conflicts);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Conflicts);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Controller
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Controller);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Controller);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string CorrelatedCallsign
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CorrelatedCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CorrelatedCallsign);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

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

        public string CurrentOperation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.CurrentOperation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.CurrentOperation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Departure
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Departure);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Departure);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte DescentPerformance
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DescentPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DescentPerformance);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double DescentSpeedRatio
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DescentSpeedRatio);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DescentSpeedRatio);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle DestFix
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DestFix);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DestFix);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Destination
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Destination);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Destination);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string DestinationETA
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DestinationETA);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DestinationETA);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte DismissRequested
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.DismissRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.DismissRequested);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string EngineName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EngineName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EngineName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte EngineOn
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EngineOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EngineOn);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte EntityMode
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityMode);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityMode);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle EntityModeArgs
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.EntityModeArgs);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.EntityModeArgs);
                
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

        public double Extension
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Extension);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Extension);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double FinalApproachDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FinalApproachDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FinalApproachDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double FinalApproachSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.FinalApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.FinalApproachSpeed);
                
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

        public double Frequency
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Frequency);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Frequency);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public int GPID
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GPID);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GPID);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double GroundAcceleration
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundAcceleration);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundAcceleration);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double GroundRetardation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.GroundRetardation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.GroundRetardation);
                
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

        public string HeadingRequested
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.HeadingRequested);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.HeadingRequested);
                
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

        public string ICAOCallsign
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ICAOCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ICAOCallsign);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string ICAOTelephoneCallsign
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ICAOTelephoneCallsign);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ICAOTelephoneCallsign);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string Id
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Id);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Id);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string Infotext
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Infotext);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Infotext);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte IsGarbage
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsGarbage);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsGarbage);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte IsHelicopter
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.IsHelicopter);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.IsHelicopter);
                
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

        public double LandingDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double LandingGearDist
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearDist);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearDist);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string LandingGearName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte LandingGearOut
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingGearOut);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingGearOut);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string LandingLightName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingLightName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingLightName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte LandingLightsOn
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingLightsOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingLightsOn);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double LandingSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte LandingType
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LandingType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LandingType);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.GroupList LayerDependentParameters
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.GroupList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.LayerDependentParameters);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.LayerDependentParameters);
                
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

        public byte MapSymbol
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MapSymbol);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MapSymbol);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte March
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.March);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.March);
                
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

        public double MaxAltitude
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxAltitude);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxBankAngle
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxBankAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxBankAngle);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MaxClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxClimbSpeed);
                
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

        public double MaxDescentSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MaxDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MaxDescentSpeed);
                
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

        public STS.WISE.ObjectHandle MilitaryAffiliation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MilitaryAffiliation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MilitaryAffiliation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MinimumApproachSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MinimumApproachSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MinimumApproachSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double MinimumCleanSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MinimumCleanSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MinimumCleanSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle MissedRoute
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.MissedRoute);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.MissedRoute);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte ModeC
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ModeC);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ModeC);
                
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

        public byte NPBreakType
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NPBreakType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NPBreakType);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte NPClose
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NPClose);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NPClose);
                
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

        public string NavLightName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NavLightName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NavLightName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte NavigationalLightsOn
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NavigationalLightsOn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NavigationalLightsOn);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double NormalClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NormalClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NormalClimbSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double NormalDescentSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.NormalDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.NormalDescentSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string OrbitStatus
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OrbitStatus);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OrbitStatus);
                
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

        public double OverridedClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedClimbSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double OverridedClimbSpeedFactor
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedClimbSpeedFactor);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedClimbSpeedFactor);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double OverridedDescentSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedDescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedDescentSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double OverridedDescentSpeedFactor
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.OverridedDescentSpeedFactor);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.OverridedDescentSpeedFactor);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Overshoot
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Overshoot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Overshoot);
                
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

        public double PlaneIndication
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PlaneIndication);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PlaneIndication);
                
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

        public byte PositionKind
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.PositionKind);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.PositionKind);
                
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

        public double QNH
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.QNH);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.QNH);
                
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

        public string RadioCallname
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RadioCallname);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RadioCallname);
                
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

        public STS.WISE.ObjectHandle ReferencePoint
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ReferencePoint);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ReferencePoint);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte ResetSpinn
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ResetSpinn);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ResetSpinn);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Reversed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Reversed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Reversed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle RolePilot
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RolePilot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RolePilot);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle RoleTrainee
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RoleTrainee);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RoleTrainee);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string RouteName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.RouteName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.RouteName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandleList Routes
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandleList value = null;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Routes);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Routes);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public STS.WISE.ObjectHandle Runway
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                STS.WISE.ObjectHandle value = WISEConstants.WISE_INVALID_HANDLE;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Runway);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Runway);
                
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

        public double Setting_Bottom_Layer_Climb_Speed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Bottom_Layer_Climb_Speed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Bottom_Layer_Climb_Speed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Lift_Off_Height
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Lift_Off_Height);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Lift_Off_Height);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Lift_Off_Speed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Lift_Off_Speed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Lift_Off_Speed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_MaxBankingAngle
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_MaxBankingAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_MaxBankingAngle);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Max_ClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Max_ClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Max_ClimbSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Max_DescentSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Max_DescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Max_DescentSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_NormalBankingAngle
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_NormalBankingAngle);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_NormalBankingAngle);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Normal_ClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_ClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_ClimbSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Normal_DescentSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_DescentSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_DescentSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double Setting_Normal_Speed_Ground
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Setting_Normal_Speed_Ground);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Setting_Normal_Speed_Ground);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public string ShadowName
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.ShadowName);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.ShadowName);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public int SlaveIndex
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                int value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlaveIndex);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlaveIndex);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double SlowDownRetardation
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlowDownRetardation);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlowDownRetardation);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double SlowDownSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SlowDownSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SlowDownSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Smoke
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Smoke);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Smoke);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte SpeedPerformance
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SpeedPerformance);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SpeedPerformance);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double SpinAngleSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SpinAngleSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SpinAngleSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte SquawkActive
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.SquawkActive);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.SquawkActive);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TakeoffSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TakeoffSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TakeoffSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TargetAltitude
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetAltitude);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetAltitude);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TargetClimbSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetClimbSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetClimbSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public double TargetDescendSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetDescendSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetDescendSpeed);
                
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

        public byte TargetHorizontalSpeedType
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TargetHorizontalSpeedType);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TargetHorizontalSpeedType);
                
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

        public double TemporaryMaxSpeed
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                double value = 0.0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TemporaryMaxSpeed);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TemporaryMaxSpeed);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte TouchAndGo
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TouchAndGo);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TouchAndGo);
                
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

        public byte TransponderState
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TransponderState);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TransponderState);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte TurbulenceCategory
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TurbulenceCategory);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TurbulenceCategory);
                
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

        public string TypeDescription
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                string value = string.Empty;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.TypeDescription);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.TypeDescription);
                
                if (this.WISESink != null)
                {
                    // Initialize handle cache
                    Initialize(this.StringCache);

                    this.WISESink.SetAttributeValue(this.Database, this.Handle, attributeHandle, value, DateTime.Now, 0);
                }
            }
        }

        public byte Unit
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.Unit);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.Unit);
                
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

        public byte UseCorrelated
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.UseCorrelated);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.UseCorrelated);
                
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

        public byte VirtualPilot
        {
            get
            {
                WISE_RESULT wResult = WISEError.WISE_OK;
                byte value = 0;
                AttributeHandle attributeHandle = WISEConstants.WISE_INVALID_HANDLE;
                
                lock (_idHandleIndex)
                {
                    attributeHandle = _idHandleIndex.GetByFirst(Attributes.VirtualPilot);
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
                AttributeHandle attributeHandle = GetHandleFromAttributeId(Attributes.VirtualPilot);
                
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
