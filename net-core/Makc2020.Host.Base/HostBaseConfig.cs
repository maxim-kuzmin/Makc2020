//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Host.Base.Config;
using System.IO;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Конфигурация.
    /// </summary>
    public sealed class HostBaseConfig
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        /// <summary>
        /// Настройки.
        /// </summary>
        public IHostBaseConfigSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="environment">Окружение.</param>
        public HostBaseConfig(CoreBaseEnvironment environment)
        {
            Environment = environment;

            FilePath = CreateFilePath();

            Settings = HostBaseConfigSettings.Create(FilePath, Environment);
        }

        #endregion Constructors

        #region Internal methods

        /// <summary>
        /// Создать путь к файлу.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        internal static string CreateFilePath()
        {
            return Path.Combine("ConfigFiles", "Host.Base.config");
        }

        #endregion Internal methods

        #region Рublic methods

        /// <summary>
        /// Создать поставщика.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public HostBaseConfigProvider CreateProvider(HostBaseConfigSettings settings)
        {
            return new HostBaseConfigProvider(settings, FilePath, Environment);
        }

        #endregion Рublic methods
    }
}