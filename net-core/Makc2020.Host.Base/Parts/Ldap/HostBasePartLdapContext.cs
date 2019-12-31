//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Ldap.Config;

namespace Makc2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Контекст.
    /// </summary>
    public class HostBasePartLdapContext
    {
        #region Properties

        /// <summary>
        /// Задания.
        /// </summary>
        public HostBasePartLdapJobs Jobs { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public HostBasePartLdapResources Resources { get; private set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public HostBasePartLdapService Service { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="externals">Внешнее.</param>
        public HostBasePartLdapContext(
            IHostBasePartLdapConfigSettings configSettings,
            HostBasePartLdapExternals externals
            )
        {
            Resources = new HostBasePartLdapResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );

            Service = new HostBasePartLdapService(configSettings);

            Jobs = new HostBasePartLdapJobs(
                externals.CoreBaseResourceErrors,
                Resources.Successes,
                Resources.Errors,
                Service
                );
        }

        #endregion Constructor
    }
}
