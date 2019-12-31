//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Контекст.
    /// </summary>
    public class ModAuthBaseContext
    {
        #region Properties        

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAuthBaseConfig Config { get; private set; }

        /// <summary>
        /// Задания.
        /// </summary>
        public ModAuthBaseJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModAuthBaseResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModAuthBaseService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModAuthBaseContext(ModAuthBaseConfig config, ModAuthBaseExternals externals)
        {
            Config = config;

            Resources = new ModAuthBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            var jwtService = new CoreBaseAuthTypeJwtService(Config.Settings.Types.Jwt);

            Service = new ModAuthBaseService(jwtService);

            Jobs = new ModAuthBaseJobs(
                externals.CoreBaseResourceErrors,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
