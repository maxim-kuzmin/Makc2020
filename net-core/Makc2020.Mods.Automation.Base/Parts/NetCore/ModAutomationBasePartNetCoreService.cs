//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
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
                filePath => FilePathIsHandleable(filePath, input.SourceEntityName)
                );

            if (filesCount > 0)
            {
                if (!Directory.Exists(input.TargetPath))
                {
                    Directory.CreateDirectory(input.TargetPath);
                }

                EnumerateFiles(
                    input.SourcePath,
                    fileSearchPattern,
                    excludedFolderNames,
                    (path, number) => HandleFile(
                        input.FileHandleProgress,
                        path,
                        number,
                        filesCount,
                        new UTF8Encoding(true),
                        input.SourceEntityName,
                        input.SourceEntityName,
                        input.SourcePath,
                        input.TargetEntityName,
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
    }
}
