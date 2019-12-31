//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Внешнее.
    /// </summary>
    public class HostBasePartLdapExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<HostBasePartLdapResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<HostBasePartLdapResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
