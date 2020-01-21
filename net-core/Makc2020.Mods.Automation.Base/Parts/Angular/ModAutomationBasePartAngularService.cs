//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.Angular.Config;
using System;
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

            const string fileSearchPattern = "*.ts";

            var fileCount = 0;

            EnumerateFiles(
                input.Path,
                fileSearchPattern,
                excludedFolderNames,
                (filePath, fileNumber) => fileCount++
                );

            if (fileCount > 0)
            {
                EnumerateFiles(
                    input.Path,
                    fileSearchPattern,
                    excludedFolderNames,
                    (filePath, fileNumber) => HandleFile(input.Progress, filePath, fileNumber, fileCount),
                    HandleFolder
                    );
            }

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private void HandleFile(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string filePath,
            int fileNumber,
            int fileCount
            )
        {
            if (progress != null)
            {
                ReportProgress(progress, filePath, fileNumber, fileCount);
            }
        }

        private void HandleFolder(string folderPath)
        {
        }

        #endregion Private methods
    }
}
