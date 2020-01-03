//Author Maxim Kuzmin//makc//

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
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Microsoft.EntityFrameworkCore;
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
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseJobItemGetOutput> GetItem(
            ModDummyMainBaseJobItemGetInput input
            )
        {
            ModDummyMainBaseJobItemGetOutput result = null;
            
            using (var source = CreateDbContext())
            {
                var entityDummy = await source.DummyMain
                    .Include(x => x.ObjectDummyOneToMany)
                    .Include(x => x.ObjectsDummyMainDummyManyToMany)
                    .ModDummyMainBaseExtApplyFiltering(input)
                    .FirstOrDefaultAsync()
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (entityDummy != null)
                {
                    result = CreateItem(entityDummy);

                    if (result.ObjectsDummyMainDummyManyToMany != null)
                    {
                        var idsOfDummyManyToMany = result.ObjectsDummyMainDummyManyToMany
                            .Select(x => x.ObjectDummyManyToManyId)
                            .ToArray();

                        if (idsOfDummyManyToMany.Any())
                        {
                            var enities = await source.DummyManyToMany
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

            using (var source = CreateDbContext())
            using (var sourceOfTotalCount = CreateDbContext())
            {
                var queryOfItems = source.DummyMain
                    .Include(x => x.ObjectDummyOneToMany)
                    .Include(x => x.ObjectsDummyMainDummyManyToMany)
                    .ModDummyMainBaseExtApplyFiltering(input)
                    .ModDummyMainBaseExtApplySorting(input)
                    .CoreBaseCommonModExtApplyPagination(input);

                var queryOfTotalCount = sourceOfTotalCount.DummyMain
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
                        var lookupOfDummyManyToMany = await source.DummyManyToMany
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

            using (var source = CreateDbContext())
            {
                var entities = await source.DummyManyToMany.ToArrayAsync();

                result.Items = entities.Select(x => CreateOptionDummyManyToMany(x)).ToArray();
            }

            return result;
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Задача с полученными данными.</returns>
        public async Task<ModDummyMainBaseCommonJobOptionListGetOutput> GetOptionsDummyOneToMany()
        {
            var result = new ModDummyMainBaseCommonJobOptionListGetOutput();

            using (var source = CreateDbContext())
            {
                var entities = await source.DummyOneToMany.ToArrayAsync();

                result.Items = entities.Select(x => CreateOptionDummyOneToMany(x)).ToArray();
            }

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
                result.ObjectDummyMain = await SaveObjectDummy(
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

        public async Task DeleteItem(ModDummyMainBaseJobItemGetInput filter)
        {
            using var source = CreateDbContext();

            var obj = await source.DummyMain.FirstAsync(
                x => x.Id == filter.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            source.DummyMain.Remove(obj);

            await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
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

        private ModDummyMainBaseCommonJobOptionItemGetOutput  CreateOptionDummyManyToMany(
            DataEntityObjectDummyManyToMany entity
            )
        {
            return new ModDummyMainBaseCommonJobOptionItemGetOutput 
            {
                Name = entity.Name,
                Value = entity.Id
            };
        }

        private ModDummyMainBaseCommonJobOptionItemGetOutput  CreateOptionDummyOneToMany(
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

        private async Task<DataBaseObjectDummyMain> SaveObjectDummy(
            DataBaseObjectDummyMain obj
            )
        {
            DataBaseObjectDummyMain result = null;

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.DummyMain
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderDummyMain(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectDummyMain.Create(obj);

                    var entry = source.DummyMain.Add(entity);

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectDummyOneToMany> SaveObjectDummyOneToMany(
            DataBaseObjectDummyOneToMany obj
            )
        {
            DataBaseObjectDummyOneToMany result = null;

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.DummyOneToMany
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderDummyOneToMany(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectDummyOneToMany.Create(obj);

                    var entry = source.DummyOneToMany.Add(entity);

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

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

            using (var source = CreateDbContext())
            {
                if (obj.Id > 0)
                {
                    result = await source.DummyManyToMany
                        .FirstAsync(x => x.Id == obj.Id)
                        .CoreBaseExtTaskWithCurrentCulture(false);

                    var loader = new DataBaseLoaderDummyManyToMany(result);

                    loader.LoadDataFrom(obj);
                }
                else
                {
                    var entity = DataEntityObjectDummyManyToMany.Create(obj);

                    var entry = source.DummyManyToMany.Add(DataEntityObjectDummyManyToMany.Create(obj));

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectDummyMainDummyManyToMany[]> SaveObjectsDummyMainDummyManyToMany(
            DataBaseObjectDummyMainDummyManyToMany[] objects
            )
        {
            var result = new DataBaseObjectDummyMainDummyManyToMany[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = await SaveObjectDummyMainDummyManyToMany(objects[i]).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private async Task<DataBaseObjectDummyMainDummyManyToMany> SaveObjectDummyMainDummyManyToMany(
            DataBaseObjectDummyMainDummyManyToMany obj
            )
        {
            DataBaseObjectDummyMainDummyManyToMany result = null;

            using (var source = CreateDbContext())
            {
                result = await source.DummyMainDummyManyToMany.FirstOrDefaultAsync(
                    x =>
                        x.ObjectDummyMainId == obj.ObjectDummyMainId
                        &&
                        x.ObjectDummyManyToManyId == obj.ObjectDummyManyToManyId
                    )
                    .CoreBaseExtTaskWithCurrentCulture(false);

                if (result == null)
                {
                    var entity = DataEntityObjectDummyMainDummyManyToMany.Create(obj);

                    var entry = source.DummyMainDummyManyToMany.Add(entity);

                    result = entry.Entity;
                }

                await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
            }

            return result;
        }

        private DataEntityDbContext CreateDbContext()
        {
            var result = DbFactory.CreateDbContext();

            result.Database.SetCommandTimeout(ConfigSettings.DbCommandTimeout);

            return result;
        }

        #endregion Private methods
    }
}