//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Data.Entity.Clients.PostgreSql.Config
{
    /// <summary>
    /// Данные. Entity Framework. Клиенты. PostgreSQL. Конфигурация. Поставщик.
    /// </summary>
    public class DataEntityClientPostgreSqlConfigProvider : CoreBaseCommonConfigProviderJson<DataEntityClientPostgreSqlConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public DataEntityClientPostgreSqlConfigProvider(
            DataEntityClientPostgreSqlConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
