using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using QuadroSoft.Enose.DataModel;

namespace QuadroSoft.Enose.DataAccess
{
    public partial class DataProvider
    {

        /// <summary>
        /// Выполнить SELECT-запрос
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>DataReader таблицы</returns>
        private IDataReader executeSelect(string query)
        {
            IDbCommand command = null;

            if (databaseType == DBType.SqlCompact)
                command = new SqlCeCommand(query, connection as SqlCeConnection);
            else if (databaseType == DBType.SqlServer)
                command = new SqlCommand(query, connection as SqlConnection);
            else
                throw new Exception(NOT_CODED);

            return command.ExecuteReader();
               
        }

        /// <summary>
        /// Выполнить SELECT-запрос без возвращения результатов
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>affected</returns>
        public int executeNonQuery(string query)
        {
            IDbCommand command = null;

            if (databaseType == DBType.SqlCompact)
                command = new SqlCeCommand(query, connection as SqlCeConnection);
            else if (databaseType == DBType.SqlServer)
                command = new SqlCommand(query, connection as SqlConnection);
            else
                throw new Exception(NOT_CODED);

            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Выполнить SELECT-запрос одним значением
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns>объект значения</returns>
        public object executeScalar(string query)
        {
            IDbCommand command = null;

            if (databaseType == DBType.SqlCompact)
                command = new SqlCeCommand(query, connection as SqlCeConnection);
            else if (databaseType == DBType.SqlServer)
                command = new SqlCommand(query, connection as SqlConnection);
            else
                throw new Exception(NOT_CODED);

            return command.ExecuteScalar();
        }

        public static void createCompactDB(string cs)
        {
            SqlCeEngine engine = new SqlCeEngine(cs);
            engine.CreateDatabase();
        }

        private string qouted(string str)
        {
            return str != null? "'" + str.Replace("'", " ").Replace("`", " ") + "'" : "NULL";
        }

        private string deNullID(int ID)
        {
            return ID > -1 ? ID.ToString() : "NULL";
        }

        private string deNullObject(object o)
        {
            return o != null ? o.ToString() : "NULL";
        }

        private string deNullMaskID(Mask m)
        {
            return m == null ? "NULL" : m.ID.ToString();
        }

        public void delete(string from, string where)
        {
            try
            {
                executeNonQuery("DELETE FROM " + from + " WHERE " + where);
            }
            catch { }
        }
    }
}
