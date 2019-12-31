//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Security.Claims;

namespace Makc2020.Core.Base.Auth.Types.Jwt
{
    /// <summary>
    /// Ядро. Основа. Аутентификация. Типы. JWT. Сервис. Интерфейс.
    /// </summary>
    public interface ICoreBaseAuthTypeJwtService
    {
        #region Methods

        /// <summary>
        /// Создать токен доступа.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="userClaims">Утверждения пользователя.</param>
        /// <returns>Токен.</returns>
        string CreateAccessToken(string userId, IEnumerable<Claim> userClaims);

        /// <summary>
        /// Создать токен обновления.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>       
        /// <returns>Токен.</returns>
        string CreateRefreshToken(string userId);

        /// <summary>
        /// Получить идентификатор пользователя по токену обновления.
        /// </summary>
        /// <param name="token">Токен.</param>
        /// <returns>Идентификатор пользователя.</returns>
        string GetUserIdByRefreshToken(string token);

        /// <summary>
        /// Удалить токен обновления.
        /// </summary>
        /// <param name="token">Токен.</param>
        void RemoveRefreshToken(string token);

        #endregion Methods
    }
}
