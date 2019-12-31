//Author Maxim Kuzmin//makc//

using Microsoft.IdentityModel.Tokens;

namespace Makc2020.Core.Base.Auth.Types.Jwt
{
    /// <summary>
    /// Ядро. Основа. Аутентификация. Типы. JWT. Настройки. Интерфейс.
    /// </summary>
    public interface ICoreBaseAuthTypeJwtSettings
    {
        #region Properties

        /// <summary>
        /// Эмитент.
        /// </summary>
        string Issuer { get; }

        /// <summary>
        /// Аудитория.
        /// </summary>
        string Audience { get; }

        /// <summary>
        /// Секретный ключ.
        /// </summary>
        string SecretKey { get; }

        /// <summary>
        /// Время жизни в минутах токена доступа.
        /// </summary>
        int TimeToLiveInMinutesOfAccessToken { get; }

        /// <summary>
        /// Время жизни в днях токена обновления.
        /// </summary>
        int TimeToLiveInDaysOfRefreshToken { get; }

        /// <summary>
        /// Ключ подписи.
        /// </summary>
        SymmetricSecurityKey SigningKey { get; }

        #endregion Properties
    }
}