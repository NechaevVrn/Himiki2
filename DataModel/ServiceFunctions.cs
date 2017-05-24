using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace QuadroSoft.Enose.DataModel
{
    public class ServiceFunctions
    {
        private static string TP_INT = "int";
        private static string TP_DOUBLE = "double";
        //private static string TP_STRING = "string";
        private static string TP_FLOAT = "float";
        private static string TP_BOOL = "bool";

        public static char wrongsep = '.';
        public static char rightsep = ',';

        /// <summary>
        /// Парсинг xml с синтаксисом <br/>
        /// &lt;settings&gt;<br/>
        ///     &lt;имя_параметра1 type='int|bool|double|float|string'&gt;значение параметра&lt;/имя_параметра1&gt;<br/>
        ///     &lt;имя_параметра2 type='int|bool|double|float|string'&gt;значение параметра&lt;/имя_параметра2&gt;<br/>
        /// &lt;/settings&gt;
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static Dictionary<string, object> parseProperties(string properties)
        {
            Dictionary<string, object> result = new Dictionary<string,object>();

            if (properties == null || properties.Trim() == "")  return result;

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(properties);
            XmlNode thenode = xdoc.GetElementsByTagName("settings")[0];

            foreach (XmlNode node in thenode.ChildNodes)
            {
                string name = node.Name;

                string nodetype = "";
                try
                {
                    nodetype = node.Attributes["type"].Value.ToLower();
                }
                catch { }

                string value = node.InnerText;

                if (nodetype == TP_DOUBLE)
                {
                    value = value.Replace(wrongsep, rightsep);
                    result.Add(name, Double.Parse(value));
                }
                else if (nodetype == TP_BOOL)
                    result.Add(name, Boolean.Parse(value));
                else if (nodetype == TP_FLOAT)
                {
                    value = value.Replace(wrongsep, rightsep);
                    result.Add(name, float.Parse(value));
                }
                else if (nodetype == TP_INT)
                    result.Add(name, Int32.Parse(value));
                else
                    result.Add(name, value);
            }

            return result;
        }

        public static string serializeProperties(Dictionary<string, object> properties)
        {
            string result = "<settings>";
            foreach (string tagname in properties.Keys)
            {
                
                string tag = "  <" + tagname + " ";
                string thetype = "?";
                object o = properties[tagname];
                
                if (o.GetType().Equals(typeof(Int32)))
                    thetype = "int";
                else if (o.GetType().Equals(typeof(Double)))
                    thetype = "double";
                else if (o.GetType().Equals(typeof(Single)))
                    thetype = "float";
                else if (o.GetType().Equals(typeof(Boolean)))
                    thetype = "bool";

                tag += " type=\"" + thetype + "\">";
                tag += o.ToString() + "</" + tagname + ">\r\n";
                result += tag;
            }



            result += "</settings>";
            return result;
        }

    }
}
