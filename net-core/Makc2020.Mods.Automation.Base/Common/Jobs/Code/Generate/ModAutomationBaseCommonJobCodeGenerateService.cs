//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Automation.Base.Common.Config;
using Makc2020.Mods.Automation.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Common.Code.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Задания. Код. Генерация. Сервис.
    /// </summary>
    public class ModAutomationBaseCommonJobCodeGenerateService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModAutomationBaseCommonJobCodeGenerateInput
        >
    {
        #region Properties

        private IModAutomationBaseCommonConfigSettings ConfigSettings { get; set; }

        private ModAutomationBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public ModAutomationBaseCommonJobCodeGenerateService(
            Func<ModAutomationBaseCommonJobCodeGenerateInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAutomationBaseResourceSuccesses resourceSuccesses,
            IModAutomationBaseCommonConfigSettings configSettings
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ConfigSettings = configSettings;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetSuccessMessages(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatEntityIsGenerated(),
                    input.TargetEntityName,
                    input.SourceEntityName
                    )
            };
        }

        protected void InitInput(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Path))
            {
                input.Path = ConfigSettings.Path;
            }

            if (string.IsNullOrWhiteSpace(input.SourceEntityName))
            {
                input.SourceEntityName = ConfigSettings.SourceEntityName;
            }

            if (string.IsNullOrWhiteSpace(input.TargetEntityName))
            {
                input.TargetEntityName = ConfigSettings.TargetEntityName;
            }
        }

        private ModAutomationBaseCommonJobCodeGenerateInput TransformInput(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            if (input == null)
            {
                input = new ModAutomationBaseCommonJobCodeGenerateInput();
            }

            InitInput(input);

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        #endregion Private methods
    }
}