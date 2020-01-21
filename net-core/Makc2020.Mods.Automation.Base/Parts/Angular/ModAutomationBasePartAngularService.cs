//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.Angular.Config;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Parts.Angular
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "Angular". Сервис.
    /// </summary>
    public class ModAutomationBasePartAngularService : ModAutomationBaseCommonService<IModAutomationBasePartAngularConfigSettings>
    {
        #region Constructors

        /// <inheritdoc/>
        public ModAutomationBasePartAngularService(IModAutomationBasePartAngularConfigSettings configSettings)
            : base(configSettings)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Генерировать код.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task GenerateCode(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            InitJobCodeGenerateInput(input);

            var excludedFolderNames = new HashSet<string>
            {
                ".idea",
                "node_modules"
            };

            var filePaths = GetFilePaths("*.ts", input.Path, excludedFolderNames);

            HandleFiles(filePaths, input.Progress, HandleFile);

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private void HandleFile(string filePath)
        {
        }

        #endregion Private methods
    }
}
