//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Ext;
using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Makc2020.Mods.DummyTree.Base.Config;
using Makc2020.Mods.DummyTree.Base.Ext;
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
        public ModDummyTreeBaseService(
            IModDummyTreeBaseConfigSettings configSettings,
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
        public async Task<ModDummyTreeBaseJobItemGetOutput> GetItem(
            ModDummyTreeBaseJobItemGetInput input
            )
        {
            ModDummyTreeBaseJobItemGetOutput result = null;

            var dbContext = CreateDbContext();

            var entityDummyTree = await dbContext.DummyTree
                .ModDummyTreeBaseExtApplyFiltering(input)
                .FirstOrDefaultAsync()
                .CoreBaseExtTaskWithCurrentCulture(false);

            //var entityDummy = await (
            //    from r in dbContext.DummyTree
            //    join k in dbContext.DummyTreeLink
            //    on new { r.Id, ParentId = 0L } equals new { k.Id, k.ParentId }
            //    select new DataEntityObjectDummyTree
            //    {
            //        TreeChildCount = r.TreeChildCount,
            //        TreeDescendantCount = r.TreeDescendantCount,
            //        Id = r.Id,
            //        TreeLevel = k.Level,
            //        Name = r.Name,
            //        ParentId = r.ParentId
            //    })
            //    .ModDummyTreeBaseExtApplyFiltering(input)
            //    .FirstOrDefaultAsync()
            //    .CoreBaseExtTaskWithCurrentCulture(false);

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

            var queryOfItems = dbContext.DummyTree
                .ModDummyTreeBaseExtApplyFiltering(input)
                .ModDummyTreeBaseExtApplySorting(input)
                .CoreBaseCommonModExtApplyPagination(input);

            var queryOfTotalCount = dbContextForTotalCount.DummyTree
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

            var obj = await dbContext.DummyTree.FirstAsync(
                x => x.Id == input.DataId
                ).CoreBaseExtTaskWithCurrentCulture(false);

            dbContext.DummyTree.Remove(obj);

            await dbContext.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);
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

        private async Task<DataBaseObjectDummyTree> SaveObjectDummyTree(
            DataBaseObjectDummyTree obj
            )
        {
            DataBaseObjectDummyTree result = null;

            using var dbContext = CreateDbContext();

            if (obj.Id > 0)
            {
                result = await dbContext.DummyTree
                    .FirstAsync(x => x.Id == obj.Id)
                    .CoreBaseExtTaskWithCurrentCulture(false);

                var loader = new DataBaseLoaderDummyTree(result);

                loader.LoadDataFrom(obj);
            }
            else
            {
                var entity = DataEntityObjectDummyTree.Create(obj);

                var entry = dbContext.DummyTree.Add(entity);

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