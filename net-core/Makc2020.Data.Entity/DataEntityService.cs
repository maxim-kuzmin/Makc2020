//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Data.Entity.Config;
using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Сервис.
    /// </summary>
    public class DataEntityService
    {
        #region Properties

        private IDataEntityConfigSettings ConfigSettings { get; set; }

        private DataEntityDbFactory DbFactory { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        /// <param name="dbFactory">Фабрика базы данных.</param>
        public DataEntityService(
            IDataEntityConfigSettings configSettings,
            DataEntityDbFactory dbFactory
            )
        {
            ConfigSettings = configSettings;
            DbFactory = dbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        public async Task SeedTestData()
        {
            using var source = CreateDbContext();

            var isOk = await source.DummyMain.AnyAsync().CoreBaseExtTaskWithCurrentCulture(false);

            if (isOk)
            {
                return;
            }

            using var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var itemsOfDummyOneToMany = await SeedTestDataForDummyOneToMany(source)
                .CoreBaseExtTaskWithCurrentCulture(false);

            var itemsOfDummyMain = await SeedTestDataForDummyMain(source)
                .CoreBaseExtTaskWithCurrentCulture(false);

            if (itemsOfDummyMain == null)
            {
                return;
            }

            ts.Complete();
        }

        /// <summary>
        /// Мигрировать базу данных.
        /// </summary>
        public async Task MigrateDatabase()
        {
            using var source = CreateDbContext();

            await source.Database.MigrateAsync().CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods

        #region Private methods

        private DataEntityDbContext CreateDbContext()
        {
            var result = DbFactory.CreateDbContext();

            result.Database.SetCommandTimeout(ConfigSettings.DbCommandTimeout);

            return result;
        }

        private DataEntityObjectDummyMain CreateTestDataItemForDummyMain(
            long index,
            DataEntityObjectDummyOneToMany[] itemsOfDummyOneToMany
            )
        {
            var isEven = index % 2 == 0;

            var day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime,
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            var indexOfDummyOneToMany =  new Random(
                Guid.NewGuid().GetHashCode()
                ).Next(0, itemsOfDummyOneToMany.Length);

            return new DataEntityObjectDummyMain
            {
                Name = $"Name-{index}",
                ObjectDummyOneToManyId = itemsOfDummyOneToMany[indexOfDummyOneToMany].Id,
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

        private DataEntityObjectDummyOneToMany CreateTestDataItemForDummyOneToMany(long index)
        {
            return new DataEntityObjectDummyOneToMany
            {
                Id = index,
                Name = $"Name-{index}"
            };
        }

        private async Task<DataEntityObjectDummyMain[]> SeedTestDataForDummyMain(
            DataEntityDbContext source,
            DataEntityObjectDummyOneToMany[] itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            source.DummyMain.AddRange(result);

            await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        private async Task<DataEntityObjectDummyOneToMany[]> SeedTestDataForDummyOneToMany(DataEntityDbContext source)
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyOneToMany(index))
                .ToArray();

            source.DummyOneToMany.AddRange(result);

            await source.SaveChangesAsync().CoreBaseExtTaskWithCurrentCulture(false);

            return result;
        }

        #endregion Private methods
    }
}
