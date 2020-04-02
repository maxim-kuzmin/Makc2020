//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
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
            ModDummyTreeBaseJobItemGetInput input
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
            if (input.DataLevel.HasValue && input.DataLevel.Value > -1)
            {
                query = query.Where(x => x.Level <= input.DataLevel.Value);
            }

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
            var sortField = input.DataSortField.ToLower();
            var sortDirection = input.DataSortDirection.ToLower();

            switch (sortField)
            {
                case "id":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Id);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Id);
                            break;
                    }
                    break;
                case "name":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.Name);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.Name);
                            break;
                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != "id")
            {
                query = ((IOrderedQueryable<DataEntityObjectDummyTree>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}