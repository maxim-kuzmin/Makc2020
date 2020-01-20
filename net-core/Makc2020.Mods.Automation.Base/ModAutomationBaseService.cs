//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Config;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base
{
    /// <summary>
    /// Мод "Automation". Основа. Сервис.
    /// </summary>
    public class ModAutomationBaseService
    {
        #region Properties

        private IModAutomationBaseConfigSettings ConfigSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public ModAutomationBaseService(IModAutomationBaseConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Генерировать код "Javascript".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task GenerateJavascriptCode(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            PrepareCommonJobCodeGenerateInput(input, ConfigSettings.PathToJavascriptCodeFolder);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Генерировать код ".NET Core".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task GenerateNetCoreCode(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            PrepareCommonJobCodeGenerateInput(input, ConfigSettings.PathToNetCoreCodeFolder);

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private void PrepareCommonJobCodeGenerateInput(
            ModAutomationBaseCommonJobCodeGenerateInput input,
            string pathToCodeFolder
            )
        {
            if (string.IsNullOrWhiteSpace(input.PathToCodeFolder))
            {
                input.PathToCodeFolder = pathToCodeFolder;
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

        #endregion Private methods
    }
}