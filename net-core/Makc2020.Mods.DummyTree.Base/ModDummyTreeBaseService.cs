//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Data.Queries.Tree;
using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Common.Enums.Tree.Item;
using Makc2020.Core.Base.Common.Enums.Tree.List;
using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Common.Ext;
using Makc2020.Core.Base.Common.Jobs.Tree.Item.Get;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Data.Queries.Tree.Calculate;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using Makc2020.Data.Base.Settings;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyTree.Base.Config;
using Makc2020.Mods.DummyTree.Base.Ext;
using Makc2020.Mods.DummyTree.Base.Jobs.Calculate;
using Makc2020.Mods.DummyTree.Base.Jobs.Filtered.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Delete;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Delete;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Сервис.
    /// </summary>
    public class ModDummyTreeBaseService
    {
        #region Properties

        private IModDummyTreeBaseConfigSettings ConfigSettings { get; set; }

        private ICoreBaseDataProvider DataProvider { get; set; }

        private DataBaseSettings DataSettings { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="dataProvider">Поставщик данных.</param>
        /// <param name="dataSettings">Настройки данных.</param>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public ModDummyTreeBaseService(
            IModDummyTreeBaseConfigSettings configSettings,
            ICoreBaseDataProvider dataProvider,
            DataBaseSettings dataSettings,
            DataEntityDbFactory dbFactory
            )
        {
            ConfigSettings = configSettings;
            DataProvider = dataProvider;
            DataSettings = dataSettings;
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Вычислить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task Calculate(ModDummyTreeBaseJobCalculateInput input)
        {
            using var dbContext = CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var queryTreeCalculateBuilder = CreateQueryTreeCalculateBuilder();

            var paramIds = queryTreeCalculateBuilder.Parameters.Ids;

            var dataIds = input.DataIds;

            if (dataIds != null && dataIds.Length > 0)
            {
                for (var i = 0; i < dataIds.Length; i++)
                {
                    paramIds.Add(DataProvider.CreateDbParameter($"Id{i}", dataIds[i]));
                }
            }

            var sql = queryTreeCalculateBuilder.GetResultSql();

            await dbContext.Database.ExecuteSqlRawAsync(sql, paramIds).CoreBaseExtTaskWithCurrentCulture(false);

            await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteItem(ModDummyTreeBaseJobItemDeleteInput input)
        {
            using var dbContext = CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var obj = await dbContext.DummyTree.FirstOrDefaultAsync(
                x => x.Id == input.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            if (obj != null)
            {
                var items = new[] { obj.Name };

                try
                {
                    dbContext.DummyTree.Remove(obj);

                    await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

                    var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(CoreBaseCommonEnumSqlTriggerActions.Delete);

                    var paramIds = queryTreeTriggerBuilder.Parameters.Ids;

                    paramIds.Add(DataProvider.CreateDbParameter("Id", input.DataId));

                    var sql = queryTreeTriggerBuilder.GetResultSql();

                    await dbContext.Database.ExecuteSqlRawAsync(sql, paramIds).CoreBaseExtTaskWithCurrentCulture(false);
                }
                catch (DbUpdateException)
                {
                    throw new CoreBaseCommonExceptionNonDeleted(null, items, null);
                }
                catch (Exception ex)
                {
                    throw new CoreBaseCommonExceptionNonDeleted(items, null, ex);
                }

                input.DataName = obj.Name;
            }

            await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Удалить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteList(ModDummyTreeBaseJobListDeleteInput input)
        {
            var deletedItems = new List<string>();
            var failedItems = new List<string>();
            var relatedItems = new List<string>();

            Exception exception = null;

            var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(CoreBaseCommonEnumSqlTriggerActions.Delete);

            var paramIds = queryTreeTriggerBuilder.Parameters.Ids;

            for (var i = 0; i < input.DataIds.Length; i++)
            {
                var dataId = input.DataIds[i];

                if (dataId < 1)
                {
                    continue;
                }

                using var dbContext = CreateDbContext();

                using var transaction = await dbContext.Database.BeginTransactionAsync()
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var obj = await dbContext.DummyTree.FirstOrDefaultAsync(
                    x => x.Id == dataId
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                if (obj != null)
                {
                    try
                    {
                        dbContext.DummyTree.Remove(obj);

                        await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

                        deletedItems.Add(obj.Name);

                        paramIds.Add(DataProvider.CreateDbParameter("Id", dataId));
                    }
                    catch (DbUpdateException)
                    {
                        relatedItems.Add(obj.Name);
                    }
                    catch (Exception ex)
                    {
                        failedItems.Add(obj.Name);

                        if (exception == null)
                        {
                            exception = ex;
                        }
                    }
                }
                else
                {
                    deletedItems.Add(input.DataNames[i]);
                }

                await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            input.DeletedItems = deletedItems;

            if (failedItems.Any() || relatedItems.Any() || exception != null)
            {
                input.Exception = new CoreBaseCommonExceptionNonDeleted(failedItems, relatedItems, exception);
            }

            if (paramIds.Any())
            {
                var sql = queryTreeTriggerBuilder.GetResultSql();

                using var dbContext = CreateDbContext();

                await dbContext.Database.ExecuteSqlRawAsync(sql, paramIds).CoreBaseExtTaskWithCurrentCulture(false);
            }
        }

        /// <summary>
        /// Получить отфильтрованное.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyTreeBaseJobFilteredGetOutput> GetFiltered(
            ModDummyTreeBaseJobListGetInput input
            )
        {
            var result = new ModDummyTreeBaseJobFilteredGetOutput();

            using var dbContext = CreateDbContext();

            var items = await CreateListQuery(dbContext, input.Axis, input.RootId, input.OpenIds)
                .ModDummyTreeBaseExtApplyFiltering(input)
                .Select(x => new { x.Id, x.Name })
                .ToArrayAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var length = items.Length;

            if (length > 0)
            {
                result.DataIds = new long[length];
                result.DataNames = new string[length];

                for (var i = 0; i < length; i++)
                {
                    var item = items[i];

                    result.DataIds[i] = item.Id;
                    result.DataNames[i] = item.Name;
                }
            }

            return result;
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyTreeBaseJobItemGetOutput> GetItem(
            CoreBaseCommonJobTreeItemGetInput input
            )
        {
            ModDummyTreeBaseJobItemGetOutput result = null;

            var dbContext = CreateDbContext();

            var entityDummyTree = await CreateItemQuery(dbContext, input.Axis, input.RootId)
                .FirstOrDefaultAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (entityDummyTree != null)
            {
                result = CreateItem(entityDummyTree);
            }

            return result;
        }

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyTreeBaseJobListGetOutput> GetList(
            ModDummyTreeBaseJobListGetInput input
            )
        {
            var result = new ModDummyTreeBaseJobListGetOutput();

            using var dbContext = CreateDbContext();
            using var dbContextForTotalCount = CreateDbContext();

            var queryOfItems = CreateListQuery(dbContext, input.Axis, input.RootId, input.OpenIds)
                .ModDummyTreeBaseExtApplyFiltering(input)
                .ModDummyTreeBaseExtApplySorting(input)
                .CoreBaseCommonModExtApplyPagination(input);

            var queryOfTotalCount = CreateListQuery(dbContextForTotalCount, input.Axis, input.RootId, input.OpenIds)
                .ModDummyTreeBaseExtApplyFiltering(input);

            var taskOfItems = queryOfItems.ToArrayAsync();
            var taskOfTotalCount = queryOfTotalCount.CountAsync();

            await Task.WhenAll(taskOfItems, taskOfTotalCount).CoreBaseExtTaskWithCurrentCulture(false);

            result.Items = taskOfItems.Result.Select(x => CreateItem(x)).ToArray();
            result.TotalCount = taskOfTotalCount.Result;

            return result;
        }

        /// <summary>
        /// Сохранить элемент.
        /// </summary>
        /// <param name="data">Данные для сохранения.</param>
        /// <returns>Задача с сохранёнными данными.</returns>
        public async Task<ModDummyTreeBaseJobItemGetOutput> SaveItem(ModDummyTreeBaseJobItemGetOutput data)
        {
            var result = new ModDummyTreeBaseJobItemGetOutput();

            if (data.ObjectDummyTree != null)
            {
                result.ObjectDummyTree = await SaveObjectDummyTree(
                    data.ObjectDummyTree
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (result.ObjectDummyTree.Id > 0)
            {
                var input = new CoreBaseCommonJobTreeItemGetInput
                {
                    RootId = result.ObjectDummyTree.Id
                };

                result = await GetItem(input);
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private ModDummyTreeBaseJobItemGetOutput CreateItem(DataEntityObjectDummyTree entity)
        {
            var result = new ModDummyTreeBaseJobItemGetOutput
            {
                ObjectDummyTree = entity.CreateObjectDummyTree(),
            };

            return result;
        }

        private IQueryable<DataEntityObjectDummyTree> CreateItemQuery(
            DataEntityDbContext dbContext,
            CoreBaseCommonEnumTreeItemAxis axis,
            long rootId
            )
        {
            return axis switch
            {
                CoreBaseCommonEnumTreeItemAxis.Parent =>
                    from t1 in dbContext.DummyTree
                    join t2 in dbContext.DummyTree
                        on t1.Id equals t2.ParentId
                    where
                        t2.Id == rootId
                    select t1,
                CoreBaseCommonEnumTreeItemAxis.Self =>
                    from t in dbContext.DummyTree
                    where
                        t.Id == rootId
                    select t,
                _ => throw new NotImplementedException()
            };
        }

        private IQueryable<DataEntityObjectDummyTree> CreateListQuery(
            DataEntityDbContext dbContext,
            CoreBaseCommonEnumTreeListAxis axis,
            long rootId,
            long[] openIds = null
            )
        {
            if (openIds != null)
            {
                var qOpen = from t in dbContext.DummyTree
                            where
                               t.ParentId.HasValue && openIds.Contains(t.ParentId.Value)
                               ||
                               openIds.Contains(t.Id)
                            select t;

                return axis switch
                {
                    CoreBaseCommonEnumTreeListAxis.All =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.Id
                        join o in qOpen
                            on t.Id equals o.Id into oo
                        from tOpen in oo.DefaultIfEmpty()
                        where
                            k.ParentId == 0
                            &&
                            (
                                tOpen == null && t.TreeLevel == 1
                                ||
                                tOpen != null
                            )
                        select t,
                    CoreBaseCommonEnumTreeListAxis.Descendant =>
                        ((Func<IQueryable<DataEntityObjectDummyTree>>)(() =>
                        {
                            var qRoot = from t in dbContext.DummyTree
                                        where
                                            t.Id == rootId
                                        select t;

                            return from t in dbContext.DummyTree
                                   join k in dbContext.DummyTreeLink
                                       on t.Id equals k.Id
                                   join o in qOpen
                                       on t.Id equals o.Id into oo
                                   from tOpen in oo.DefaultIfEmpty()
                                   from tRoot in qRoot
                                   where
                                       k.ParentId == rootId
                                       &&
                                       k.Id != k.ParentId
                                       &&
                                       (
                                           tOpen == null && t.TreeLevel == tRoot.TreeLevel
                                           ||
                                           tOpen != null
                                       )
                                   select t;
                        }))(),
                    CoreBaseCommonEnumTreeListAxis.DescendantOrSelf =>
                        ((Func<IQueryable<DataEntityObjectDummyTree>>)(() =>
                        {
                            var qRoot = from t in dbContext.DummyTree
                                        where
                                            t.Id == rootId
                                        select t;

                            return from t in dbContext.DummyTree
                                   join k in dbContext.DummyTreeLink
                                       on t.Id equals k.Id
                                   join o in qOpen
                                       on t.Id equals o.Id into oo
                                   from tOpen in oo.DefaultIfEmpty()
                                   from tRoot in qRoot
                                   where
                                       k.ParentId == rootId
                                       &&
                                       (
                                           tOpen == null && t.TreeLevel == tRoot.TreeLevel
                                           ||
                                           tOpen != null
                                       )
                                   select t;
                        }))(),
                    _ => throw new NotImplementedException()
                };
            }
            else
            {
                return axis switch
                {
                    CoreBaseCommonEnumTreeListAxis.None =>
                        from t in dbContext.DummyTree
                        select t,
                    CoreBaseCommonEnumTreeListAxis.All =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.Id
                        where
                            k.ParentId == 0
                        select t,
                    CoreBaseCommonEnumTreeListAxis.Ancestor =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.ParentId
                        where
                            k.Id == rootId
                            &&
                            k.Id != k.ParentId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.AncestorOrSelf =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.ParentId
                        where
                            k.Id == rootId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.Child =>
                        from t in dbContext.DummyTree
                        where
                            t.ParentId == rootId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.ChildOrSelf =>
                        from t in dbContext.DummyTree
                        where
                            t.ParentId == rootId
                            ||
                            t.Id == rootId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.Descendant =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.Id
                        where
                            k.ParentId == rootId
                            &&
                            k.Id != k.ParentId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.DescendantOrSelf =>
                        from t in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t.Id equals k.Id
                        where
                            k.ParentId == rootId
                        select t,
                    CoreBaseCommonEnumTreeListAxis.ParentOrSelf =>
                        from t1 in dbContext.DummyTree
                        join k in dbContext.DummyTreeLink
                            on t1.Id equals k.ParentId
                        join t2 in dbContext.DummyTree
                            on k.Id equals t2.Id
                        where
                            k.Id == rootId
                            &&
                            (
                                t1.TreeLevel == t2.TreeLevel
                                ||
                                t1.TreeLevel == t2.TreeLevel - 1
                            )
                        select t1,
                    _ => throw new NotImplementedException()
                };
            }
        }

        private async Task<DataBaseObjectDummyTree> SaveObjectDummyTree(
            DataBaseObjectDummyTree obj
            )
        {
            DataBaseObjectDummyTree result = null;

            using var dbContext = CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var sqlTriggerAction = CoreBaseCommonEnumSqlTriggerActions.None;

            if (obj.Id > 0)
            {
                result = await dbContext.DummyTree
                    .FirstAsync(x => x.Id == obj.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (result.ParentId != obj.ParentId)
                {
                    sqlTriggerAction = CoreBaseCommonEnumSqlTriggerActions.Update;
                }

                var loader = new DataBaseLoaderDummyTree(result);

                loader.LoadDataFrom(obj);
            }
            else
            {
                sqlTriggerAction = CoreBaseCommonEnumSqlTriggerActions.Insert;

                var entity = DataEntityObjectDummyTree.Create(obj);

                var entry = dbContext.DummyTree.Add(entity);

                result = entry.Entity;
            }

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            if (sqlTriggerAction != CoreBaseCommonEnumSqlTriggerActions.None)
            {
                var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(sqlTriggerAction);

                var paramIds = queryTreeTriggerBuilder.Parameters.Ids;

                paramIds.Add(DataProvider.CreateDbParameter("Id", result.Id));

                var sql = queryTreeTriggerBuilder.GetResultSql();

                await dbContext.Database.ExecuteSqlRawAsync(sql, paramIds).CoreBaseExtTaskWithCurrentCulture(false);
            }

            await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private DataEntityDbContext CreateDbContext()
        {
            var result = DbFactory.CreateDbContext();

            var dbCommandTimeout = ConfigSettings.DbCommandTimeout;

            if (dbCommandTimeout < 1)
            {
                dbCommandTimeout = 3600;
            }

            result.Database.SetCommandTimeout(dbCommandTimeout);

            return result;
        }

        private CoreBaseDataQueryTreeCalculateBuilder CreateQueryTreeCalculateBuilder()
        {
            var result = DataProvider.CreateQueryTreeCalculateBuilder();

            InitQueryBuilder(result, DataSettings.DummyTreeLink, DataSettings.DummyTree);

            return result;
        }

        private CoreBaseDataQueryTreeTriggerBuilder CreateQueryTreeTriggerBuilder(
            CoreBaseCommonEnumSqlTriggerActions action
            )
        {
            var result = DataProvider.CreateQueryTreeTriggerBuilder();

            result.Action = action;

            InitQueryBuilder(result, DataSettings.DummyTreeLink, DataSettings.DummyTree);

            return result;
        }

        private void InitQueryBuilder(
            CoreBaseCommonDataQueryTreeBuilder builder,
            DataBaseSettingDummyTreeLink linkSettings,
            DataBaseSettingDummyTree treeSettings
            )
        {
            builder.LinkTableFieldNameForId = linkSettings.DbColumnNameForId;
            builder.LinkTableFieldNameForParentId = linkSettings.DbColumnNameForParentId;

            builder.LinkTableNameWithoutSchema = linkSettings.DbTable;
            builder.LinkTableSchema = linkSettings.DbSchema;

            builder.TreeTableFieldNameForId = treeSettings.DbColumnNameForId;
            builder.TreeTableFieldNameForParentId = treeSettings.DbColumnNameForParentId;
            builder.TreeTableFieldNameForTreeChildCount = treeSettings.DbColumnNameForTreeChildCount;
            builder.TreeTableFieldNameForTreeDescendantCount = treeSettings.DbColumnNameForTreeDescendantCount;
            builder.TreeTableFieldNameForTreeLevel = treeSettings.DbColumnNameForTreeLevel;
            builder.TreeTableFieldNameForTreePath = treeSettings.DbColumnNameForTreePath;
            builder.TreeTableFieldNameForTreePosition = treeSettings.DbColumnNameForTreePosition;
            builder.TreeTableFieldNameForTreeSort = treeSettings.DbColumnNameForTreeSort;

            builder.TreeTableNameWithoutSchema = treeSettings.DbTable;
            builder.TreeTableSchema = treeSettings.DbSchema;
        }

        #endregion Private methods
    }
}