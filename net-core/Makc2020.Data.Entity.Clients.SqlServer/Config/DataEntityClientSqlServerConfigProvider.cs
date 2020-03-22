//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Data.Entity.Clients.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. SQL Server. Конфигурация. Поставщик.
    /// </summary>
    public class DataEntityClientSqlServerConfigProvider : CoreBaseCommonConfigProviderJson<DataEntityClientSqlServerConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public DataEntityClientSqlServerConfigProvider(
            DataEntityClientSqlServerConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
