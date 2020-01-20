//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Jobs.JavascriptCode.Generate;
using Makc2020.Mods.Automation.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Resources.Successes;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Задания.
    /// </summary>
    public class ModAutomationBaseJobs
    {
        #region Properties

        /// <summary>
        /// Задание на генерацию кода "Javascript".
        /// </summary>
        public ModAutomationBaseJobJavascriptCodeGenerateService JobJavascriptCodeGenerate { get; private set; }

        /// <summary>
        /// Задание на генерацию кода ".Net Core".
        /// </summary>
        public ModAutomationBaseJobNetCoreCodeGenerateService JobNetCoreCodeGenerate { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModAutomationBaseJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            ModAutomationBaseResourceErrors resourceErrors,
            ModAutomationBaseService service
            )
        {
            JobJavascriptCodeGenerate = new ModAutomationBaseJobJavascriptCodeGenerateService(
                service.GenerateJavascriptCode,
                coreBaseResourceErrors,
                resourceSuccesses
                );

            JobNetCoreCodeGenerate = new ModAutomationBaseJobNetCoreCodeGenerateService(
                service.GenerateNetCoreCode,
                coreBaseResourceErrors,
                resourceSuccesses
                );
        }

        #endregion Constructor
    }
}
