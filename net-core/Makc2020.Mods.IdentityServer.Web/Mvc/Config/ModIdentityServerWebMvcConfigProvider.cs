//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Common.Config.Providers;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Конфигурация. Поставщик.
    /// </summary>
    public class ModIdentityServerWebMvcConfigProvider : CoreBaseCommonConfigProviderJson<ModIdentityServerWebMvcConfigSettings>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="environment">Окружение.</param>
        public ModIdentityServerWebMvcConfigProvider(
            ModIdentityServerWebMvcConfigSettings settings,
            string filePath,
            CoreBaseEnvironment environment
            )
            : base(settings, filePath, environment)
        {
        }

        #endregion Constructors
    }
}
