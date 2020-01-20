//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Jobs.JavascriptCode.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Задания. Код "NetCore". Генерация. Сервис.
    /// </summary>
    public class ModAutomationBaseJobNetCoreCodeGenerateService : ModAutomationBaseCommonJobCodeGenerateService
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBaseJobNetCoreCodeGenerateService(
            Func<ModAutomationBaseCommonJobCodeGenerateInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses)
        {
        }

        #endregion Constructors
    }
}