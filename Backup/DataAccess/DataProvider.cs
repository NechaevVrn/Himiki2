using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;

namespace QuadroSoft.Enose.DataAccess
{
    /// <summary>
    /// Уровень данных для проекта E-Nose. MS SQL CE 3.5
    /// </summary>
    public partial class DataProvider : IDisposable
    {

        private const string NOT_CODED = "No logics for engine coded";

        public enum DBType { SqlCompact, SqlServer };

        private string errorMessage = "";

        private DBType databaseType;
        
        private string connectionString;
        
        private bool isConnected;
        
        IDbConnection connection;
        
        /// <summary>
        /// Установлено ли подключение к базе
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="connectionString">Строка подключение к базе</param>
        /// <param name="dbtype">тип БД: DataProvider.DBType</param>
        public DataProvider(string connectionString, DBType dbtype)
        {
            isConnected = false;
            this.connectionString = connectionString;
            databaseType = dbtype;
            if (!Connect())
                throw new Exception("Не удалось подключиться к базе: " + errorMessage);
        }

        /// <summary>
        /// Подключение к БД
        /// </summary>
        /// <returns>успешность подключения</returns>
        public bool Connect()
        {
            bool result = true;
            
            try
            {
                if (databaseType == DBType.SqlCompact)
                {
                    connection = new SqlCeConnection(connectionString);
                }
                else if (databaseType == DBType.SqlServer)
                {
                    connection = new SqlConnection(connectionString);
                }
                else
                    throw new Exception(NOT_CODED);

                connection.Open();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Отключение от базы
        /// </summary>
        /// <returns>удачность отключения</returns>
        public bool Disconnect()
        {
            bool result = true;
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                result = false;
            }
            return result;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (IsConnected)
                Disconnect();
        }

        #endregion
    }
}
