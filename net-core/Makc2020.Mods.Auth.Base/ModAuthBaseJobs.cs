//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt;
using Makc2020.Mods.Auth.Base.Jobs.Register;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Successes;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Задания.
    /// </summary>
    public class ModAuthBaseJobs
    {
        #region Properties

        /// <summary>
        /// Задание на вход в систему с помощью JWT-токена авторизации.
        /// </summary>
        public ModAuthBaseJobLoginJwtService JobLoginJwt { get; private set; }

        /// <summary>
        /// Задание на обновление JWT-токена авторизации.
        /// </summary>
        public ModAuthBaseJobRefreshJwtService JobRefreshJwt { get; private set; }

        /// <summary>
        /// Задание на регистрацию.
        /// </summary>
        public ModAuthBaseJobRegisterService JobRegister { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModAuthBaseJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAuthBaseResourceSuccesses resourceSuccesses,
            ModAuthBaseResourceErrors resourceErrors,
            ModAuthBaseService service
            )
        {
            JobLoginJwt = new ModAuthBaseJobLoginJwtService(
                service.JwtLogin,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );

            JobRefreshJwt = new ModAuthBaseJobRefreshJwtService(
                service.JwtRefresh,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );

            JobRegister = new ModAuthBaseJobRegisterService(
                service.Register,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );
        }

        #endregion Constructor
    }
}
