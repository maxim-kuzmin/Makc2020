//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Data.Queries.Tree;
using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Common.Ext;
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
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using Microsoft.EntityFrameworkCore;
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
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyTreeBaseJobItemGetOutput> GetItem(
            ModDummyTreeBaseJobItemGetInput input
        )
        {
            ModDummyTreeBaseJobItemGetOutput result = null;

            var dbContext = CreateDbContext();

            var query = CreateQuery(dbContext, CoreBaseCommonEnumTreeAxis.Self, input.DataId);

            var entityDummyTree = await query.ModDummyTreeBaseExtApplyFiltering(input)
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

            var query = CreateQuery(dbContext, input.Axis, input.RootId);

            var queryOfItems = query.ModDummyTreeBaseExtApplyFiltering(input)
                .ModDummyTreeBaseExtApplySorting(input)
                .CoreBaseCommonModExtApplyPagination(input);

            var queryOfTotalCount = query.ModDummyTreeBaseExtApplyFiltering(input);

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
                result = await GetItem(new ModDummyTreeBaseJobItemGetInput { DataId = result.ObjectDummyTree.Id });
            }

            return result;
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteItem(ModDummyTreeBaseJobItemGetInput input)
        {
            using var dbContext = CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var obj = await dbContext.DummyTree.FirstAsync(
                x => x.Id == input.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            dbContext.DummyTree.Remove(obj);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(CoreBaseCommonEnumSqlTriggerActions.Delete);

            var paramIds = queryTreeTriggerBuilder.Parameters.Ids;

            paramIds.Add(DataProvider.CreateDbParameter("Id", input.DataId));

            var sql = queryTreeTriggerBuilder.GetResultSql();

            await dbContext.Database.ExecuteSqlRawAsync(sql, paramIds).CoreBaseExtTaskWithCurrentCulture(false);

            await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);
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

        private IQueryable<DataEntityObjectDummyTree> CreateQuery(
            DataEntityDbContext dbContext,
            CoreBaseCommonEnumTreeAxis axis,
            long rootId
            )
        {
            return axis switch
            {
                CoreBaseCommonEnumTreeAxis.All =>
                    from t in dbContext.DummyTree
                    join k in dbContext.DummyTreeLink
                        on t.Id equals k.Id
                    where
                        k.ParentId == 0
                    orderby
                        t.TreeSort
                    select t,
                CoreBaseCommonEnumTreeAxis.Ancestor =>
                    from t in dbContext.DummyTree
                    join k in dbContext.DummyTreeLink
                        on t.Id equals k.ParentId
                    where
                        k.Id == rootId
                        &&
                        k.Id != k.ParentId
                    select t,
                CoreBaseCommonEnumTreeAxis.AncestorOrSelf =>
                    from t in dbContext.DummyTree
                    join k in dbContext.DummyTreeLink
                        on t.Id equals k.ParentId
                    where
                        k.Id == rootId
                    select t,
                CoreBaseCommonEnumTreeAxis.Child =>
                    from t in dbContext.DummyTree
                    where
                        t.ParentId == rootId
                    select t,
                CoreBaseCommonEnumTreeAxis.ChildOrSelf =>
                    from t in dbContext.DummyTree
                    where
                        t.ParentId == rootId
                        ||
                        t.Id == rootId
                    select t,
                CoreBaseCommonEnumTreeAxis.Descendant =>
                    from t in dbContext.DummyTree
                    join k in dbContext.DummyTreeLink
                        on t.Id equals k.Id
                    where
                        k.ParentId == rootId
                        &&
                        k.Id != k.ParentId
                    orderby
                        t.TreeSort
                    select t,
                CoreBaseCommonEnumTreeAxis.DescendantOrSelf =>
                    from t in dbContext.DummyTree
                    join k in dbContext.DummyTreeLink
                        on t.Id equals k.Id
                    where
                        k.ParentId == rootId
                    orderby
                        t.TreeSort
                    select t,
                CoreBaseCommonEnumTreeAxis.Parent =>
                    from t1 in dbContext.DummyTree
                    join t2 in dbContext.DummyTree
                        on t1.Id equals t2.ParentId
                    where
                        t2.Id == rootId
                    select t1,
                CoreBaseCommonEnumTreeAxis.ParentOrSelf =>
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
                CoreBaseCommonEnumTreeAxis.Self =>
                    from t in dbContext.DummyTree
                    where
                        t.Id == rootId
                    select t,
                _ => throw new System.NotImplementedException()
            };
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
            builder.LinkTableName = linkSettings.DbTableWithSchema;

            builder.TreeTableFieldNameForId = treeSettings.DbColumnNameForId;
            builder.TreeTableFieldNameForParentId = treeSettings.DbColumnNameForParentId;
            builder.TreeTableFieldNameForTreeChildCount = treeSettings.DbColumnNameForTreeChildCount;
            builder.TreeTableFieldNameForTreeDescendantCount = treeSettings.DbColumnNameForTreeDescendantCount;
            builder.TreeTableFieldNameForTreeLevel = treeSettings.DbColumnNameForTreeLevel;
            builder.TreeTableFieldNameForTreePath = treeSettings.DbColumnNameForTreePath;
            builder.TreeTableFieldNameForTreePosition = treeSettings.DbColumnNameForTreePosition;
            builder.TreeTableFieldNameForTreeSort = treeSettings.DbColumnNameForTreeSort;
            builder.TreeTableName = treeSettings.DbTableWithSchema;
        }

        #endregion Private methods
    }
}