using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QuadroSoft.Enose.DataModel
{
    public class Error
    {
        public static string errorfile = "./errors.log";
        public static string divider = "\r\n------------------------------------------------\r\n";

        /// <summary>
        /// Запись ошибок
        /// </summary>
        /// <param name="text">текст ошибки</param>
        /// <returns></returns>
        public static void Log(string text)
        {
            try
            {
                File.AppendAllText(errorfile, DateTime.Now.ToString() + " >> " + text + divider);
            }
            catch { }
        }

        /// <summary>
        /// Запись Exception'ов в файл
        /// </summary>
        /// <param name="ex">объект исключения</param>
        public static void Log(Exception ex)
        {
            if (ex != null)
            {
                string logtext = ex.Source + " threw ['" + ex.Message + "'] at ";

                if (ex.TargetSite.ReflectedType != null)
                    logtext += ex.TargetSite.ReflectedType.ToString() + "." + ex.TargetSite.Name;
                else
                    logtext += "nowhere";
                Log(logtext);
            }
        }
    }
}
