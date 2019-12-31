//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth.Config;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Контекст.
    /// </summary>
    public class HostBasePartAuthContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public HostBasePartAuthJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public HostBasePartAuthResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public HostBasePartAuthService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public HostBasePartAuthContext(
            IHostBasePartAuthConfigSettings configSettings,
            HostBasePartAuthExternals externals
            )
        {
            Resources = new HostBasePartAuthResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new HostBasePartAuthService(configSettings);

            Jobs = new HostBasePartAuthJobs(
                externals.CoreBaseResourceErrors,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
