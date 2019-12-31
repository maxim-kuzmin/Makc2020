//Author Maxim Kuzmin//makc//

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
                query = query.Where(x => input.DataIds.Contains(x.Id));
            }

            if (input.DataObjectDummyOneToManyId > 0)
            {
                query = query.Where(x => x.ObjectDummyOneToManyId == input.DataObjectDummyOneToManyId);
            }

            if (input.DataObjectDummyOneToManyIds != null && input.DataObjectDummyOneToManyIds.Any())
            {
                query = query.Where(x => input.DataObjectDummyOneToManyIds.Contains(x.ObjectDummyOneToManyId));
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
                case "objectdummyonetomany":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.ObjectDummyOneToMany.Name);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.ObjectDummyOneToMany.Name);
                            break;
                    }
                    break;
                case "propdate":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.PropDate);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.PropDate);
                            break;
                    }
                    break;
                case "propboolean":
                    switch (sortDirection)
                    {
                        case "asc":
                            query = query.OrderBy(x => x.PropBoolean);
                            break;
                        case "desc":
                            query = query.OrderByDescending(x => x.PropBoolean);
                            break;
                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != "id")
            {
                query = ((IOrderedQueryable<DataEntityObjectDummyMain>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}