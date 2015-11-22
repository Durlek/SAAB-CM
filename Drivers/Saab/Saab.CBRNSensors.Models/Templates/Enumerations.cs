using System;
using System.Collections.Generic;
using System.Text;
using STS.WISE;
using WISE_RESULT = System.UInt32;

namespace <#CompanyName#>.<#FileName#>.Models
{
///#### BEGIN FOREACH_ENUM
    /// <summary>
    /// <#EnumDescription#>
    /// Default value: _<#EnumDefaultvalue#>
    /// </summary>
    public enum <#EnumName#>
    {
///#### BEGIN FOREACH_ENUMVALUE
        /// <summary>
        /// <#EnumValueDescription#>
        /// </summary>
        e<#EnumValueName#> = <#EnumValue#>,
///#### END FOREACH_ENUMVALUE
    }

///#### END FOREACH_ENUM
}
