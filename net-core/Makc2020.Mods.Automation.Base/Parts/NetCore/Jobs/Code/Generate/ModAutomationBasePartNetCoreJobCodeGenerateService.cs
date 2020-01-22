//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.NetCore.Config;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Parts.NetCore.Jobs.Code.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Задания. Код. Генерация. Сервис.
    /// </summary>
    public class ModAutomationBasePartNetCoreJobCodeGenerateService : ModAutomationBaseCommonJobCodeGenerateService
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBasePartNetCoreJobCodeGenerateService(
            Func<ModAutomationBaseCommonJobCodeGenerateInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            IModAutomationBasePartNetCoreConfigSettings configSettings
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses, configSettings)
        {
        }

        #endregion Constructors
    }
}