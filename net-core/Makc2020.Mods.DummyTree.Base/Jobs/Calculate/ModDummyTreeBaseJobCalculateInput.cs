//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using System.Linq;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Calculate
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Вычисление. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobCalculateInput
    {
        #region Properties

        /// <summary>
        /// Данные: идентификаторы.
        /// </summary>
        public long[] DataIds { get; set; }

        /// <summary>
        /// Данные: строка идентификаторов.
        /// </summary>
        public string DataIdsString { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public void Normalize()
        {
            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
