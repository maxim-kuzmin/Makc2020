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

            var (filesCount, foldersCount) = GetCounts(
                input.SourcePath,
                fileSearchPattern,
                excludedFolderNames,
                filePath => FilePathIsValid(filePath, input.SourceEntityName)
                );

            if (filesCount > 0)
            {
                EnumerateFiles(
                    input.SourcePath,
                    fileSearchPattern,
                    excludedFolderNames,
                    (path, number) => HandleFile(
                        input.FileHandleProgress,
                        path,
                        number,
                        filesCount,
                        input.SourceEntityName,
                        input.SourcePath,
                        input.TargetEntityName,
                        input.TargetPath
                        ),
                    (path, number) => HandleFolder(
                        input.FolderHandleProgress,
                        path,
                        number,                        
                        foldersCount,                        
                        input.SourceEntityName,
                        input.SourcePath,
                        input.TargetEntityName,
                        input.TargetPath,
                        fileSearchPattern
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
            string sourcePath,
            string targetEntityName,
            string targetPath
            )
        {
            if (FilePathIsValid(path, sourceEntityName))
            {
                var destPath = path.Replace(sourceEntityName, targetEntityName);

                if (sourcePath != targetPath)
                {
                    destPath = destPath.Replace(sourcePath, targetPath);
                }

                File.Copy(path, destPath, false);

                var encoding = Encoding.UTF8;

                var targetText = File.ReadAllText(destPath, encoding);

                targetText = targetText.Replace(sourceEntityName, targetEntityName);

                File.WriteAllText(destPath, targetText, encoding);

                if (progress != null)
                {
                    ReportProgress(progress, path, number, count);
                }
            }
        }

        private void HandleFolder(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count,            
            string sourceEntityName,
            string sourcePath,
            string targetEntityName,
            string targetPath,
            string fileSearchPattern
            )
        {
            if (FolderPathIsValid(path, fileSearchPattern, filePath => FilePathIsValid(filePath, sourceEntityName)))
            {
                var destPath = path.Replace(sourceEntityName, targetEntityName);

                if (sourcePath != targetPath)
                {
                    destPath = destPath.Replace(sourcePath, targetPath);
                }

                Directory.CreateDirectory(destPath);

                if (progress != null)
                {
                    ReportProgress(progress, path, number, count);
                }
            }
        }

        #endregion Private methods
    }
}
