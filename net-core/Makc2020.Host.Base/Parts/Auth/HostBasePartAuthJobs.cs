//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Jobs.CurrentUser.Get;
using Makc2020.Host.Base.Parts.Auth.Jobs.Seed;
using Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания.
    /// </summary>
    public class HostBasePartAuthJobs
    {
        #region Properties

        /// <summary>
        /// Задание на получение текущего пользователя.
        /// </summary>
        public HostBasePartAuthJobCurrentUserGetService JobCurrentUserGet { get; private set; }

        /// <summary>
        /// Задание на посев.
        /// </summary>
        public HostBasePartAuthJobSeedService JobSeed { get; private set; }

        /// <summary>
        /// Задание на создание сущности пользователя.
        /// </summary>
        public HostBasePartAuthJobUserEntityCreateService JobUserEntityCreate { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public HostBasePartAuthJobs(
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartAuthResourceSuccesses resourceSuccesses,
            HostBasePartAuthResourceErrors resourceErrors,
            HostBasePartAuthService service
            )
        {
            JobCurrentUserGet = new HostBasePartAuthJobCurrentUserGetService(
                service.GetCurrentUser,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );

            JobSeed = new HostBasePartAuthJobSeedService(
                service.Seed,
                coreBaseResourceErrors,
                resourceErrors
                );

            JobUserEntityCreate = new HostBasePartAuthJobUserEntityCreateService(
                service.CreateUserEntity,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors
                );
        }

        #endregion Constructor
    }
}
