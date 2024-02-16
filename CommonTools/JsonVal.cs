using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTools
{
    public static class JsonVal
    {
        public static string GetJValue(string Path, string jData)
        {
            string Value = "";
            string[] ArrKeys = Path.Split("/");
            JObject jOData = JObject.Parse(jData);

            if (ArrKeys.Length == 0) { return Value; };

            try
            {
                foreach (string key in ArrKeys)
                {
                    JToken jResults;
                    if (jOData.TryGetValue(key, out jResults))
                    {
                        if (jResults is JObject)
                        {
                            jOData = JObject.Parse(jResults.ToString());
                        }
                        else if (jResults is JValue)
                        {
                            Value = jResults.Value<string>();
                            break;
                        }
                    }
                }

            }
            catch (Exception) { }

            return Value;
        }


        public static string GetJValue(string Path, string SecondaryPath, string jData)
        {
            string Value = GetJValue(Path, jData);
            Value = string.IsNullOrWhiteSpace(Value) ? GetJValue(SecondaryPath, jData) : Value;

            return Value;
        }
    }
}
