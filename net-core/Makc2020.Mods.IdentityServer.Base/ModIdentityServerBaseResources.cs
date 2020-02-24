//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.IdentityServer.Base
{
    /// <summary>
    /// Мод "IdentityServer". Основа. Ресурсы.
    /// </summary>
    public class ModIdentityServerBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModIdentityServerBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModIdentityServerBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceTitlesLocalizer">Локализатор ресурсов заголовков.</param>
        public ModIdentityServerBaseResources(
            IStringLocalizer<ModIdentityServerBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModIdentityServerBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModIdentityServerBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModIdentityServerBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
