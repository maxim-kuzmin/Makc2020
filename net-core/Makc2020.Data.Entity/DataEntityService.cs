//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Data.Queries.Tree;
using Makc2020.Core.Base.Common.Enums;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Data.Queries.Tree.Trigger;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base;
using Makc2020.Data.Base.Settings;
using Makc2020.Data.Entity.Config;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Сервис.
    /// </summary>
    public class DataEntityService
    {
        #region Properties

        private IDataEntityConfigSettings ConfigSettings { get; set; }

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
        public DataEntityService(
            IDataEntityConfigSettings configSettings,
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
        /// Мигрировать базу данных.
        /// </summary>
        public async Task MigrateDatabase()
        {
            using var dbContext = CreateDbContext();

            await dbContext.Database.MigrateAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        public async Task SeedTestData()
        {
            using var dbContext = CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            var isOk = await dbContext.DummyMain.AnyAsync().CoreBaseExtTaskWithCurrentCulture(false);

            if (!isOk)
            {
                var itemsOfDummyOneToMany = await SeedTestDataForDummyOneToMany(dbContext)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var itemsOfDummyMain = await SeedTestDataForDummyMain(dbContext, itemsOfDummyOneToMany)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var itemsOfDummyManyToMany = await SeedTestDataForDummyManyToMany(dbContext)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                await SeedTestDataForDummyMainDummyManyToMany(dbContext, itemsOfDummyMain, itemsOfDummyManyToMany)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                await SeedTestDataForDummyTree(dbContext).CoreBaseExtTaskWithCurrentCulture(false);
            }

            await transaction.CommitAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods

        #region Private methods

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

        private DataEntityObjectDummyMain CreateTestDataItemForDummyMain(
            long index,
            IEnumerable<DataEntityObjectDummyOneToMany> itemsOfDummyOneToMany
            )
        {
            var isEven = index % 2 == 0;

            var day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime,
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            var indexOfDummyOneToMany = GetRandomIndex(itemsOfDummyOneToMany);

            return new DataEntityObjectDummyMain
            {
                Name = $"Name-{index}",
                ObjectDummyOneToManyId = itemsOfDummyOneToMany.ElementAt(indexOfDummyOneToMany).Id,
                PropBoolean = isEven,
                PropBooleanNullable = isEven ? new bool?(!isEven) : null,
                PropDate = new DateTime(2018, 01, day),
                PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
                PropDateTimeOffset = dateAndOffsetLocal,
                PropDateTimeOffsetNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
                PropDecimal = 1000M + index + (index / 100M),
                PropDecimalNullable = isEven ? new decimal?(2000M + index + (index / 200M)) : null,
                PropInt32 = 1000 + (int)index,
                PropInt32Nullable = isEven ? new int?(1000 + (int)index) : null,
                PropInt64 = 3000 + index,
                PropInt64Nullable = isEven ? new long?(3000 + index) : null,
                PropString = $"PropString-{index}",
                PropStringNullable = isEven ? $"PropStringNullable-{index}" : null
            };
        }

        private List<DataEntityObjectDummyMainDummyManyToMany> CreateTestDataItemsForDummyMainDummyManyToMany(
            DataEntityObjectDummyMain itemOfDummyMain,
            IEnumerable<DataEntityObjectDummyManyToMany> itemsOfDummyManyToMany
            )
        {
            var result = new List<DataEntityObjectDummyMainDummyManyToMany>();

            foreach (var itemOfDummyManyToMany in itemsOfDummyManyToMany)
            {
                var isEven = GetRandomIndex(itemsOfDummyManyToMany) % 2 == 0;

                if (isEven) continue;

                var item = new DataEntityObjectDummyMainDummyManyToMany
                {
                    ObjectDummyMainId = itemOfDummyMain.Id,
                    ObjectDummyManyToManyId = itemOfDummyManyToMany.Id
                };

                result.Add(item);
            }

            if (!result.Any())
            {
                var index = GetRandomIndex(itemsOfDummyManyToMany);

                var item = new DataEntityObjectDummyMainDummyManyToMany
                {
                    ObjectDummyMainId = itemOfDummyMain.Id,
                    ObjectDummyManyToManyId = itemsOfDummyManyToMany.ElementAt(index).Id
                };

                result.Add(item);
            }

            return result;
        }

        private DataEntityObjectDummyManyToMany CreateTestDataItemForDummyManyToMany(long index)
        {
            return new DataEntityObjectDummyManyToMany
            {
                Name = $"Name-{index}"
            };
        }

        private DataEntityObjectDummyOneToMany CreateTestDataItemForDummyOneToMany(long index)
        {
            return new DataEntityObjectDummyOneToMany
            {
                Name = $"Name-{index}"
            };
        }

        private DataEntityObjectDummyTree CreateTestDataItemForDummyTree(IEnumerable<int> indexes, long? parentId)
        {
            var suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

            return new DataEntityObjectDummyTree
            {
                Name = $"Name{suffix}",
                ParentId = parentId
            };
        }

        private int GetRandomIndex<T>(IEnumerable<T> items)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(0, items.Count());
        }

        private async Task SaveTestDataListForDummyTree(
            DataEntityDbContext dbContext,
            List<DataEntityObjectDummyTree> list,
            List<int> parentIndexes,
            long? parentId
            )
        {
            if (parentIndexes.Count == 5)
            {
                return;
            }

            var indexes = new List<int>();

            if (parentIndexes.Any())
            {
                indexes.AddRange(parentIndexes);
            }

            for (var index = 1; index < 4; index++)
            {
                indexes.Add(index);

                var item = CreateTestDataItemForDummyTree(indexes, parentId);

                list.Add(item);

                dbContext.DummyTree.Add(item);

                await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

                await SaveTestDataListForDummyTree(dbContext, list, indexes, item.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                indexes.RemoveAt(indexes.Count - 1);
            }
        }

        private async Task<IEnumerable<DataEntityObjectDummyMain>> SeedTestDataForDummyMain(
            DataEntityDbContext dbContext,
            IEnumerable<DataEntityObjectDummyOneToMany> itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            dbContext.DummyMain.AddRange(result);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<IEnumerable<DataEntityObjectDummyMainDummyManyToMany>> SeedTestDataForDummyMainDummyManyToMany(
            DataEntityDbContext dbContext,
            IEnumerable<DataEntityObjectDummyMain> itemsOfDummyMain,
            IEnumerable<DataEntityObjectDummyManyToMany> itemsOfDummyManyToMany
            )
        {
            var result = new List<DataEntityObjectDummyMainDummyManyToMany>();

            foreach (var itemOfDummyMain in itemsOfDummyMain)
            {
                var itemsOfDummyMainDummyManyToMany = CreateTestDataItemsForDummyMainDummyManyToMany(
                    itemOfDummyMain,
                    itemsOfDummyManyToMany
                    );

                if (itemsOfDummyMainDummyManyToMany.Any())
                {
                    result.AddRange(itemsOfDummyMainDummyManyToMany);
                }
            }

            dbContext.AddRange(result);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<IEnumerable<DataEntityObjectDummyManyToMany>> SeedTestDataForDummyManyToMany(
            DataEntityDbContext dbContext
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyManyToMany(index))
                .ToArray();

            dbContext.DummyManyToMany.AddRange(result);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<IEnumerable<DataEntityObjectDummyOneToMany>> SeedTestDataForDummyOneToMany(
            DataEntityDbContext dbContext
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyOneToMany(index))
                .ToArray();

            dbContext.DummyOneToMany.AddRange(result);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<IEnumerable<DataEntityObjectDummyTree>> SeedTestDataForDummyTree(
            DataEntityDbContext dbContext
            )
        {
            var result = new List<DataEntityObjectDummyTree>();

            await SaveTestDataListForDummyTree(dbContext, result, new List<int>(), null)
                .CoreBaseExtTaskWithCurrentCulture(false);

            //makc//!!!//>//Убрать комментарии, когда закончу адаптировать запросы//
            //var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(CoreBaseCommonEnumSqlTriggerActions.None);

            //var sql = queryTreeTriggerBuilder.GetResultSql();

            //await dbContext.Database.ExecuteSqlRawAsync(sql).CoreBaseExtTaskWithCurrentCulture(false);
            //makc//!!!//<//

            return result;
        }

        #endregion Private methods
    }
}
