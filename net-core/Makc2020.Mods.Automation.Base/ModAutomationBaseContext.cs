//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Parts.Angular;
using Makc2020.Mods.Automation.Base.Parts.NetCore;
using Makc2020.Mods.Automation.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Successes;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Контекст.
    /// </summary>
    public class ModAutomationBaseContext
    {
        #region Properties

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public ModAutomationBaseConfig Config { get; private set; }

        /// <summary>
        /// Часть "Angular".
        /// </summary>
        public ModAutomationBasePartAngularContext PartAngular { get; set; }

        /// <summary>
        /// Часть "NetCore".
        /// </summary>
        public ModAutomationBasePartNetCoreContext PartNetCore { get; set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public ModAutomationBaseResources Resources { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public ModAutomationBaseContext(ModAutomationBaseConfig config, ModAutomationBaseExternals externals)
        {
            Config = config;

            var resourceErrors = new ModAutomationBaseResourceErrors(externals.ResourceErrorsLocalizer);
            var resourceSuccesses = new ModAutomationBaseResourceSuccesses(externals.ResourceSuccessesLocalizer);

            PartAngular = new ModAutomationBasePartAngularContext(
                Config.Settings.PartAngular,
                new ModAutomationBasePartAngularExternals
                {
                    CoreBaseResourceErrors = externals.CoreBaseResourceErrors,
                    ResourceErrors = resourceErrors,
                    ResourceSuccesses = resourceSuccesses
                });

            PartNetCore = new ModAutomationBasePartNetCoreContext(
                Config.Settings.PartNetCore,
                new ModAutomationBasePartNetCoreExternals
                {
                    CoreBaseResourceErrors = externals.CoreBaseResourceErrors,
                    ResourceErrors = resourceErrors,
                    ResourceSuccesses = resourceSuccesses
                });

            Resources = new ModAutomationBaseResources(
                externals.ResourceErrorsLocalizer,
                externals.ResourceSuccessesLocalizer
                );
        }

        #endregion Constructor
    }
}
