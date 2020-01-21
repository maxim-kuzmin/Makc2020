//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Common.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace Makc2020.Mods.Automation.Base.Common
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Сервис.
    /// </summary>
    /// <typeparam name="TConfigSettings">Тип конфигурационных настроек.</typeparam>
    public class ModAutomationBaseCommonService<TConfigSettings>
        where TConfigSettings: IModAutomationBaseCommonConfigSettings
    {
        #region Properties

        protected TConfigSettings ConfigSettings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public ModAutomationBaseCommonService(TConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

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

        /// <summary>
        /// Инициализировать ввод задания на генерацию кода.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        protected void InitJobCodeGenerateInput(ModAutomationBaseCommonJobCodeGenerateInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Path))
            {
                input.Path = ConfigSettings.Path;
            }

            if (string.IsNullOrWhiteSpace(input.SourceEntityName))
            {
                input.SourceEntityName = ConfigSettings.SourceEntityName;
            }

            if (string.IsNullOrWhiteSpace(input.TargetEntityName))
            {
                input.TargetEntityName = ConfigSettings.TargetEntityName;
            }
        }

        #endregion Protected methods
    }
}