//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Makc2020.Core.Base.Common.Config.Providers
{
    /// <summary>
    /// Ядро. Основа. Общее. Конфигурация. Поставщики. JSON.
    /// </summary>
    /// <typeparam name="TSettings">Тип настроек.</typeparam>
    public class CoreBaseCommonConfigProviderJson<TSettings> : CoreBaseCommonConfigProvider<TSettings>
    {
        #region Properties

        private CoreBaseEnvironment Environment { get; set; }

        private string FilePath { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public CoreBaseCommonConfigProviderJson(
            TSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings)
        {
            Environment = environment;
            FilePath = filePath;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Load()
        {
            var configurationBuilder = new ConfigurationBuilder();

            var isAbsolutePath = FilePath.StartsWith(
                Environment.BasePath,
                StringComparison.InvariantCultureIgnoreCase
                );

            var absolutePathToFile = isAbsolutePath
                ? FilePath
                : Path.Combine(Environment.BasePath, FilePath);

            var isPathToFileWithExtension = FilePath.EndsWith(
                ".json",
                StringComparison.InvariantCultureIgnoreCase
                );

            if (isPathToFileWithExtension)
            {
                configurationBuilder.AddJsonFile(absolutePathToFile);
            }
            else
            {
                configurationBuilder.CoreBaseExtConfigAddFromJsonFile(
                    absolutePathToFile,
                    Environment.Name
                    );
            }

            configurationBuilder.Build().Bind(Settings);
        }

        /// <inheritdoc/>
        public sealed override void Save()
        {
            var contents = Settings.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForConfig);

            File.WriteAllText(FilePath, contents);
        }

        #endregion Public methods
    }
}
