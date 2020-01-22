//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Parts.Angular
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "Angular". Сервис.
    /// </summary>
    public class ModAutomationBasePartAngularService : ModAutomationBaseCommonService
    {
        #region Public methods

        /// <summary>
        /// Генерировать код.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task GenerateCode(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            var excludedFolderNames = new HashSet<string>
            {
                ".idea",
                "node_modules"
            };

            const string fileSearchPattern = "*.ts";

            var (filesCount, foldersCount) = GetCounts(input.Path, fileSearchPattern, excludedFolderNames);

            if (filesCount > 0)
            {
                EnumerateFiles(
                    input.Path,
                    fileSearchPattern,
                    excludedFolderNames,
                    (path, number) => HandleFile(input.FileHandleProgress, path, number, filesCount),
                    (path, number) => HandleFolder(input.FolderHandleProgress, path, number, foldersCount)
                    );
            }

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private void HandleFile(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count
            )
        {
            if (progress != null)
            {
                ReportProgress(progress, path, number, count);
            }
        }

        private void HandleFolder(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count
            )
        {
            if (progress != null)
            {
                ReportProgress(progress, path, number, count);
            }
        }

        #endregion Private methods
    }
}
