//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Ресурсы.
    /// </summary>
    public class ModAutomationBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModAutomationBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModAutomationBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public ModAutomationBaseResources(
            IStringLocalizer<ModAutomationBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModAutomationBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModAutomationBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModAutomationBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
