//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using System.Linq;

namespace Makc2020.Mods.DummyTree.Base.Ext
{
    /// <summary>
    /// Мод "DummyTree". Основа. Расширение. Применить.
    /// </summary>
    public static class ModDummyTreeBaseExtApply
    {
        #region Public methods

        /// <summary>
        /// Мод "DummyTree". Основа. Расширение. Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<DataEntityObjectDummyTree> ModDummyTreeBaseExtApplyFiltering(
            this IQueryable<DataEntityObjectDummyTree> query,
            ModDummyTreeBaseJobListGetInput input
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

            return query;
        }

        /// <summary>
        /// Мод "DummyTree". Основа. Расширение. Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Ввод.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<DataEntityObjectDummyTree> ModDummyTreeBaseExtApplySorting(
            this IQueryable<DataEntityObjectDummyTree> query,
            ModDummyTreeBaseJobListGetInput input
            )
        {
            var sortField = input.SortField?.ToLower();
            var sortDirection = input.SortDirection?.ToLower();

            DataEntityObjectDummyTree obj;

            var sortFieldForId = nameof(obj.Id).ToLower();
            var sortFieldForName = nameof(obj.Name).ToLower();
            var sortFieldForTreeSort = nameof(obj.TreeSort).ToLower();

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
            }
            else if (sortField == sortFieldForName)
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
            }
            else if (sortField == sortFieldForTreeSort)
            {
                switch (sortDirection)
                {
                    case CoreBaseCommonSettings.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.TreeSort);
                        break;
                    case CoreBaseCommonSettings.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.TreeSort);
                        break;
                }
            }

            var isOk = !string.IsNullOrWhiteSpace(sortField)
                && 
                sortField != sortFieldForId
                &&
                sortField != sortFieldForTreeSort;

            if (isOk)
            {
                query = ((IOrderedQueryable<DataEntityObjectDummyTree>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}