//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

            var (filesCount, foldersCount) = GetCounts(
                input.SourcePath,
                fileSearchPattern,
                excludedFolderNames,
                filePath => FilePathIsValid(filePath, input.SourceEntityName)
                );

            if (filesCount > 0)
            {
                var sourceEntityFileName = GetFileNameFromEntityName(input.SourceEntityName);
                var targetEntityFileName = GetFileNameFromEntityName(input.TargetEntityName);

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
                        sourceEntityFileName,
                        input.SourcePath,
                        input.TargetEntityName,
                        targetEntityFileName,
                        input.TargetPath
                        ),
                    (path, number) => HandleFolder(
                        input.FolderHandleProgress,
                        path,
                        number,
                        foldersCount,
                        input.SourceEntityName,
                        sourceEntityFileName,
                        input.SourcePath,
                        input.TargetEntityName,                        
                        targetEntityFileName,
                        input.TargetPath
                        )
                    );
            }

            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        private string GetFileNameFromEntityName(string entityName)
        {
            var result = new StringBuilder();

            var entityNameUpper = entityName.ToUpper();

            for (var i = 0; i < entityNameUpper.Length; i++)
            {
                var letter = entityName[i];

                if (letter != entityNameUpper[i])
                {
                    result.Append(letter);
                }
                else
                {
                    if (i > 0)
                    {
                        result.Append("-");
                    }

                    result.Append(letter.ToString().ToLower());
                }
            }

            return result.ToString();
        }

        private void HandleFile(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count,
            string sourceEntityName,            
            string sourceEntityFileName,
            string sourcePath,
            string targetEntityName,
            string targetEntityFileName,
            string targetPath
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
            int count,
            string sourceEntityName,
            string sourceEntityFileName,
            string sourcePath,
            string targetEntityName,
            string targetEntityFileName,
            string targetPath
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
