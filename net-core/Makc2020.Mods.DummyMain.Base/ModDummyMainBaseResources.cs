//Author Maxim Kuzmin//makc//

using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Ресурсы.
    /// </summary>
    public class ModDummyMainBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModDummyMainBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModDummyMainBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public ModDummyMainBaseResources(
            IStringLocalizer<ModDummyMainBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModDummyMainBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModDummyMainBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModDummyMainBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
