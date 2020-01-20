//Author Maxim Kuzmin//makc//

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
        /// Путь к папке с кодом.
        /// </summary>
        public string PathToCodeFolder { get; set; }

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

            if (string.IsNullOrWhiteSpace(PathToCodeFolder))
            {
                result.Add(nameof(PathToCodeFolder));
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
