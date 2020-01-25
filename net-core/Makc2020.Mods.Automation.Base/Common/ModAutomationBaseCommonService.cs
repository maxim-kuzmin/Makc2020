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
        /// <param name="funcFilePathIsHandleable">Функция проверки годности пути к файлу для обработки.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) GetCounts(
            string path,
            string fileSearchPattern,
            HashSet<string> excludedFolderNames,
            Func<string, bool> funcFilePathIsHandleable
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
                    isOk = excludedFolderNames == null || !excludedFolderNames.Contains(folderName);

                    if (!isOk)
                    {
                        break;
                    }
                }

                if (!isOk)
                {
                    continue;
                }

                isOk = FolderPathIsHandleable(folderPath, fileSearchPattern, funcFilePathIsHandleable);

                if (isOk)
                {
                    foldersCount++;
                }

                foreach (var filePath in Directory.EnumerateFiles(folderPath, fileSearchPattern))
                {
                    isOk = funcFilePathIsHandleable.Invoke(filePath);

                    if (isOk)
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
        /// <param name="funcHandleFile">Функция обработки файла.</param>
        /// <param name="funcHandleFolder">Функция обработки папки.</param>
        /// <param name="fileNumber">Номер файла.</param>
        /// <param name="folderNumber">Номер папки.</param>
        /// <returns>Счётчик файлов, счётчик папок.</returns>
        protected (int, int) EnumerateFiles(
            string path,
            string fileSearchPattern,
            HashSet<string> excludedFolderNames,
            Func<string, int, bool> funcHandleFile,
            Func<string, int, bool> funcHandleFolder,
            int fileNumber = 0,
            int folderNumber = 0
        )
        {
            var folderName = Path.GetFileName(path);

            if (folderNumber == 0 || excludedFolderNames == null || !excludedFolderNames.Contains(folderName))
            {
                folderNumber++;

                if (!funcHandleFolder.Invoke(path, folderNumber))
                {
                    folderNumber--;
                }

                foreach (var filePath in Directory.EnumerateFiles(path, fileSearchPattern))
                {
                    fileNumber++;

                    if (!funcHandleFile.Invoke(filePath, fileNumber))
                    {
                        fileNumber--;
                    }
                }

                foreach (var folderPath in Directory.EnumerateDirectories(path, "*.*"))
                {
                    (fileNumber, folderNumber) = EnumerateFiles(
                        folderPath,
                        fileSearchPattern,
                        excludedFolderNames,
                        funcHandleFile,
                        funcHandleFolder,
                        fileNumber,
                        folderNumber
                        );
                }
            }

            return (fileNumber, folderNumber);
        }

        /// <summary>
        /// Получить признак того, что путь к файлу годен для обработки.
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="sourceEntityFileName">Имя файла исходной сущности.</param>
        /// <returns>Признак годности к обработке.</returns>
        protected bool FilePathIsHandleable(string path, string sourceEntityFileName)
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
        /// <returns>Признак годности к обработке.</returns>
        protected bool FolderPathIsHandleable(string path, string fileSearchPattern, Func<string, bool> funcFilePathIsValid)
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
        /// <returns>Признак того, что файл был обработан.</returns>
        protected bool HandleFile(
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
            var isOk = FilePathIsHandleable(path, sourceEntityFileName);

            if (!isOk)
            {
                return false;
            }

            var destPath = path.Replace(sourceEntityFileName, targetEntityFileName);

            if (sourcePath != targetPath)
            {
                destPath = destPath.Replace(sourcePath, targetPath);
            }

            if (!File.Exists(destPath))
            {
                File.Copy(path, destPath);
            }

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

            return true;
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
        /// <returns>Признак того, что папка была обработана.</returns>
        protected bool HandleFolder(
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
            var isOk = FolderPathIsHandleable(
                path,
                fileSearchPattern,
                filePath => FilePathIsHandleable(filePath, sourceEntityFileName)
                );

            if (!isOk)
            {
                return false;
            }

            var destPath = path.Replace(sourceEntityFileName, targetEntityFileName);

            if (sourcePath != targetPath)
            {
                destPath = destPath.Replace(sourcePath, targetPath);
            }

            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            if (progress != null)
            {
                ReportProgress(progress, path, number, count);
            }

            return true;
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