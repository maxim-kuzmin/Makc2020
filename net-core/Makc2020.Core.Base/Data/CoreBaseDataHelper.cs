//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Data
{
    /// <summary>
    /// Ядро. Основа. Данные. Помощник.
    /// </summary>
    public sealed class CoreBaseDataHelper
    {
        #region Constants

        private const int COMMAND_TIMEOUT = 30;

        #endregion Constants

        #region Properties

        private ICoreBaseDataProvider Provider { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="provider">Провайдер.</param>
        public CoreBaseDataHelper(ICoreBaseDataProvider provider)
        {
            Provider = provider;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Создать параметр команды базы данных.
        /// </summary>
        /// <param name="name">Имя параметра.</param>
        /// <param name="value">Значение параметра.</param>
        /// <returns>Параметр команды базы данных.</returns>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return Provider.CreateDbParameter(name, value);
        }

        /// <summary>
        /// Создать подключение к базе данных.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        /// <returns>Подключение к базе данных.</returns>        
        public DbConnection CreateDbConnection(string connectionString)
        {
            return Provider.CreateDbConnection(connectionString, TransformConnectionString);
        }

        /// <summary>
        /// Выполнить SQL-запрос.
        /// </summary>
        /// <param name="commandType">Тип команды.</param>
        /// <param name="commandText">Текст команды.</param>
        /// <param name="parameters">Параметры.</param>
        /// <param name="executableFunction">Выполняемая функция.</param>
        /// <param name="connection">Соединение с базой данных.</param>
        /// <param name="commandTimeout">Таймаут команды.</param>
        /// <returns>Задача.</returns>
        public async Task ExecuteSql(
            CommandType commandType,
            string commandText,
            DbParameter[] parameters,
            Func<DbCommand, Task> executableFunction,
            DbConnection connection,
            int? commandTimeout
            )
        {
            using (connection)
            {
                await connection.OpenAsync().CoreBaseExtTaskWithCurrentCulture(false);

                using var cmd = CreateDbCommand(connection, parameters);

                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                cmd.CommandTimeout = commandTimeout ?? COMMAND_TIMEOUT;

                await executableFunction.Invoke(cmd).CoreBaseExtTaskWithCurrentCulture(false);
            }
        }

        #endregion Public methods

        #region Private methods

        private DbCommand CreateDbCommand(DbConnection connection, DbParameter[] parameters)
        {
            var result = Provider.CreateDbCommand(connection, parameters);

            if (result == null)
            {
                result = connection.CreateCommand();

                if (parameters != null)
                {
                    result.Parameters.AddRange(parameters);
                }
            }

            return result;
        }

        private string TransformConnectionString(string connectionString)
        {
            var csb = new DbConnectionStringBuilder { ConnectionString = connectionString };

            csb.Add("pooling", true);

            return csb.ConnectionString;
        }

        #endregion Private methods
    }
}