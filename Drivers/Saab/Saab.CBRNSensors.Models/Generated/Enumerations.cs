using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace Saab.CBRNSensors.Models
{
    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum AircraftPerformance
    {
        /// <summary>
        /// 
        /// </summary>
        eAbsolute = 0,
        /// <summary>
        /// 
        /// </summary>
        eMax = 1,
        /// <summary>
        /// 
        /// </summary>
        eMin = 3,
        /// <summary>
        /// 
        /// </summary>
        eNormal = 2,
        /// <summary>
        /// 
        /// </summary>
        eemergency = 5,
        /// <summary>
        /// 
        /// </summary>
        eexpeditfart = 4,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum AviationRules
    {
        /// <summary>
        /// 
        /// </summary>
        eIFR = 1,
        /// <summary>
        /// 
        /// </summary>
        eUnknown = 0,
        /// <summary>
        /// 
        /// </summary>
        eVFR = 2,
        /// <summary>
        /// 
        /// </summary>
        eY = 3,
        /// <summary>
        /// 
        /// </summary>
        eZ = 4,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum BreakLandingType
    {
        /// <summary>
        /// 
        /// </summary>
        eCONTINUE = 4,
        /// <summary>
        /// 
        /// </summary>
        eEARLY = 0,
        /// <summary>
        /// 
        /// </summary>
        eLATE = 3,
        /// <summary>
        /// 
        /// </summary>
        eLOWAPPROACH = 5,
        /// <summary>
        /// 
        /// </summary>
        eMID = 2,
        /// <summary>
        /// 
        /// </summary>
        eNORMAL = 1,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNDetectionLibrary
    {
        /// <summary>
        /// Chemical warfare agent (CWA)
        /// </summary>
        eCWA = 0,
        /// <summary>
        /// Toxic industrial chemical (TIC)
        /// </summary>
        eTIC = 1,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNDetectionMode
    {
        /// <summary>
        /// Chemical warfare agent (CWA)
        /// </summary>
        eCWA = 0,
        /// <summary>
        /// Chemical warfare agent (CWA) continous
        /// </summary>
        eCWAcont = 2,
        /// <summary>
        /// Toxic industrial chemical (TIC)
        /// </summary>
        eTIC = 1,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNParticleModel
    {
        /// <summary>
        /// CFD
        /// </summary>
        eCFD = 2,
        /// <summary>
        /// Particle
        /// </summary>
        eParticle = 1,
        /// <summary>
        /// Puff
        /// </summary>
        ePuff = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNRAIDState
    {
        /// <summary>
        /// Analytic checking. Internal state is analytic test. NOT USED
        /// </summary>
        eanalytictest = 5,
        /// <summary>
        /// Cleaning. Internal state is Standby
        /// </summary>
        ecleaning = 2,
        /// <summary>
        /// Off. Internal state is error. NOT USED
        /// </summary>
        eoff = 6,
        /// <summary>
        /// Started. Internal state is Measuring
        /// </summary>
        estarted = 1,
        /// <summary>
        /// Starting. Internal state is Self test. NOT USED
        /// </summary>
        estartingselftest = 4,
        /// <summary>
        /// Starting. Internal state is Warm Up. NOT USED
        /// </summary>
        estartingwarmup = 3,
        /// <summary>
        /// Stopped. Internal state is Standby
        /// </summary>
        estopped = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNRapidCalibrationStatus
    {
        /// <summary>
        /// 
        /// </summary>
        ecoldreference = 2,
        /// <summary>
        /// 
        /// </summary>
        edone = 6,
        /// <summary>
        /// 
        /// </summary>
        efailed = 5,
        /// <summary>
        /// 
        /// </summary>
        eheating = 3,
        /// <summary>
        /// 
        /// </summary>
        enotcalibrating = 0,
        /// <summary>
        /// 
        /// </summary>
        estarting = 1,
        /// <summary>
        /// 
        /// </summary>
        ewarmreference = 4,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNRapidLibrary
    {
        /// <summary>
        /// 
        /// </summary>
        eCWA = 2,
        /// <summary>
        /// 
        /// </summary>
        eSIM = 0,
        /// <summary>
        /// 
        /// </summary>
        eTIC = 1,
        /// <summary>
        /// 
        /// </summary>
        eTST = 3,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNRapidSamplingMode
    {
        /// <summary>
        /// 
        /// </summary>
        efixeddirection = 1,
        /// <summary>
        /// 
        /// </summary>
        efullscan = 2,
        /// <summary>
        /// Stopped
        /// </summary>
        enotsampling = 0,
        /// <summary>
        /// 
        /// </summary>
        escansector1 = 3,
        /// <summary>
        /// 
        /// </summary>
        escansector2 = 4,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNRapidStatus
    {
        /// <summary>
        /// 
        /// </summary>
        ecalibrating = 4,
        /// <summary>
        /// 
        /// </summary>
        ecooling = 1,
        /// <summary>
        /// 
        /// </summary>
        einitialising = 2,
        /// <summary>
        /// 
        /// </summary>
        esampling = 5,
        /// <summary>
        /// 
        /// </summary>
        estarting = 3,
        /// <summary>
        /// Stopped
        /// </summary>
        estopped = 0,
        /// <summary>
        /// 
        /// </summary>
        estopping = 6,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum CBRNSensorMode
    {
        /// <summary>
        /// 
        /// </summary>
        eBlister = 1,
        /// <summary>
        /// 
        /// </summary>
        eNerve = 2,
        /// <summary>
        /// 
        /// </summary>
        eOff = 0,
        /// <summary>
        /// 
        /// </summary>
        eUnknown = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum ControlledBy
    {
        /// <summary>
        /// 
        /// </summary>
        eExternal = 2,
        /// <summary>
        /// 
        /// </summary>
        ePilot = 1,
        /// <summary>
        /// 
        /// </summary>
        eUnknown = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum EntityModeType
    {
        /// <summary>
        /// 
        /// </summary>
        eLANDING = 3,
        /// <summary>
        /// 
        /// </summary>
        ePILOT = 0,
        /// <summary>
        /// 
        /// </summary>
        eROUTE = 1,
        /// <summary>
        /// 
        /// </summary>
        eTAKEOFF = 2,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum HighMediumLowType
    {
        /// <summary>
        /// 
        /// </summary>
        eHigh = 0,
        /// <summary>
        /// 
        /// </summary>
        eLow = 2,
        /// <summary>
        /// 
        /// </summary>
        eMedium = 1,
        /// <summary>
        /// 
        /// </summary>
        eNone = 3,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum LandingType
    {
        /// <summary>
        /// 
        /// </summary>
        eARC = 0,
        /// <summary>
        /// 
        /// </summary>
        eAUTO = 9,
        /// <summary>
        /// 
        /// </summary>
        eHelicopter = 8,
        /// <summary>
        /// 
        /// </summary>
        eILS = 3,
        /// <summary>
        /// 
        /// </summary>
        eTILS = 4,
        /// <summary>
        /// 
        /// </summary>
        eTILSLB2 = 13,
        /// <summary>
        /// 
        /// </summary>
        eTILSLBIPH = 10,
        /// <summary>
        /// 
        /// </summary>
        eTILSLBIPL = 11,
        /// <summary>
        /// 
        /// </summary>
        eTILSLBIPR = 12,
        /// <summary>
        /// 
        /// </summary>
        eVAL = 7,
        /// <summary>
        /// 
        /// </summary>
        eVAN = 6,
        /// <summary>
        /// 
        /// </summary>
        eVAS = 5,
        /// <summary>
        /// 
        /// </summary>
        eVOR = 14,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum MapSymbolType
    {
        /// <summary>
        /// 
        /// </summary>
        eNO_SYMBOL = 0,
        /// <summary>
        /// 
        /// </summary>
        eONLY_CONTROLLED = 3,
        /// <summary>
        /// 
        /// </summary>
        eSYMBOL = 1,
        /// <summary>
        /// 
        /// </summary>
        eSYMBOL_AND_LABEL = 2,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum MovedBy
    {
        /// <summary>
        /// 
        /// </summary>
        eExternal = 2,
        /// <summary>
        /// 
        /// </summary>
        eMoveServer = 1,
        /// <summary>
        /// 
        /// </summary>
        eUnknown = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum PositionKind
    {
        /// <summary>
        /// 
        /// </summary>
        eAir = 2,
        /// <summary>
        /// 
        /// </summary>
        eGround = 0,
        /// <summary>
        /// 
        /// </summary>
        eLanding = 4,
        /// <summary>
        /// 
        /// </summary>
        eLandingAir = 5,
        /// <summary>
        /// 
        /// </summary>
        eSea = 1,
        /// <summary>
        /// 
        /// </summary>
        eTakeOff = 3,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum SpeedType
    {
        /// <summary>
        /// Indicated Air Speed
        /// </summary>
        eIAS = 2,
        /// <summary>
        /// True Air Speed
        /// </summary>
        eTAS = 1,
        /// <summary>
        /// 
        /// </summary>
        eUnknown = 0,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum TurnDirection
    {
        /// <summary>
        /// 
        /// </summary>
        eClosest = 0,
        /// <summary>
        /// 
        /// </summary>
        eLeft = 2,
        /// <summary>
        /// 
        /// </summary>
        eRight = 1,
    }

    /// <summary>
    /// 
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// 
        /// </summary>
        eMETRIC = 1,
        /// <summary>
        /// 
        /// </summary>
        eNAUTIC = 0,
    }

}
