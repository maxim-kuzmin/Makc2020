//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Base.Config.Enums;
using System.Collections.Generic;

namespace Makc2020.Mods.IdentityServer.Base.Config.Settings
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Конфигурация. Настройки. Клиент. Интерфейс.
    /// </summary>
    public interface IModIdentityServerBaseConfigSettingClient
    {
        #region Properties

        /// <summary>
        /// Разрешённые источники CORS.
        /// </summary>
        ICollection<string> AllowedCorsOrigins { get; }

        /// <summary>
        /// Разрешённые типы разрешений.
        /// </summary>
        ModIdentityServerBaseConfigEnumGrantTypes AllowedGrantTypes { get; }

        /// <summary>
        /// Разрешить доступ офлайн.
        /// </summary>
        bool AllowOfflineAccess { get; }

        /// <summary>
        /// Разрешённые области применения.
        /// </summary>
        ICollection<string> AllowedScopes { get; }

        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        string ClientName { get; }

        /// <summary>
        /// URI клиента.
        /// </summary>
        string ClientUri { get; }

        /// <summary>
        /// Требуется секрет клиента.
        /// </summary>
        bool RequireClientSecret { get; }

        /// <summary>
        /// Требуется согласие.
        /// </summary>
        bool RequireConsent { get; }

        /// <summary>
        /// Требуется ключ подтверждения для обмена кодами.
        /// </summary>
        bool RequirePkce { get; }

        /// <summary>
        /// Список URI перенаправления.
        /// </summary>
        ICollection<string> RedirectUris { get; }

        /// <summary>
        /// Список URI перенаправления после выхода из системы.
        /// </summary>
        ICollection<string> PostLogoutRedirectUris { get; }

        #endregion Properties
    }
}