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
        /// Признак разрешения логина пользователя без пароля.
        /// </summary>
        bool AllowLoginWithoutPassword { get; }

        /// <summary>
        /// Признак разрешения запоминания входа в систему.
        /// </summary>
        bool AllowRememberLogin { get; }

        /// <summary>
        /// Признак необходимости автоматического перенаправления после выхода из системы.
        /// </summary>
        bool AutomaticRedirectAfterSignOut { get; }

        /// <summary>
        /// Имя параметра признака первого входа в систему на стороне клиента.
        /// </summary>
        string ClientIsFirstLoginParamName { get; }

        /// <summary>
        /// Значение параметра признака первого входа в систему на стороне клиента.
        /// </summary>
        string ClientIsFirstLoginParamValue { get; }

        /// <summary>
        /// Имя параметра языка на стороне клиента.
        /// </summary>
        string ClientLangParamName { get; }

        /// <summary>
        /// Признак необходимости включения групп Windows.
        /// </summary>
        bool IncludeWindowsGroups { get; }

        /// <summary>
        /// URL-адрес WebApi.
        /// </summary>
        string LogOutRoute { get; }

        /// <summary>
        /// Длительность запоминания входа в систему в днях.
        /// </summary>
        int RememberLoginDurationInDays { get; }

        /// <summary>
        /// Признак необходимости показать напоминание о выходе из системы.
        /// </summary>
        bool ShowLogoutPrompt { get; }

        /// <summary>
        /// URL-адрес WebApi.
        /// </summary>
        string UserSessionCountRoute { get; }

        /// <summary>
        /// URL-адрес WebApi.
        /// </summary>
        string WebApiUrlAddress { get; set; }

        #endregion Properties
    }
}