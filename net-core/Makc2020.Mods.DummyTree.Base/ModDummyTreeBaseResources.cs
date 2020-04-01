//Author Maxim Kuzmin//makc//

using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Ресурсы.
    /// </summary>
    public class ModDummyTreeBaseResources
    {
        #region Properties

        /// <summary>
        /// Ошибки.
        /// </summary>
        public ModDummyTreeBaseResourceErrors Errors { get; set; }

        /// <summary>
        /// Успехи.
        /// </summary>
        public ModDummyTreeBaseResourceSuccesses Successes { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrorsLocalizer">Локализатор ресурсов ошибок.</param>
        /// <param name="resourceSuccessesLocalizer">Локализатор ресурсов успехов.</param>
        public ModDummyTreeBaseResources(
            IStringLocalizer<ModDummyTreeBaseResourceErrors> resourceErrorsLocalizer,
            IStringLocalizer<ModDummyTreeBaseResourceSuccesses> resourceSuccessesLocalizer
            )
        {
            Errors = new ModDummyTreeBaseResourceErrors(resourceErrorsLocalizer);
            Successes = new ModDummyTreeBaseResourceSuccesses(resourceSuccessesLocalizer);
        }

        #endregion Constructor
    }
}
