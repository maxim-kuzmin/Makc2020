//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Makc2020.Mods.Automation.Base.Parts.NetCore
{
    /// <summary>
    /// Мод "Automation". Основа. Часть "NetCore". Сервис.
    /// </summary>
    public class ModAutomationBasePartNetCoreService : ModAutomationBaseCommonService
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
                ".vs",
                "bin",
                "doc",
                "obj"
            };

            const string fileSearchPattern = "*.cs";

            var (filesCount, foldersCount) = GetCounts(input.Path, fileSearchPattern, excludedFolderNames);

            if (filesCount > 0)
            {
                EnumerateFiles(
                    input.Path,
                    fileSearchPattern,
                    excludedFolderNames,
                    (path, number) => HandleFile(
                        input.FileHandleProgress,
                        path,
                        number,
                        filesCount,
                        input.SourceEntityName,
                        input.TargetEntityName
                        ),
                    (path, number) => HandleFolder(
                        input.FolderHandleProgress,
                        path,
                        number,
                        foldersCount,
                        input.SourceEntityName,
                        input.TargetEntityName
                        )
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
            int count,
            string sourceEntityName,
            string targetEntityName
            )
        {
            var fileName = Path.GetFileName(path);

            if (fileName.Contains(sourceEntityName))
            {
                var targetPath = path.Replace(sourceEntityName, targetEntityName);

                File.Copy(path, targetPath, false);

                var encoding = Encoding.UTF8;

                var targetText = File.ReadAllText(targetPath, encoding);

                targetText = targetText.Replace(sourceEntityName, targetEntityName);

                File.WriteAllText(targetPath, targetText, encoding);
            }

            if (progress != null)
            {
                ReportProgress(progress, path, number, count);
            }
        }

        private void HandleFolder(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count,
            string sourceEntityName,
            string targetEntityName
            )
        {
            if (path.Contains(sourceEntityName))
            {
                var targetPath = path.Replace(sourceEntityName, targetEntityName);

                Directory.CreateDirectory(targetPath);
            }

            if (progress != null)
            {
                ReportProgress(progress, path, number, count);
            }
        }

        #endregion Private methods
    }
}
