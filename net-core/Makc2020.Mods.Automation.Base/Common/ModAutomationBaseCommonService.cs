//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;
using System.Collections.Generic;
using System.IO;

namespace Makc2020.Mods.Automation.Base.Common
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Сервис.
    /// </summary>
    public class ModAutomationBaseCommonService
    {
        #region Protected methods

        protected List<string> GetFilePaths(
            string fileSearchPattern,
            string pathToFolder,
            HashSet<string> excludedFolderNames
            )
        {
            var result = new List<string>();

            foreach (var folderPath in Directory.EnumerateDirectories(pathToFolder, "*.*", SearchOption.AllDirectories))
            {
                var folderName = Path.GetFileName(Path.GetDirectoryName(folderPath));

                if (excludedFolderNames != null && excludedFolderNames.Contains(folderName))
                {
                    continue;
                }

                foreach (var filePath in Directory.EnumerateFiles(folderPath, fileSearchPattern))
                {
                    result.Add(filePath);
                }
            }

            return result;
        }

        protected void HandleFiles(
            List<string> filePaths,
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            Action<ModAutomationBaseCommonJobCodeGenerateInfo> fileHandler
            )
        {
            double index = 0;

            var count = filePaths.Count;

            foreach (var filePath in filePaths)
            {
                index++;

                var info = new ModAutomationBaseCommonJobCodeGenerateInfo
                {
                    FileName = Path.GetFileName(filePath),
                    PathToFolder = Path.GetDirectoryName(filePath),
                    Percentage = (int)Math.Round(index / count, 2) * 100
                };

                fileHandler.Invoke(info);

                if (progress != null)
                {
                    progress.Report(info);
                }
            }
        }

        protected void InitJobCodeGenerateInput(
            ModAutomationBaseCommonJobCodeGenerateInput input,
            string path,
            string sourceEntityName,
            string targetEntityName
            )
        {
            if (string.IsNullOrWhiteSpace(input.Path))
            {
                input.Path = path;
            }

            if (string.IsNullOrWhiteSpace(input.SourceEntityName))
            {
                input.SourceEntityName = sourceEntityName;
            }

            if (string.IsNullOrWhiteSpace(input.TargetEntityName))
            {
                input.TargetEntityName = targetEntityName;
            }
        }

        #endregion Protected methods
    }
}