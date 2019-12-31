//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Auth.Types.Oidc
{
    /// <summary>
    /// Ядро. Основа. Аутентификация. Типы. OIDC. Настройки. Интерфейс.
    /// </summary>
    public interface ICoreBaseAuthTypeOidcSettings
    {
        #region Properties

        /// <summary>
        /// Аудитория.
        /// </summary>
        string Audience { get; }

        /// <summary>
        /// Авторитетный источник.
        /// </summary>
        string Authority { get; }

        /// <summary>
        /// Признак необходимости использовать протокол HTTPS.
        /// </summary>
        bool RequireHttpsMetadata { get; }

        #endregion Properties
    }
}