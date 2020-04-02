//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Common.Jobs.List.Get;
using System.Linq;
using Makc2020.Core.Base.Common.Enums;

namespace Makc2020.Mods.DummyTree.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "DummyTree". Задания. Список. Получение. Ввод.
    /// </summary>
    public class ModDummyTreeBaseJobListGetInput : CoreBaseCommonJobListGetInput
    {
        #region Properties

        /// <summary>
        /// Ось.
        /// </summary>
        public CoreBaseCommonEnumTreeAxis Axis { get; set; }

        /// <summary>
        /// Строка идентификаторов данных.
        /// </summary>
        public string DataIdsString { get; set; }

        /// <summary>
        /// Идентификаторы данных.
        /// </summary>
        public long[] DataIds { get; set; }

        /// <summary>
        /// Уровень данных.
        /// </summary>
        public long? DataLevel { get; set; }

        /// <summary>
        /// Имя данных.
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

            if (string.IsNullOrWhiteSpace(DataSortField))
            {
                DataSortField = "id";
            }

            if (string.IsNullOrWhiteSpace(DataSortDirection))
            {
                DataSortDirection = "desc";
            }

            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}