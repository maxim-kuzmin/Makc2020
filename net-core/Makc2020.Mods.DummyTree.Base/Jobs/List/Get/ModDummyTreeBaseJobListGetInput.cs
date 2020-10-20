//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Common.Enums.Tree.List;
using Makc2020.Core.Base.Common.Jobs.Tree.List.Get;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
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

            if (Axis != CoreBaseCommonEnumTreeListAxis.None)
            {
                if (string.IsNullOrWhiteSpace(SortField))
                {
                    DataEntityObjectDummyTree obj;

                    SortField = nameof(obj.TreeSort);
                }

                if (string.IsNullOrWhiteSpace(SortDirection))
                {
                    SortDirection = CoreBaseCommonSettings.SORT_DIRECTION_ASC;
                }
            }

            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}