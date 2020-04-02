//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Common.Jobs.List.Get;
using System.Linq;

namespace Makc2020.Mods.DummyMain.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Список. Получение. Ввод.
    /// </summary>
    public class ModDummyMainBaseJobListGetInput : CoreBaseCommonJobListGetInput
    {
        #region Properties

        /// <summary>
        /// Имя объекта, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public string DataObjectDummyOneToManyName { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public long DataObjectDummyOneToManyId { get; set; }

        /// <summary>
        /// Строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public string DataObjectDummyOneToManyIdsString { get; set; }

        /// <summary>
        /// Идентификаторы объектов, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public long[] DataObjectDummyOneToManyIds { get; set; }

        /// <summary>
        /// Имя данных.
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// Строка идентификаторов данных.
        /// </summary>
        public string DataIdsString { get; set; }

        /// <summary>
        /// Идентификаторы данных.
        /// </summary>
        public long[] DataIds { get; set; }

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

            if (!string.IsNullOrWhiteSpace(DataObjectDummyOneToManyIdsString) && (DataObjectDummyOneToManyIds == null || !DataObjectDummyOneToManyIds.Any()))
            {
                DataObjectDummyOneToManyIds = DataObjectDummyOneToManyIdsString.CoreBaseExtConvertToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(DataIdsString) && (DataIds == null || !DataIds.Any()))
            {
                DataIds = DataIdsString.CoreBaseExtConvertToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}