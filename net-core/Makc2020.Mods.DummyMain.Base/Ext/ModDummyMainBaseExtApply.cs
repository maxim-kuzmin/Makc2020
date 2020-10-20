//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using System.Linq;

namespace Makc2020.Mods.DummyMain.Base.Ext
{
    /// <summary>
    /// Мод "DummyMain". Основа. Расширение. Применить.
    /// </summary>
    public static class ModDummyMainBaseExtApply
    {        
        #region Public methods

        /// <summary>
        /// Мод "DummyMain". Основа. Расширение. Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DataEntityObjectDummyMain> ModDummyMainBaseExtApplyFiltering(
            this IQueryable<DataEntityObjectDummyMain> query,
            ModDummyMainBaseJobItemGetInput input
            )
        {
            if (input.DataId > 0)
            {
                query = query.Where(x => x.Id == input.DataId);
            }

            if (input.DataName != null)
            {
                query = query.Where(x => x.Name == input.DataName);
            }

            return query;
        }

        /// <summary>
        /// Мод "DummyMain". Основа. Расширение. Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DataEntityObjectDummyMain> ModDummyMainBaseExtApplyFiltering(
            this IQueryable<DataEntityObjectDummyMain> query,
            ModDummyMainBaseJobListGetInput input
            )
        {
            if (!string.IsNullOrWhiteSpace(input.DataName))
            {
                query = query.Where(x => x.Name.Contains(input.DataName));
            }

            if (input.DataIds != null && input.DataIds.Any())
            {
                if (input.DataIds.Count() > 1)
                {
                    query = query.Where(x => input.DataIds.Contains(x.Id));
                }
                else
                {
                    var dataId = input.DataIds[0];

                    query = query.Where(x => x.Id == dataId);
                }
            }

            if (input.DataObjectDummyOneToManyId > 0)
            {
                query = query.Where(x => x.ObjectDummyOneToManyId == input.DataObjectDummyOneToManyId);
            }

            if (input.DataObjectDummyOneToManyIds != null && input.DataObjectDummyOneToManyIds.Any())
            {
                if (input.DataObjectDummyOneToManyIds.Count() > 1)
                {
                    query = query.Where(x => input.DataObjectDummyOneToManyIds.Contains(x.ObjectDummyOneToManyId));
                }
                else
                {
                    var dataObjectDummyOneToManyId = input.DataObjectDummyOneToManyIds[0];

                    query = query.Where(x => x.ObjectDummyOneToManyId == dataObjectDummyOneToManyId);
                }
            }

            if (!string.IsNullOrWhiteSpace(input.DataObjectDummyOneToManyName))
            {
                query = query.Where(x => x.ObjectDummyOneToMany.Name.Contains(input.DataObjectDummyOneToManyName));
            }

            return query;
        }

        /// <summary>
        /// Мод "DummyMain". Основа. Расширение. Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<DataEntityObjectDummyMain> ModDummyMainBaseExtApplySorting(
            this IQueryable<DataEntityObjectDummyMain> query,
            ModDummyMainBaseJobListGetInput input
            )
        {
            var sortField = input.SortField.ToLower();
            var sortDirection = input.SortDirection.ToLower();

            DataEntityObjectDummyMain obj;

            var sortFieldForId = nameof(obj.Id).ToLower();
            var sortFieldForName = nameof(obj.Name).ToLower();
            var sortFieldForObjectDummyOneToMany = nameof(obj.ObjectDummyOneToMany).ToLower();
            var sortFieldForPropDate = nameof(obj.PropDate).ToLower();
            var sortFieldForPropBoolean = nameof(obj.PropBoolean).ToLower();

            if (sortField == sortFieldForId)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Id);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Id);
                        break;
                }
            } else if (sortField == sortFieldForName)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Name);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Name);
                        break;
                }
            } else if (sortField == sortFieldForObjectDummyOneToMany)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.ObjectDummyOneToMany.Name);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.ObjectDummyOneToMany.Name);
                        break;
                }
            } else if (sortField == sortFieldForPropDate)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropDate);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropDate);
                        break;
                }
            } else if (sortField == sortFieldForPropBoolean)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropBoolean);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropBoolean);
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != sortFieldForId)
            {
                query = ((IOrderedQueryable<DataEntityObjectDummyMain>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}