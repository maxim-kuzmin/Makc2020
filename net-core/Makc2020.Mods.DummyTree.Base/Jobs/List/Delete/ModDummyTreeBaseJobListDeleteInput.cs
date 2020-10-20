//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.List.Delete;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Mods.DummyTree.Base.Jobs.List.Delete
{
    /// <summary>
    /// Мод "DummyTree". Задания. Список. Удаление. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobListDeleteInput : CoreBaseCommonJobListDeleteInput
    {
        #region Properties

        /// <summary>
        /// Данные: идентификаторы.
        /// </summary>
        public long[] DataIds { get; set; }

        /// <summary>
        /// Данные: наименования.
        /// </summary>
        public string[] DataNames { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Получить список свойств с недействительными значениями.
        /// </summary>
        /// <returns>Список свойств.</returns>
        public List<string> GetInvalidProperties()
        {
            var result = new List<string>();

            if (DataIds == null || !DataIds.Any())
            {
                result.Add(nameof(DataIds));
            }

            if (DataNames == null || !DataNames.Any())
            {
                result.Add(nameof(DataNames));
            }

            return result;
        }

        #endregion Public methods
    }
}