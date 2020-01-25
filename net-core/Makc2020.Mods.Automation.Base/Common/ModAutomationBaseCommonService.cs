//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
        /// <param name="funcFilePathIsValid">Функция проверки годности пути к файлу для обработки.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) GetCounts(
            string path,
            string fileSearchPattern,
            HashSet<string> excludedFolderNames,
            Func<string, bool> funcFilePathIsValid
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

                if (FolderPathIsValid(folderPath, fileSearchPattern, funcFilePathIsValid))
                {
                    foldersCount++;
                }

                foreach (var filePath in Directory.EnumerateFiles(folderPath, fileSearchPattern))
                {
                    if (funcFilePathIsValid.Invoke(filePath))
                    {
                        filesCount++;
                    }
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
        /// <param name="actionHandleFile">Действие по обработке файла.</param>
        /// <param name="actionHandleFolder">Действие по обработке папки.</param>
        /// <param name="fileNumber">Номер файла.</param>
        /// <param name="folderNumber">Номер папки.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) EnumerateFiles(
            string path,
            string fileSearchPattern,            
            HashSet<string> excludedFolderNames,
            Action<string, int> actionHandleFile,
            Action<string, int> actionHandleFolder,
            int fileNumber = 0,
            int folderNumber = 0
        )
        {
            var folderName = Path.GetFileName(path);

            if (folderNumber == 0 || excludedFolderNames == null || !excludedFolderNames.Contains(folderName))
            {
                folderNumber++;

                actionHandleFolder.Invoke(path, folderNumber);

                foreach (var filePath in Directory.EnumerateFiles(path, fileSearchPattern))
                {
                    fileNumber++;

                    actionHandleFile.Invoke(filePath, fileNumber);
                }

                foreach (var folderPath in Directory.EnumerateDirectories(path, "*.*"))
                {
                    (fileNumber, folderNumber) = EnumerateFiles(
                        folderPath,
                        fileSearchPattern,
                        excludedFolderNames,
                        actionHandleFile,
                        actionHandleFolder,
                        fileNumber,
                        folderNumber
                        );
                }
            }

            return (fileNumber, folderNumber);
        }

        /// <summary>
        /// Получить признак того, что путь к файлу годнен для обработки.
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="sourceEntityFileName">Имя файла исходной сущности.</param>
        /// <returns></returns>
        protected bool FilePathIsValid(string path, string sourceEntityFileName)
        {
            var fileName = Path.GetFileName(path);

            return fileName.Contains(sourceEntityFileName);
        }

        /// <summary>
        /// Получить признак того, что путь к папке годен для обработки.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <param name="fileSearchPattern">Шаблон поиска файлов.</param>
        /// <param name="funcFilePathIsValid">Функция проверки годности пути к файлу для обработки.</param>
        /// <returns></returns>
        protected bool FolderPathIsValid(string path, string fileSearchPattern, Func<string, bool> funcFilePathIsValid)
        {
            var result = false;

            foreach (var filePath in Directory.EnumerateFiles(path, fileSearchPattern, SearchOption.AllDirectories))
            {
                if (funcFilePathIsValid.Invoke(filePath))
                {
                    result = true;

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Обработать файл.
        /// </summary>
        /// <param name="progress">Прогресс.</param>
        /// <param name="path">Путь.</param>
        /// <param name="number">Номер.</param>
        /// <param name="count">Счётчик.</param>
        /// <param name="sourceEntityName">Имя файла сущности.</param>
        /// <param name="sourceEntityFileName">Имя файла исходной сущности.</param>
        /// <param name="sourcePath">Исходный путь.</param>
        /// <param name="targetEntityName">Имя конечной сущности.</param>
        /// <param name="targetEntityFileName">Имя файла конечной сущности.</param>
        /// <param name="targetPath">Конечный путь.</param>
        protected void HandleFile(
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
            if (FilePathIsValid(path, sourceEntityFileName))
            {
                var destPath = path.Replace(sourceEntityFileName, targetEntityFileName);

                if (sourcePath != targetPath)
                {
                    destPath = destPath.Replace(sourcePath, targetPath);
                }

                File.Copy(path, destPath, false);

                var encoding = Encoding.UTF8;

                var targetText = File.ReadAllText(destPath, encoding);

                targetText = targetText.Replace(sourceEntityName, targetEntityName);
                
                if (sourceEntityFileName != sourceEntityName)
                {
                    targetText = targetText.Replace(sourceEntityFileName, targetEntityFileName);
                }

                File.WriteAllText(destPath, targetText, encoding);

                if (progress != null)
                {
                    ReportProgress(progress, path, number, count);
                }
            }
        }

        /// <summary>
        /// Обработать папку.
        /// </summary>
        /// <param name="progress">Прогресс.</param>
        /// <param name="path">Путь.</param>
        /// <param name="number">Номер.</param>
        /// <param name="count">Счётчик.</param>
        /// <param name="sourceEntityFileName">Имя файла исходной сущности.</param>
        /// <param name="sourcePath">Исходный путь.</param>
        /// <param name="targetEntityFileName">Имя файла конечной сущности.</param>
        /// <param name="targetPath">Конечный путь.</param>
        /// <param name="fileSearchPattern">Шаблон поиска файлов.</param>
        protected void HandleFolder(
            IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> progress,
            string path,
            int number,
            int count,
            string sourceEntityFileName,
            string sourcePath,
            string targetEntityFileName,
            string targetPath,
            string fileSearchPattern
            )
        {
            if (FolderPathIsValid(path, fileSearchPattern, filePath => FilePathIsValid(filePath, sourceEntityFileName)))
            {
                var destPath = path.Replace(sourceEntityFileName, targetEntityFileName);

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