using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace CommonTools
{
    public static class XMLChk
    {
        public static string GetAttributeValue(this XElement oX, string Path, string AttributeName)
        {
            string Value = "";

            try
            {
                Value = ValChk.Cast<string>(oX.XPathSelectElement(Path).Attribute(AttributeName).Value);
            }
            catch (Exception ex)
            {
                Value = "";
            }

            return Value;
        }


        public static string GetElemValue(this XElement oX, string Path, XmlNamespaceManager NameSpaceManager)
        {
            string Value = "";

            try
            {
                if (NameSpaceManager != null)
                {
                    Value = ValChk.Cast<string>(oX.XPathSelectElement(Path, NameSpaceManager).Value);
                }
                else
                {
                    Value = ValChk.Cast<string>(oX.XPathSelectElement(Path).Value);
                }

            }
            catch (Exception ex)
            {
                Value = "";
            }

            return Value;
        }



        public static string GetElemValue(this XElement oX, string Path)
        {
            string Value = "";


            try
            {
                Value = ValChk.Cast<string>(oX.XPathSelectElement(Path).Value);
            }
            catch (Exception ex)
            {
                Value = "";
            }

            return Value;
        }




        public static string GetElemValue(this XElement oX, string Path, string DefaultValue)
        {
            string Value = "";

            try
            {
                Value = ValChk.CastValueType<string>(oX.XPathSelectElement(Path).Value, DefaultValue);
            }
            catch (Exception ex)
            {
                Value = "";
            }
            return Value;
        }

        public static string GetElemValueBit(this XElement oX, string Path)
        {
            string Value = "0";

            try
            {
                Value = ValChk.CastValueType<string>(oX.XPathSelectElement(Path).Value, Value);
            }
            catch (Exception ex)
            {
                Value = "";
            }

            if (Value.ToUpper() == "YES" || Value.ToUpper() == "TRUE" || Value.ToUpper() == "1")
            {
                Value = "1";
            }
            else
            {
                Value = "0";
            }


            return Value;
        }

        public static string GetElemValue(this XElement oX, string[] Paths)
        {
            string Value = "";
            int Count = Paths.Count();


            foreach (string Path in Paths)
            {
                try
                {
                    Value = ValChk.Cast<string>(oX.XPathSelectElement(Path).Value);
                }
                catch (Exception ex)
                {
                    Value = "";
                }

                if (!string.IsNullOrWhiteSpace(Value))
                {
                    break;
                }
            }

            return Value;
        }


        public static string GetCombineElemValue(this XElement oX, string parPath, string Datatype)
        {
            string Value = "";
            double DblValue = 0;
            string[] Paths = parPath.Split('~');
            int Count = Paths.Count();


            foreach (string Path in Paths)
            {
                try
                {
                    if (Datatype == "STR")
                    {
                        Value = Value + ValChk.Cast<string>(oX.XPathSelectElement(Path).Value);
                    }
                    else
                    {
                        DblValue = DblValue + ValChk.CastValueType<double>(oX.XPathSelectElement(Path).Value, 0);
                        Value = DblValue.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Value = "";
                }

            }

            return Value;
        }
    }
}
