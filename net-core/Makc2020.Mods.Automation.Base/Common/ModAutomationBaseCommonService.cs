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

        /// <summary>
        /// Получить счётчики.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <param name="fileSearchPattern">Шаблон поиска файлов.</param>
        /// <param name="excludedFolderNames">Имена исключаемых папок.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) GetCounts(
            string path,
            string fileSearchPattern,
            HashSet<string> excludedFolderNames
            )
        {
            int filesCount = 0;
            int foldersCount = 1;

            foreach (var folderPath in Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories))
            {
                var folderNames = folderPath.Split(Path.DirectorySeparatorChar);

                var isOk = true;

                foreach (var folderName in folderNames)
                {
                    if (excludedFolderNames != null && excludedFolderNames.Contains(folderName))
                    {
                        isOk = false;
                    }

                    if (!isOk)
                    {
                        break;
                    }
                }

                if (!isOk)
                {
                    continue;
                }

                foldersCount++;

                foreach (var filePath in Directory.EnumerateFiles(folderPath, fileSearchPattern))
                {
                    filesCount++;
                }
            }

            return (filesCount, foldersCount);
        }

        /// <summary>
        /// Перечислить файлы.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <param name="fileSearchPattern">Шаблон поиска файлов.</param>
        /// <param name="excludedFolderNames">Имена исключаемых папок.</param>
        /// <param name="handleFile">Обработчик файла.</param>
        /// <param name="handleFolder">Обработчик папки.</param>
        /// <param name="fileNumber">Номер файла.</param>
        /// <param name="folderNumber">Номер папки.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) EnumerateFiles(
            string path,
            string fileSearchPattern,            
            HashSet<string> excludedFolderNames,
            Action<string, int> handleFile,
            Action<string, int> handleFolder,
            int fileNumber = 0,
            int folderNumber = 0
        )
        {
            var folderName = Path.GetFileName(path);

            if (folderNumber == 0 || excludedFolderNames == null || !excludedFolderNames.Contains(folderName))
            {
                folderNumber++;

                handleFolder.Invoke(path, folderNumber);

                foreach (var filePath in Directory.EnumerateFiles(path, fileSearchPattern))
                {
                    fileNumber++;

                    handleFile.Invoke(filePath, fileNumber);
                }

                foreach (var folderPath in Directory.EnumerateDirectories(path, "*.*"))
                {
                    (fileNumber, folderNumber) = EnumerateFiles(
                        folderPath,
                        fileSearchPattern,
                        excludedFolderNames,
                        handleFile,
                        handleFolder,
                        fileNumber,
                        folderNumber
                        );
                }
            }

            return (fileNumber, folderNumber);
        }

        /// <summary>
        /// Отчитаться о прогрессе.
        /// </summary>
        /// <param name="progress">Прогресс.</param>
        /// <param name="path">Путь.</param>
        /// <param name="number">Номер.</param>
        /// <param name="count">Счётчик.</param>
        protected void ReportProgress(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count
            )
        {
            var info = new ModAutomationBaseCommonJobCodeGenerateInfo
            {
                Count = count,
                Number = number,
                Path = path
            };

            progress.Report(info);
        }

        #endregion Protected methods
    }
}