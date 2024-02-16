using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonTools
{
    public static partial class ValChk
    {


        public static bool IsValidSqlDateTime(object Date)
        {
            try
            {
                if (Date != null)
                {
                    System.Data.SqlTypes.SqlDateTime.Parse(Date.ToString());
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public static DateTime? GetValidSqlDateTime(DateTime? Date)
        {

            if (IsValidSqlDateTime(Date) == false)
            {
                Date = null;
            }

            return Date;
        }


        public static U GetProperty<T, U>(T oClass, string Name, U defValue)
        {
            U Value = defValue;

            try
            {
                PropertyInfo oProp = oClass.GetType().GetProperty(Name, BindingFlags.Public | BindingFlags.Instance);


                if (oProp != null)
                {
                    Value = (U)oProp.GetValue(oClass, null);
                }
            }
            catch
            {
                throw;
            }

            return Value;
        }


        public static void SetProperty<T>(T oClass, string Name, object value)
        {
            //U Value = defValue;
            try
            {
                PropertyInfo oProp = oClass.GetType().GetProperty(Name, BindingFlags.Public | BindingFlags.Instance);

                if (oProp != null)
                {
                    if (oProp.PropertyType == typeof(Int32))
                    {
                        oProp.SetValue(oClass, CastValueType<Int32>(value, 0), null);
                    }
                    else if (oProp.PropertyType == typeof(string))
                    {
                        oProp.SetValue(oClass, CastValueType<string>(value, ""), null);
                    }
                    else if (oProp.PropertyType == typeof(bool))
                    {
                        oProp.SetValue(oClass, CastValueType<bool>(value, false), null);
                    }
                    else if (oProp.PropertyType == typeof(Decimal))
                    {
                        oProp.SetValue(oClass, CastValueType<decimal>(value, 0), null);
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public static U GetProperty<T, U>(T oClass, string Name)
        {
            U Value = default(U);

            try
            {
                PropertyInfo oProp = oClass.GetType().GetProperty(Name, BindingFlags.Public | BindingFlags.Instance);

                if (oProp != null)
                {
                    Value = CastValueType<U>(oProp.GetValue(oClass, null), Value);
                }
            }
            catch
            {
                throw;
            }

            return Value;
        }


        public static U Cast<U>(object TmpValue)
        {
            object DefValue = "";
            U Value;

            try
            {

                if (typeof(U) == typeof(Int32)) { DefValue = 0; }
                else if (typeof(U) == typeof(long)) { DefValue = Convert.ToInt64(0); }
                else if (typeof(U) == typeof(Int64)) { DefValue = Convert.ToInt64(0); }
                else if (typeof(U) == typeof(bool)) { DefValue = false; }
                else if (typeof(U) == typeof(string)) { DefValue = ""; }
                else if (typeof(U) == typeof(double)) { DefValue = 0.0; }
                else if (typeof(U) == typeof(decimal)) { DefValue = Convert.ToDecimal(0.00); }
                else if (typeof(U) == typeof(DateTime)) { DefValue = new DateTime(1900, 1, 1); }

                Value = (U)DefValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CastValueType<U>(TmpValue, Value);
        }


        public static U CastValueType<U>(object TmpValue, U Value)
        {
            try
            {
                if (TmpValue != null)
                {
                    if (!string.IsNullOrWhiteSpace(TmpValue.ToString()))
                    {
                        if (typeof(U) == typeof(Int32)) { TmpValue = Convert.ToInt32(TmpValue); }
                        else if (typeof(U) == typeof(long)) { TmpValue = Convert.ToInt64(TmpValue); }
                        else if (typeof(U) == typeof(Int64)) { TmpValue = Convert.ToInt64(TmpValue); }
                        else if (typeof(U) == typeof(bool)) { TmpValue = Convert.ToBoolean(TmpValue); }
                        else if (typeof(U) == typeof(string)) { TmpValue = Convert.ToString(TmpValue); }
                        else if (typeof(U) == typeof(double)) { TmpValue = Convert.ToDouble(TmpValue); }
                        else if (typeof(U) == typeof(decimal)) { TmpValue = Convert.ToDecimal(TmpValue); }
                        else if (typeof(U) == typeof(DateTime))
                        {
                            if (IsDate(TmpValue)) { TmpValue = Convert.ToDateTime(TmpValue); }
                            else { TmpValue = Value; }
                        }

                        Value = (U)TmpValue;
                    }
                }
            }
            catch
            {
                //throw;
            }

            return Value;
        }


        public static string DateFormat(Object oDat, string DefaultVal)
        {
            string strDate = DefaultVal;

            if (IsDate(oDat))
            {
                strDate = ((DateTime)oDat).ToString("MM/dd/yyyy");
            }

            return strDate;
        }

        public static string DateFormat(string ODat, string Format)
        {
            string strDate = "";

            if (!string.IsNullOrWhiteSpace(ODat))
            {
                try
                {
                    DateTime ODatetime;

                    if (DateTime.TryParse(ODat, out ODatetime))
                    {
                        strDate = ODatetime.ToString(Format);
                    }
                }
                catch
                {
                    throw;
                }
            }

            return strDate;
        }

        public static string DateTimeFormat(Object oDat, string DefaultVal)
        {
            string strDate = DefaultVal;

            if (IsDate(oDat))
            {
                strDate = ((DateTime)oDat).ToString("MM/dd/yyyy hh:mm tt");
            }

            return strDate;
        }

        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            bool IsValid = false;
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                {
                    if (dt > new DateTime(2000, 1, 1))
                    {
                        IsValid = true;
                    }
                }
            }
            catch
            {
                throw;
            }

            return IsValid;
        }

        public static string GetEnumName<T>(string parVal)
        {
            string Name = parVal;
            string[] Names = Enum.GetNames(typeof(T));

            for (int i = 0; i < Names.Length; i++)
            {
                if (Names[i].Contains(parVal))
                {
                    Name = Names[i];
                }
            }

            return Name;
        }


        public static bool IsValidJson(string strInput)
        {
            if (strInput is null) { return false; }

            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Author: Julius
        // Create date: 03262021
        // Description: #56 Sprint4
        public static bool Compare<U>(U value1, U value2, U defaultValue)
        {
            bool result = false;

            U tmpValue1 = value1 != null ? value1 : defaultValue;
            U tmpValue2 = value2 != null ? value2 : defaultValue;

            if (tmpValue1.Equals(tmpValue2))
            {
                result = true;
            }

            return result;
        }

        public static U CastDefaultIf<U, T>(object value1, object value2, U defaultValue)
        {
            U result = Cast<U>(value1);

            if (typeof(T) == typeof(string))
            {
                result = CompareString(value1, value2, "") ? defaultValue : result;
            }
            else if (typeof(T) == typeof(int))
            {
                result = CompareInt(value1, value2) ? defaultValue : result;
            }
            else if (typeof(T) == typeof(decimal))
            {
                result = CompareDecimal(value1, value2) ? defaultValue : result;
            }

            return result;
        }

        public static bool CompareString(object value1, object value2, string defaultVal)
        {
            bool result = false;

            if (CastValueType<string>(value1, defaultVal) == CastValueType<string>(value2, defaultVal))
            {
                result = true;
            }

            return result;
        }

        private static bool CompareInt(object value1, object value2)
        {
            bool result = false;

            if (Cast<int>(value1) == Cast<int>(value2))
            {
                result = true;
            }

            return result;
        }

        private static bool CompareDecimal(object value1, object value2)
        {
            bool result = false;

            if (Cast<decimal>(value1) == Cast<decimal>(value2))
            {
                result = true;
            }

            return result;
        }

        public static string Trim(string value)
        {
            string result = value;

            if (value != null)
            {
                result = Regex.Replace(value, @"\s+", "");
            }

            return result;
        }

        public static bool FileExist(string FullFileName)
        {
            bool result = false;

            try
            {
                if (File.Exists(FullFileName))
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> List)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in List)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static MemberInfo[] GetMemberInfoByAttribute<T, U>(IList<T> Source)
        {
            return typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !Attribute.IsDefined(p, typeof(U)))
                .ToArray();
        }

        public static bool IsAlphaNumeric(string value)
        {
            bool isAlphaNum = false;

            var regexItem = new Regex("^[a-zA-Z0-9]*$");

            if (regexItem.IsMatch(value))
            {
                isAlphaNum = true;
            }

            return isAlphaNum;
        }
    }
}
