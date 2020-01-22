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

        protected void EnumerateFiles(
            string path,
            string fileSearchPattern,            
            HashSet<string> excludedFolderNames,            
            Action<string, int> handleFile,
            Action<string> handleFolder = null
            )
        {
            int fileNumber = 0;

            foreach (var folderPath in Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories))
            {
                var folderName = Path.GetFileName(Path.GetDirectoryName(folderPath));

                if (excludedFolderNames != null && excludedFolderNames.Contains(folderName))
                {
                    continue;
                }

                if (handleFolder != null)
                {
                    handleFolder.Invoke(folderName);
                }

                foreach (var filePath in Directory.EnumerateFiles(folderPath, fileSearchPattern))
                {
                    fileNumber++;

                    handleFile.Invoke(filePath, fileNumber);
                }
            }
        }
        
        protected void ReportProgress(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string filePath,
            int fileNumber,
            int fileCount
            )
        {
            var info = new ModAutomationBaseCommonJobCodeGenerateInfo
            {
                FilePath = filePath,
                Percentage = (int)Math.Round((double)fileNumber / fileCount, 2) * 100
            };

            progress.Report(info);
        }

        #endregion Protected methods
    }
}