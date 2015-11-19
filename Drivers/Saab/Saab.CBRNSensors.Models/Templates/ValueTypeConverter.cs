using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Xml;
using STS.WISE;

namespace <#CompanyName#>.<#FileName#>.Models
{
    /// <summary>
    /// Static class for type conversions between XSD types and WISE representation.
    /// The XSD types are automatically created by the WSDL import component.
    /// The conversion methods are named as follows;
    /// <list type="table">
    ///     <listheader>
    ///         <term>Method name</term><description>Description</description>
    ///     </listheader>
    ///     <item>
    ///         <term>Decode&lt;XSD type&gt;(...)</term><description>Decodes data from the web service to the corresponding WISE representation.</description>
    ///     </item>
    ///     <item>
    ///         <term>Encode&lt;XSD type&gt;(...)</term><description>Encodes data from the WISE to the corresponding web service representation.</description>
    ///     </item>
    /// </list>
    /// </summary>
    public static class ValueTypeConverter
    {
        #region Simple data types
        public static byte Decodeboolean(Boolean value)
        {
            if(value)
            {
                return 1;
            }
            return 0;
        }
        public static Boolean Encodeboolean(byte value)
        {
            return (value != 0);
        }

        public static byte Decodebyte(Byte value)
        {
            return (byte)value;
        }
        public static Byte Encodebyte(byte value)
        {
            return (Byte)value;
        }

        public static string Decodedecimal(Decimal value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
        public static Decimal Encodedecimal(string value)
        {
            return Decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        public static double Decodedouble(Double value)
        {
            return value;
        }
        public static Double Encodedouble(double value)
        {
            return value;
        }

        public static double Decodefloat(Single value)
        {
            return System.Convert.ToDouble(value);
        }
        public static Single Encodefloat(double value)
        {
            return System.Convert.ToSingle(value);
        }

        public static int Decodeint(Int32 value)
        {
            return value;
        }
        public static Int32 Encodeint(int value)
        {
            return value;
        }

        public static long Decodeinteger(Decimal value)
        {
            return Decimal.ToInt64(value);
        }
        public static Decimal Encodeinteger(long value)
        {
            return value;
        }

        public static long Decodelong(Int64 value)
        {
            return value;
        }
        public static Int64 Encodelong(long value)
        {
            return value;
        }

        public static long DecodenegativeInteger(Decimal value)
        {
            return Decimal.ToInt64(value);
        }
        public static Decimal EncodenegativeInteger(long value)
        {
            return value;
        }

        public static long DecodenonNegativeInteger(Decimal value)
        {
            return Decimal.ToInt64(value);
        }
        public static Decimal EncodenonNegativeInteger(long value)
        {
            return value;
        }

        public static long DecodenonPositiveInteger(Decimal value)
        {
            return Decimal.ToInt64(value);
        }
        public static Decimal EncodenonPositiveInteger(long value)
        {
            return value;
        }

        public static long DecodepositiveInteger(Decimal value)
        {
            return Decimal.ToInt64(value);
        }
        public static Decimal EncodepositiveInteger(long value)
        {
            return value;
        }

        public static int Decodeshort(Int16 value)
        {
            return Convert.ToInt32(value);
        }
        public static Int16 Encodeshort(int value)
        {
            return Convert.ToInt16(value);
        }

        public static string Decodestring(string value)
        {
            return value;
        }
        public static string Encodestring(string value)
        {
            return value;
        }

        public static byte DecodeunsignedByte(Byte value)
        {
            return value;
        }
        public static Byte EncodeunsignedByte(byte value)
        {
            return value;
        }

        public static int DecodeunsignedInt(UInt32 value)
        {
            return (int)value;
        }
        public static UInt32 EncodeunsignedInt(int value)
        {
            return (UInt32)value;
        }

        public static long DecodeunsignedLong(UInt64 value)
        {
            return (long)value;
        }
        public static UInt64 EncodeunsignedLong(long value)
        {
            return (UInt64)value;
        }

        public static int DecodeunsignedShort(UInt16 value)
        {
            return Convert.ToInt32(value);
        }
        public static UInt16 EncodeunsignedShort(int value)
        {
            return Convert.ToUInt16(value);
        }

        #endregion

        #region Name / ID data types
        public static string DecodeanyUri(System.Uri uri)
        {
            if (uri != null)
            {
                return uri.ToString();
            }
            return string.Empty;
        }
        public static Uri EncodeanyUri(string uri)
        {
            if (uri != null)
            {
                return new Uri(uri);
            }
            return null;
        }

        public static string DecodeENTITY(String value)
        {
            return value;
        }
        public static String EncodeENTITY(string value)
        {
            return value;
        }

        public static string DecodeID(String value)
        {
            return value;
        }
        public static String EncodeID(string value)
        {
            return value;
        }

        public static string DecodeIDREF(String value)
        {
            return value;
        }
        public static String EncodeIDREF(string value)
        {
            return value;
        }

        public static string DecodeName(string value)
        {
            return value;
        }
        public static string EncodeName(string value)
        {
            return value;
        }

        public static string DecodeNCName(string value)
        {
            return value;
        }
        public static string EncodeNCName(string value)
        {
            return value;
        }

        public static string DecodeNMTOKEN(String value)
        {
            return value;
        }
        public static String EncodeNMTOKEN(string value)
        {
            return value;
        }

        public static string DecodeQName(XmlQualifiedName value)
        {
            return value.ToString();
        }
        public static XmlQualifiedName EncodeQName(string value)
        {
            return new XmlQualifiedName(value);
        }
        #endregion

        #region Date / Time converstions
        public static string Decodedate(DateTime value)
        {
            // Use XSD date format "yyyy-mm-dd%K"?
            return value.ToString("u");
        }
        public static DateTime Encodedate(string value)
        {
            // We explicitly do not check for a null string
            // since this is an error and should be handled 
            // as such by the caller.
            return DateTime.Parse(value);
        }

        public static string DecodedateTime(DateTime value)
        {
            return value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss%K");
        }
        public static DateTime EncodedateTime(string value)
        {
            // We explicitly do not check for a null string
            // since this is an error and should be handled 
            // as such by the caller.
            return DateTime.ParseExact(value, "yyyy'-'MM'-'dd'T'HH':'mm':'ss%K", CultureInfo.InvariantCulture);
        }

        public static string DecodegDay(DateTime value)
        {
            return value.ToString("'---'dd%K");
        }
        public static DateTime EncodegDay(string value)
        {
            return DateTime.ParseExact(value, "---dd%K", CultureInfo.InvariantCulture);
        }

        public static string DecodegMonthDay(DateTime value)
        {
            return value.ToString("'--'MM'-'dd%K");
        }
        public static DateTime EncodegMonthDay(string value)
        {
            return DateTime.ParseExact(value, "'--'mm'-'dd%K", CultureInfo.InvariantCulture);
        }

        public static string DecodegYear(DateTime value)
        {
            return value.ToString("yyyy%K");
        }
        public static DateTime EncodegYear(string value)
        {
            return DateTime.ParseExact(value, "yyyy%K", CultureInfo.InvariantCulture);
        }

        public static string DecodegYearMonth(DateTime value)
        {
            return value.ToString("yyyy-MM%K");
        }
        public static DateTime EncodegYearMonth(string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM%K", CultureInfo.InvariantCulture);
        }

        public static string Decodemonth(DateTime value)
        {
            return value.ToString("--MM%K");
        }
        public static DateTime Encodemonth(string value)
        {
            return DateTime.ParseExact(value, "--MM%K", CultureInfo.InvariantCulture);
        }

        public static string Decodetime(DateTime value)
        {
            return value.ToString("HH':'mm':'ss'.'fffffffK");
        }
        public static DateTime Encodetime(string value)
        {
            return DateTime.ParseExact(value, "HH':'mm':'ss'.'fffffffK", CultureInfo.InvariantCulture);
        }

        public static string DecodetimePeriod(DateTime value)
        {
            return value.ToString();
        }
        public static DateTime EncodetimePeriod(string value)
        {
            return DateTime.Parse(value);
        }

        public static string Decodeduration(TimeSpan value)
        {
            //PnYnMnDTnHnMnS
            return value.ToString();
        }
        public static TimeSpan Encodeduration(string value)
        {
            return TimeSpan.Parse(value);
        }

        #endregion

        #region BLOB conversions
        public static string Decodebase64Binary(byte[] data)
        {
            if (data != null)
            {
                return System.Convert.ToBase64String(data);
            }
            return null;
        }
        public static byte[] Encodebase64Binary(string data)
        {
            if (data != null)
            {
                return System.Convert.FromBase64String(data);
            }
            return null;
        }

        public static string DecodehexBinary(byte[] data)
        {
            if (data != null)
            {
                return System.Convert.ToBase64String(data);
            }
            return null;
        }
        public static byte[] EncodehexBinary(string data)
        {
            if (data != null)
            {
                return System.Convert.FromBase64String(data);
            }
            return null;
        }

        #endregion

        #region Other
        public static string Decodelanguage(string value)
        {
            return value;
        }
        public static string Encodelanguage(string value)
        {
            return value;
        }

        public static string DecodenormalizedString(string value)
        {
            return value;
        }
        public static string EncodenormalizedString(string value)
        {
            return value;
        }

        public static string DecodeNOTATION(string value)
        {
            return value;
        }
        public static string EncodeNOTATION(string value)
        {
            return value;
        }

        public static string Decodetoken(string value)
        {
            return value;
        }
        public static string Encodetoken(string value)
        {
            return value;
        }

        #endregion

        #region Code generated array conversions
///#### BEGIN FOREACH_ARRAY
///#### BEGIN CONDITION ArrayCSType = STS.WISE.GroupList
        public static <#ArrayCSType#> Decode<#ArrayName#>(<#ArrayElementCSTypeIn#>[] values, AttributeHandle parentAttribute, INETWISEStringCache cache)
        {
            <#ArrayCSType#> outArray = new <#ArrayCSType#>();

            foreach (<#ArrayElementCSTypeIn#> item in values)
            {
                outArray.Add(ValueTypeConverter.Decode<#ArrayElementType#>(item, parentAttribute, cache));
            }
            return outArray;
        }
///#### END CONDITION ArrayCSType = STS.WISE.GroupList
///
///#### END FOREACH_ARRAY
        #endregion

        #region Code generated composite conversions

///#### BEGIN FOREACH_ENUM
        public static int Decode<#EnumName#>(<#EnumName#> value)
        {
            return (int)value;
        }

///#### END FOREACH_ENUM

///#### BEGIN FOREACH_COMPOSITE
        public static AttributeGroup Decode<#CompositeName#>(<#CompositeName#> value, AttributeHandle parentAttribute, INETWISEStringCache cache)
        {
            AttributeGroup outValue = new AttributeGroup();

///#### BEGIN FOREACH_FIELD
            AttributeHandle fieldHandle<#FieldName#> = <#CompositeName#>.GetFieldHandle(<#CompositeName#>.Fields.<#FieldName#>, parentAttribute);
///#### BEGIN CONDITION FieldWISEType = AttributeGroup
            Decode<#FieldDataType#>(outValue,
                                    value.<#FieldName#>, 
                                    fieldHandle<#FieldName#>,
                                    cache);
///#### END CONDITION FieldWISEType = AttributeGroup
///#### BEGIN CONDITION FieldWISEType != AttributeGroup
            outValue.Set(fieldHandle<#FieldName#>, value.<#FieldName#> );
///#### END CONDITION FieldWISEType != AttributeGroup

///#### END FOREACH_FIELD
            return outValue;
        }

        public static void Decode<#CompositeName#>(AttributeGroup parentGroup, <#CompositeName#> value, AttributeHandle parentAttribute, INETWISEStringCache cache)
        {
///#### BEGIN FOREACH_FIELD
            AttributeHandle fieldHandle<#FieldName#> = <#CompositeName#>.GetFieldHandle(<#CompositeName#>.Fields.<#FieldName#>, parentAttribute);
///#### BEGIN CONDITION FieldWISEType = AttributeGroup
            Decode<#FieldDataType#>( parentGroup,
                                     value.<#FieldName#>, 
                                     fieldHandle<#FieldName#>,
                                     cache );
///#### END CONDITION FieldWISEType = AttributeGroup
///#### BEGIN CONDITION FieldWISEType != AttributeGroup
            parentGroup.Set(fieldHandle<#FieldName#>, value.<#FieldName#> );
///#### END CONDITION FieldWISEType != AttributeGroup

///#### END FOREACH_FIELD
        }

///#### END FOREACH_COMPOSITE

///#### BEGIN FOREACH_UNION
        public static AttributeGroup Decode<#CompositeName#>(<#CompositeName#> value, AttributeHandle parentAttribute, INETWISEStringCache cache)
        {
            AttributeGroup outValue = new AttributeGroup();

///#### BEGIN FOREACH_FIELD
            AttributeHandle fieldHandle<#FieldName#> = <#CompositeName#>.GetFieldHandle(<#CompositeName#>.Fields.<#FieldName#>, parentAttribute);
///#### BEGIN CONDITION FieldWISEType = AttributeGroup
            Decode<#FieldDataType#>(outValue,
                                    value.<#FieldName#>, 
                                    fieldHandle<#FieldName#>,
                                    cache);
///#### END CONDITION FieldWISEType = AttributeGroup
///#### BEGIN CONDITION FieldWISEType != AttributeGroup
            outValue.Set(fieldHandle<#FieldName#>, value.<#FieldName#> );
///#### END CONDITION FieldWISEType != AttributeGroup

///#### END FOREACH_FIELD
            return outValue;
        }

        public static void Decode<#CompositeName#>(AttributeGroup parentGroup, <#CompositeName#> value, AttributeHandle parentAttribute, INETWISEStringCache cache)
        {
///#### BEGIN FOREACH_FIELD
            AttributeHandle fieldHandle<#FieldName#> = <#CompositeName#>.GetFieldHandle(<#CompositeName#>.Fields.<#FieldName#>, parentAttribute);
///#### BEGIN CONDITION FieldWISEType = AttributeGroup
            Decode<#FieldDataType#>( parentGroup,
                                     value.<#FieldName#>, 
                                     fieldHandle<#FieldName#>,
                                     cache );
///#### END CONDITION FieldWISEType = AttributeGroup
///#### BEGIN CONDITION FieldWISEType != AttributeGroup
            parentGroup.Set(fieldHandle<#FieldName#>, value.<#FieldName#> );
///#### END CONDITION FieldWISEType != AttributeGroup

///#### END FOREACH_FIELD
        }

///#### END FOREACH_UNION
        #endregion

        #region Internal helpers
        private static StringList GenericDecodeStringArray(string[] value)
        {
            StringList list = new StringList();
            if (value != null)
            {
                list.AddRange(value);
            }
            return list;
        }
        private static string[] GenericEncodeStringArray(StringList value)
        {
            if (value != null)
            {
                return value.ToArray();
            }
            return null;
        }
        #endregion
    }

}
