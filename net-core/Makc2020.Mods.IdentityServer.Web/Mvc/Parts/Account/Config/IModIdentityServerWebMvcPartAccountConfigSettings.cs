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
        /// Признак разрешения логина пользователя без пароля.
        /// </summary>
        bool AllowLoginWithoutPassword { get; set; }

        /// <summary>
        /// Признак необходимости автоматического перенаправления после выхода из системы.
        /// </summary>
        bool AutomaticRedirectAfterSignOut { get; set; }

        /// <summary>
        /// Имя параметра признака первого входа в систему на стороне клиента.
        /// </summary>
        string ClientIsFirstLoginParamName { get; set; }

        /// <summary>
        /// Значение параметра признака первого входа в систему на стороне клиента.
        /// </summary>
        string ClientIsFirstLoginParamValue { get; set; }

        /// <summary>
        /// Имя параметра языка на стороне клиента.
        /// </summary>
        string ClientLangParamName { get; set; }

        /// <summary>
        /// Таймаут команд базы данных.
        /// </summary>
        int DbCommandTimeout { get; }

        /// <summary>
        /// Признак необходимости использования автоматической аутентификации Windows.
        /// </summary>
        bool IsWindowsAuthenticationMandatory { get; set; }

        /// <summary>
        /// Имя куки для хранения метода входа в систему.
        /// </summary>
        string LoginMethodCookieName { get; set; }

        /// <summary>
        /// Имя куки для хранения имени вошедшего в систему пользователя.
        /// </summary>
        string LoginUserNameCookieName { get; set; }

        /// <summary>
        /// Длительность запоминания входа в систему в днях.
        /// </summary>
        int RememberLoginDurationInDays { get; set; }

        /// <summary>
        /// Признак необходимости показать напоминание о выходе из системы.
        /// </summary>
        bool ShowLogoutPrompt { get; set; }

        #endregion Properties
    }
}