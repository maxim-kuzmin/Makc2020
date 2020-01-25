//Author Maxim Kuzmin//makc//

using System;
using System.Collections.Generic;

namespace Makc2020.Mods.Automation.Base.Common.Code.Generate
{
    /// <summary>
    /// Мод "Automation". Основа. Общее. Задания. Код. Генерация. Ввод.
    /// </summary>
    public class ModAutomationBaseCommonJobCodeGenerateInput
    {
        #region Properties

        /// <summary>
        /// Прогресс обработки файлов.
        /// </summary>
        public IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> FileHandleProgress { get; set; }

        /// <summary>
        /// Прогресс обработки папок.
        /// </summary>
        public IProgress<ModAutomationBaseCommonJobCodeGenerateInfo> FolderHandleProgress { get; set; }

        /// <summary>
        /// Имя исходной сущности.
        /// </summary>
        public string SourceEntityName { get; set; }

        /// <summary>
        /// Исходный путь.
        /// </summary>
        public string SourcePath { get; set; }

        /// <summary>
        /// Имя конечной сущности.
        /// </summary>
        public string TargetEntityName { get; set; }

        /// <summary>
        /// Конечный путь.
        /// </summary>
        public string TargetPath { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(SourceEntityName))
            {
                result.Add(nameof(SourceEntityName));
            }

            if (string.IsNullOrWhiteSpace(SourcePath))
            {
                result.Add(nameof(SourcePath));
            }

            if (string.IsNullOrWhiteSpace(TargetEntityName))
            {
                result.Add(nameof(TargetEntityName));
            }

            if (string.IsNullOrWhiteSpace(TargetPath))
            {
                result.Add(nameof(TargetPath));
            }

            return result;
        }

        #endregion Public methods
    }
}
