//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Внешнее.
    /// </summary>
    public class ModAutomationBaseExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ядро. Основа. Данные. Поставщик.
        /// </summary>
        public ICoreBaseDataProvider CoreBaseDataProvider { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModAutomationBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModAutomationBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
