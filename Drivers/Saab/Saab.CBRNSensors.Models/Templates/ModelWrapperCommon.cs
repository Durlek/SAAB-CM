using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Xml;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace <#CompanyName#>.<#FileName#>.Models
{
    public enum <#FileName#>EntityTypes
    {
        Unknown,
///#### BEGIN FOREACH_ENTITY            
        <#EntityClassMerged#>,
///#### END FOREACH_ENTITY            
    }

    /// <summary>
    /// Static class for initialization of object end event lookup dictionaries.
    /// </summary>
    public static class Model
    {   
        public static bool InitializeModel(INETWISEDriverSink2 wiseAccess)
        {
            bool bResult = false;
            INETWISEStringCache stringCache = wiseAccess as INETWISEStringCache;
            
            // The UnInitialize call is needed to clear string cache when WISE restarts

///#### BEGIN FOREACH_ENTITY            
            <#EntityClassMerged#>.UnInitialize();
            bResult = <#EntityClassMerged#>.Initialize( stringCache );
                
///#### END FOREACH_ENTITY            

            return bResult;
        }

        public static <#FileName#>EntityTypes GetEntityType(ClassHandle classHandle)
        {
///#### BEGIN FOREACH_ENTITY
            if (<#EntityClassMerged#>.IsTypeOf(classHandle))
            {
                return <#FileName#>EntityTypes.<#EntityClassMerged#>;
            }
///#### END FOREACH_ENTITY
            return <#FileName#>EntityTypes.Unknown;
        }

    }
}
