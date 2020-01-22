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
        /// Путь.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Имя исходной сущности.
        /// </summary>
        public string SourceEntityName { get; set; }

        /// <summary>
        /// Имя целевой сущности.
        /// </summary>
        public string TargetEntityName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public virtual List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(Path))
            {
                result.Add(nameof(Path));
            }

            if (string.IsNullOrWhiteSpace(SourceEntityName))
            {
                result.Add(nameof(SourceEntityName));
            }

            if (string.IsNullOrWhiteSpace(TargetEntityName))
            {
                result.Add(nameof(TargetEntityName));
            }

            return result;
        }

        #endregion Public methods
    }
}
