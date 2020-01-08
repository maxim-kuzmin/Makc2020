//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Config
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Конфигурация. Настройки.
    /// </summary>
    public interface IModIdentityServerWebMvcPartAccountConfigSettings
    {
        #region Properties

        /// <summary>
        /// Признак разрешения локального входа в систему.
        /// </summary>
        bool AllowLocalLogin { get; }

        /// <summary>
        /// Признак разрешения запоминания входа в систему.
        /// </summary>
        bool AllowRememberLogin { get; }

        /// <summary>
        /// Длительность запоминания входа в систему в днях.
        /// </summary>
        int RememberLoginDurationInDays { get; }

        /// <summary>
        /// Признак необходимости показать напоминание о выходе из системы.
        /// </summary>
        bool ShowLogoutPrompt { get; }

        /// <summary>
        /// Признак необходимости автоматического перенаправления после выхода из системы.
        /// </summary>
        bool AutomaticRedirectAfterSignOut { get; }

        /// <summary>
        /// Имя схемы аутентификации Windows.
        /// </summary>
        string WindowsAuthenticationSchemeName { get; }

        /// <summary>
        /// Признак необходимости включения групп Windows.
        /// </summary>
        bool IncludeWindowsGroups { get; }

        #endregion Properties
    }
}