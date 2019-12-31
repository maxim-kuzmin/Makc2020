//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Host.Base.Parts.Auth
{
    /// <summary>
    /// Мод "Auth". Основа. Ресурсы.
    /// </summary>
    public class HostBasePartAuthResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public HostBasePartAuthResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public HostBasePartAuthResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public HostBasePartAuthResources(
            IStringLocalizer<HostBasePartAuthResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<HostBasePartAuthResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new HostBasePartAuthResourceErrors(resourceErrorsLocalizer);
            Successes = new HostBasePartAuthResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
