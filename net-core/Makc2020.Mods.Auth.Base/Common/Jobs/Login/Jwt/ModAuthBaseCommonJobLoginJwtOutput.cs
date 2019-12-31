//Author Maxim Kuzmin//makc//

namespace Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt
{
    /// <summary>
    /// Мод "Auth". Основа. Общее. Задания. Вход в систему. JWT. Вывод.
    /// </summary>
    public class ModAuthBaseCommonJobLoginJwtOutput : ModAuthBaseCommonJobLoginOutput
    {
        #region Properties

        /// <summary>
        /// Токен доступа.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Токен обновления.
        /// </summary>
        public string RefreshToken { get; set; }

        #endregion Properties
    }
}
