//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Auth.Enums;
using Makc2020.Mods.Auth.Base.Config.Settings;

namespace Makc2020.Mods.Auth.Base.Config
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки.
    /// </summary>
    public class ModAuthBaseConfigSettings : IModAuthBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Тип.
        /// </summary>
        public CoreBaseAuthEnumTypes Type { get; set; }

        /// <inheritdoc/>
        CoreBaseAuthEnumTypes IModAuthBaseConfigSettings.Type => Type;

        /// <summary>
        /// Типы.
        /// </summary>
        public ModAuthBaseConfigSettingTypes Types { get; set; }

        /// <inheritdoc/>
        IModAuthBaseConfigSettingTypes IModAuthBaseConfigSettings.Types => Types;

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IModAuthBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new ModAuthBaseConfigSettings();

            var configProvider = new ModAuthBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            result.Init();

            return result;
        }

        /// <summary>
        /// Инициализировать.
        /// </summary>
        internal void Init()
        {
            Types.Init();
        }

        #endregion Internal methods
    }
}