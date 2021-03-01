//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Data.Queries.Identity.Reseed;
using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Data.Base.Clients.PostgreSql.Queries.Identity.Reseed;
using Makc2020.Core.Data.Base.Clients.PostgreSql.Queries.Tree.Calculate;
using Makc2020.Core.Data.Base.Clients.PostgreSql.Queries.Tree.Trigger;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Makc2020.Core.Data.Base.Clients.PostgreSql
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. PostgreSQL. Поставщик.
    /// </summary>
    public class CoreDataBaseClientPostgreSqlProvider : ICoreBaseDataProvider
    {
        #region Public methods

        /// <inheritdoc/>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <inheritdoc/>
        public DbCommand CreateDbCommand(DbConnection connection, DbParameter[] parameters)
        {
            SqlCommand result = null;

            if (!(connection is SqlConnection cn)) return result;

            result = cn.CreateCommand();

            if (parameters == null) return result;

            foreach (var parameter in parameters)
            {
                var par = result.CreateParameter();

                var name = parameter.ParameterName;

                if (!string.IsNullOrEmpty(name))
                {
                    if (!name.StartsWith("@"))
                    {
                        name = "@" + name;
                    }

                    par.ParameterName = name;
                }

                par.Direction = parameter.Direction;

                if (parameter.Value is DataTable val)
                {
                    par.SqlDbType = SqlDbType.Structured;
                    par.TypeName = val.TableName;
                    par.SqlValue = val;

                }
                else
                {
                    par.Value = parameter.Value;
                    par.DbType = parameter.DbType;
                }

                result.Parameters.Add(par);
            }

            return result;
        }

        /// <inheritdoc/>   
        public DbConnection CreateDbConnection(string connectionString, Func<string, string> transformConnectionString = null)
        {
            if (transformConnectionString != null)
            {
                connectionString = transformConnectionString(connectionString);
            }

            return new SqlConnection(connectionString);
        }

        /// <inheritdoc/>
        public CoreBaseDataQueryIdentityReseedBuilder CreateQueryIdentityReseedBuilder()
        {
            return new CoreDataBaseClientPostgreSqlQueryIdentityReseedBuilder();
        }

        /// <inheritdoc/>
        public CoreBaseDataQueryTreeCalculateBuilder CreateQueryTreeCalculateBuilder()
        {
            return new CoreDataBaseClientPostgreSqlQueryTreeCalculateBuilder();
        }

        /// <inheritdoc/>
        public CoreBaseDataQueryTreeTriggerBuilder CreateQueryTreeTriggerBuilder()
        {
            return new CoreDataBaseClientPostgreSqlQueryTreeTriggerBuilder();
        }

        #endregion Public methods
    }
}
