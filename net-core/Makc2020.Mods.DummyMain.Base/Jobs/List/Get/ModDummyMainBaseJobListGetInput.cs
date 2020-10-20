//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Core.Base.Common.Jobs.List.Get;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Objects;
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

        /// <summary>
        /// Данные: имя объекта, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public string DataObjectDummyOneToManyName { get; set; }

        /// <summary>
        /// Данные: идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public long DataObjectDummyOneToManyId { get; set; }

        /// <summary>
        /// Данные: строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public string DataObjectDummyOneToManyIdsString { get; set; }

        /// <summary>
        /// Идентификаторы объектов, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public long[] DataObjectDummyOneToManyIds { get; set; }

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
                DataEntityObjectDummyMain obj;

                SortField = nameof(obj.Id);
            }

            if (string.IsNullOrWhiteSpace(SortDirection))
            {
                SortDirection = CoreBaseCommonSettings.SORT_DIRECTION_DESC;
            }

            var isOk = !string.IsNullOrWhiteSpace(DataObjectDummyOneToManyIdsString)
                && 
                (
                    DataObjectDummyOneToManyIds == null
                    ||
                    !DataObjectDummyOneToManyIds.Any()
                );

            if (isOk)
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