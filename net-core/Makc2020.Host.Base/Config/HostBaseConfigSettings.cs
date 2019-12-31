//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Host.Base.Parts.Auth.Config;
using Makc2020.Host.Base.Parts.Ldap.Config;

namespace Makc2020.Host.Base.Config
{
    /// <summary>
    /// Хост. Основа. Конфигурация. Настройки.
    /// </summary>
    public class HostBaseConfigSettings : IHostBaseConfigSettings
    {
        #region Properties

        /// <summary>
        /// Часть "Auth".
        /// </summary>
        public HostBasePartAuthConfigSettings PartAuth { get; set; }

        /// <inheritdoc/>
        IHostBasePartAuthConfigSettings IHostBaseConfigSettings.PartAuth => PartAuth;

        /// <summary>
        /// Часть "LDAP".
        /// </summary>
        public HostBasePartLdapConfigSettings PartLdap { get; set; }

        /// <inheritdoc/>
        IHostBasePartLdapConfigSettings IHostBaseConfigSettings.PartLdap => PartLdap;

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Создать.
        /// </summary>
        /// <param name="configFilePath">Путь к файлу конфигурации.</param>
        /// <param name="environment">Окружение.</param>
        /// <returns>Конфигурационные настройки.</returns>
        internal static IHostBaseConfigSettings Create(string configFilePath, CoreBaseEnvironment environment)
        {
            var result = new HostBaseConfigSettings();

            var configProvider = new HostBaseConfigProvider(result, configFilePath, environment);

            configProvider.Load();

            return result;
        }

        #endregion Internal methods
    }
}