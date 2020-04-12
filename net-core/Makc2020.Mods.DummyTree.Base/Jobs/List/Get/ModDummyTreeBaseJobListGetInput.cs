//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Tree.List.Get;
using Makc2020.Core.Base.Ext;
using System.Linq;

namespace Makc2020.Mods.DummyTree.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "DummyTree". Задания. Список. Получение. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobListGetInput : CoreBaseCommonJobTreeListGetInput
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

        /// <summary>
        /// Данные: имя.
        /// </summary>
        public string DataName { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (string.IsNullOrWhiteSpace(SortField))
            {
                SortField = "treesort";
            }

            if (string.IsNullOrWhiteSpace(SortDirection))
            {
                SortDirection = "asc";
            }

            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}