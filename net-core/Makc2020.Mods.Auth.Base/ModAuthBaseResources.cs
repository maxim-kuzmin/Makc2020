//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Auth.Base.Settings.Errors;
using Makc2020.Mods.Auth.Base.Settings.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Ресурсы.
    /// </summary>
    public class ModAuthBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModAuthBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModAuthBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public ModAuthBaseResources(
            IStringLocalizer<ModAuthBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModAuthBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModAuthBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModAuthBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
