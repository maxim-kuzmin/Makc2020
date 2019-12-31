//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Data.Entity.SqlServer.Config
{
    /// <summary>
    /// Данные. Entity Framework. База данных MS SQL Server. Конфигурация. Поставщик.
    /// </summary>
    public class DataEntitySqlServerConfigProvider : CoreBaseCommonConfigProviderJson<DataEntitySqlServerConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public DataEntitySqlServerConfigProvider(
            DataEntitySqlServerConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
