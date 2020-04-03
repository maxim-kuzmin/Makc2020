//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Data.Entity.Config;
using System.IO;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Конфигурация.
    /// </summary>
    public sealed class DataEntityConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IDataEntityConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public DataEntityConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = DataEntityConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Data.Entity.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public DataEntityConfigProvider CreateProvider(DataEntityConfigSettings settings)
        {
            return new DataEntityConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}