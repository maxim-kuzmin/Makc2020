//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Common.Ext;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.Item.Get;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.DummyMain.Base.Config;
using Makc2020.Mods.DummyMain.Base.Ext;
using Makc2020.Mods.DummyMain.Base.Jobs.Filtered.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Delete;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Сервис.
    /// </summary>
    public class ModDummyMainBaseService
    {
        #region Properties

        private IModDummyMainBaseConfigSettings ConfigSettings { get; set; }

        private CoreBaseDataHelper DataHelper { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="dataProvider">Поставщик данных.</param>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public ModDummyMainBaseService(
            IModDummyMainBaseConfigSettings configSettings,
            ICoreBaseDataProvider dataProvider,
            DataEntityDbFactory dbFactory
            )
        {
            ConfigSettings = configSettings;
            DataHelper = new CoreBaseDataHelper(dataProvider);
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteItem(ModDummyMainBaseJobItemGetInput input)
        {
            using var dbContext = CreateDbContext();

            var obj = await dbContext.DummyMain.FirstOrDefaultAsync(
                x => x.Id == input.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            if (obj != null)
            {
                var items = new[] { obj.Name };

                try
                {
                    dbContext.DummyMain.Remove(obj);

                    await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
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
        }

        /// <summary>
        /// Удалить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public async Task DeleteList(ModDummyMainBaseJobListDeleteInput input)
        {
            var deletedItems = new List<string>();
            var failedItems = new List<string>();
            var relatedItems = new List<string>();

            Exception exception = null;

            for (var i = 0; i < input.DataIds.Length; i++)
            {
                var dataId = input.DataIds[i];

                if (dataId < 1)
                {
                    continue;
                }

                using var dbContext = CreateDbContext();

                var obj = await dbContext.DummyMain.FirstOrDefaultAsync(
                    x => x.Id == dataId
                    ).CoreBaseExtTaskWithCurrentCulture(false);

                if (obj != null)
                {
                    try
                    {
                        dbContext.DummyMain.Remove(obj);

                        await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

                        deletedItems.Add(obj.Name);
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
            }

            input.DeletedItems = deletedItems;

            if (failedItems.Any() || relatedItems.Any() || exception != null)
            {
                input.Exception = new CoreBaseCommonExceptionNonDeleted(failedItems, relatedItems, exception);
            }
        }

        /// <summary>
        /// Получить отфильтрованное.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseJobFilteredGetOutput> GetFiltered(
            ModDummyMainBaseJobListGetInput input
            )
        {
            var result = new ModDummyMainBaseJobFilteredGetOutput();

            using var dbContext = CreateDbContext();

            var items = await dbContext.DummyMain
                .Include(x => x.ObjectDummyOneToMany)
                .Include(x => x.ObjectsDummyMainDummyManyToMany)
                .ModDummyMainBaseExtApplyFiltering(input)
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
        public async Task<ModDummyMainBaseJobItemGetOutput> GetItem(
            ModDummyMainBaseJobItemGetInput input
            )
        {
            ModDummyMainBaseJobItemGetOutput result = null;

            using var dbContext = CreateDbContext();

            var entityDummyMain = await dbContext.DummyMain
                .Include(x => x.ObjectDummyOneToMany)
                .Include(x => x.ObjectsDummyMainDummyManyToMany)
                .ModDummyMainBaseExtApplyFiltering(input)
                .FirstOrDefaultAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (entityDummyMain != null)
            {
                result = CreateItem(entityDummyMain);

                if (result.ObjectsDummyMainDummyManyToMany != null)
                {
                    var idsOfDummyManyToMany = result.ObjectsDummyMainDummyManyToMany
                        .Select(x => x.ObjectDummyManyToManyId)
                        .ToArray();

                    if (idsOfDummyManyToMany.Any())
                    {
                        var enities = await dbContext.DummyManyToMany
                            .Where(x => idsOfDummyManyToMany.Contains(x.Id))
                            .ToArrayAsync()
                            .CoreBaseExtTaskWithCurrentCulture(false);

                        if (enities.Any())
                        {
                            InitItemDummyManyToMany(result, enities);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseJobListGetOutput> GetList(
            ModDummyMainBaseJobListGetInput input
            )
        {
            var result = new ModDummyMainBaseJobListGetOutput();

            using var dbContext = CreateDbContext();
            using var dbContextForTotalCount = CreateDbContext();

            var queryOfItems = dbContext.DummyMain
                .Include(x => x.ObjectDummyOneToMany)
                .Include(x => x.ObjectsDummyMainDummyManyToMany)
                .ModDummyMainBaseExtApplyFiltering(input)
                .ModDummyMainBaseExtApplySorting(input)
                .CoreBaseCommonModExtApplyPagination(input);

            var queryOfTotalCount = dbContextForTotalCount.DummyMain
                .ModDummyMainBaseExtApplyFiltering(input);

            var taskOfItems = queryOfItems.ToArrayAsync();
            var taskOfTotalCount = queryOfTotalCount.CountAsync();

            await Task.WhenAll(taskOfItems, taskOfTotalCount).CoreBaseExtTaskWithCurrentCulture(false);

            result.Items = taskOfItems.Result.Select(x => CreateItem(x)).ToArray();
            result.TotalCount = taskOfTotalCount.Result;

            if (result.Items.Any())
            {
                var idsDummyManyToMany = result.Items
                    .Where(x => x.ObjectsDummyMainDummyManyToMany != null)
                    .SelectMany(x => x.ObjectsDummyMainDummyManyToMany)
                    .Select(x => x.ObjectDummyManyToManyId)
                    .Distinct()
                    .ToArray();

                if (idsDummyManyToMany.Any())
                {
                    var lookupOfDummyManyToMany = await dbContext.DummyManyToMany
                        .Where(x => idsDummyManyToMany.Contains(x.Id))
                        .ToDictionaryAsync(x => x.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    if (lookupOfDummyManyToMany.Any())
                    {
                        foreach (var item in result.Items)
                        {
                            if (item.ObjectsDummyMainDummyManyToMany != null)
                            {
                                InitItemDummyManyToMany(item, lookupOfDummyManyToMany);
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyManyToMany".
        /// </summary>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseCommonJobOptionListGetOutput> GetOptionsDummyManyToMany()
        {
            var result = new ModDummyMainBaseCommonJobOptionListGetOutput();

            using var dbContext = CreateDbContext();

            var entities = await dbContext.DummyManyToMany.ToArrayAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            result.Items = entities.Select(x => CreateOptionDummyManyToMany(x)).ToArray();

            return result;
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseCommonJobOptionListGetOutput> GetOptionsDummyOneToMany()
        {
            var result = new ModDummyMainBaseCommonJobOptionListGetOutput();

            var dbContext = CreateDbContext();

            var entities = await dbContext.DummyOneToMany.ToArrayAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            result.Items = entities.Select(x => CreateOptionDummyOneToMany(x)).ToArray();

            return result;
        }

        /// <summary>
        /// Сохранить элемент.
        /// </summary>
        /// <param name="data">Данные для сохранения.</param>
        /// <returns>Задача с сохранёнными данными.</returns>
        public async Task<ModDummyMainBaseJobItemGetOutput> SaveItem(ModDummyMainBaseJobItemGetOutput data)
        {
            var result = new ModDummyMainBaseJobItemGetOutput();

            if (data.ObjectDummyMain != null)
            {
                result.ObjectDummyMain = await SaveObjectDummyMain(
                    data.ObjectDummyMain
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (data.ObjectDummyOneToMany != null)
            {
                result.ObjectDummyOneToMany = await SaveObjectDummyOneToMany(
                    data.ObjectDummyOneToMany
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (data.ObjectsDummyManyToMany != null && data.ObjectsDummyManyToMany.Any())
            {
                result.ObjectsDummyManyToMany = await SaveObjectsDummyManyToMany(
                    data.ObjectsDummyManyToMany
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (data.ObjectsDummyMainDummyManyToMany != null && data.ObjectsDummyMainDummyManyToMany.Any())
            {
                result.ObjectsDummyMainDummyManyToMany = await SaveObjectsDummyMainDummyManyToMany(
                    data.ObjectsDummyMainDummyManyToMany
                    ).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (result.ObjectDummyMain.Id > 0)
            {
                result = await GetItem(new ModDummyMainBaseJobItemGetInput { DataId = result.ObjectDummyMain.Id });
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private ModDummyMainBaseJobItemGetOutput CreateItem(DataEntityObjectDummyMain entity)
        {
            var result = new ModDummyMainBaseJobItemGetOutput
            {
                ObjectDummyMain = entity.CreateObjectDummyMain(),
                ObjectDummyOneToMany = entity.ObjectDummyOneToMany.CreateObjectDummyOneToMany()
            };

            if (entity.ObjectsDummyMainDummyManyToMany.Any())
            {
                result.ObjectsDummyMainDummyManyToMany = entity.ObjectsDummyMainDummyManyToMany.Select(
                    x => x.CreateObjectDummyMainDummyManyToMany()
                    ).ToArray();
            }

            return result;
        }

        private ModDummyMainBaseCommonJobOptionItemGetOutput CreateOptionDummyManyToMany(
            DataEntityObjectDummyManyToMany entity
            )
        {
            return new ModDummyMainBaseCommonJobOptionItemGetOutput
            {
                Name = entity.Name,
                Value = entity.Id
            };
        }

        private ModDummyMainBaseCommonJobOptionItemGetOutput CreateOptionDummyOneToMany(
            DataEntityObjectDummyOneToMany entity
            )
        {
            return new ModDummyMainBaseCommonJobOptionItemGetOutput
            {
                Name = entity.Name,
                Value = entity.Id
            };
        }

        private void InitItemDummyManyToMany(
            ModDummyMainBaseJobItemGetOutput item,
            IEnumerable<DataEntityObjectDummyManyToMany> enities
            )
        {
            item.ObjectsDummyManyToMany = enities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.CreateObjectDummyManyToMany())
                .ToArray();
        }

        private void InitItemDummyManyToMany(
            ModDummyMainBaseJobItemGetOutput item,
            IDictionary<long, DataEntityObjectDummyManyToMany> lookup
            )
        {
            var ids = item.ObjectsDummyMainDummyManyToMany
                .Select(x => x.ObjectDummyManyToManyId)
                .ToArray();

            var entities = new List<DataEntityObjectDummyManyToMany>();

            foreach (var id in ids)
            {
                if (lookup.TryGetValue(id, out DataEntityObjectDummyManyToMany entity))
                {
                    entities.Add(entity);
                }
            }

            if (entities.Any())
            {
                InitItemDummyManyToMany(item, entities);
            }
        }

        private async Task<DataBaseObjectDummyMain> SaveObjectDummyMain(
            DataBaseObjectDummyMain obj
            )
        {
            DataBaseObjectDummyMain result = null;

            using var dbContext = CreateDbContext();

            if (obj.Id > 0)
            {
                result = await dbContext.DummyMain
                    .FirstAsync(x => x.Id == obj.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var loader = new DataBaseLoaderDummyMain(result);

                loader.LoadDataFrom(obj);
            }
            else
            {
                var entity = DataEntityObjectDummyMain.Create(obj);

                var entry = dbContext.DummyMain.Add(entity);

                result = entry.Entity;
            }

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<DataBaseObjectDummyOneToMany> SaveObjectDummyOneToMany(
            DataBaseObjectDummyOneToMany obj
            )
        {
            DataBaseObjectDummyOneToMany result = null;

            using var dbContext = CreateDbContext();

            if (obj.Id > 0)
            {
                result = await dbContext.DummyOneToMany
                    .FirstAsync(x => x.Id == obj.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var loader = new DataBaseLoaderDummyOneToMany(result);

                loader.LoadDataFrom(obj);
            }
            else
            {
                var entity = DataEntityObjectDummyOneToMany.Create(obj);

                var entry = dbContext.DummyOneToMany.Add(entity);

                result = entry.Entity;
            }

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<DataBaseObjectDummyManyToMany[]> SaveObjectsDummyManyToMany(
            DataBaseObjectDummyManyToMany[] objects
            )
        {
            var result = new DataBaseObjectDummyManyToMany[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = await SaveObjectDummyManyToMany(objects[i]).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectDummyManyToMany> SaveObjectDummyManyToMany(
            DataBaseObjectDummyManyToMany obj
            )
        {
            DataBaseObjectDummyManyToMany result = null;

            using var dbContext = CreateDbContext();

            if (obj.Id > 0)
            {
                result = await dbContext.DummyManyToMany
                    .FirstAsync(x => x.Id == obj.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var loader = new DataBaseLoaderDummyManyToMany(result);

                loader.LoadDataFrom(obj);
            }
            else
            {
                var entity = DataEntityObjectDummyManyToMany.Create(obj);

                var entry = dbContext.DummyManyToMany.Add(DataEntityObjectDummyManyToMany.Create(obj));

                result = entry.Entity;
            }

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<DataBaseObjectDummyMainDummyManyToMany[]> SaveObjectsDummyMainDummyManyToMany(
            DataBaseObjectDummyMainDummyManyToMany[] objects
            )
        {
            var result = new DataBaseObjectDummyMainDummyManyToMany[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = await SaveObjectDummyMainDummyManyToMany(objects[i])
                    .CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectDummyMainDummyManyToMany> SaveObjectDummyMainDummyManyToMany(
            DataBaseObjectDummyMainDummyManyToMany obj
            )
        {
            DataBaseObjectDummyMainDummyManyToMany result = null;

            using var dbContext = CreateDbContext();

            result = await dbContext.DummyMainDummyManyToMany.FirstOrDefaultAsync(
                x =>
                    x.ObjectDummyMainId == obj.ObjectDummyMainId
                    &&
                    x.ObjectDummyManyToManyId == obj.ObjectDummyManyToManyId
                )
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (result == null)
            {
                var entity = DataEntityObjectDummyMainDummyManyToMany.Create(obj);

                var entry = dbContext.DummyMainDummyManyToMany.Add(entity);

                result = entry.Entity;
            }

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

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

        #endregion Private methods
    }
}