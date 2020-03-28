//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Makc2020.Data.Entity.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace Makc2020.Data.Entity.Schemas
{
    /// <summary>
    /// Данные. Entity Framework. Схемы. Сущность "DummyMain".
    /// </summary>
    public class DataEntitySchemaDummyMain : DataEntitySchema<DataEntityObjectDummyMain>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchemaDummyMain(DataBaseSettings dataBaseSettings)
            : base(dataBaseSettings)
        {
        }        

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Configure(EntityTypeBuilder<DataEntityObjectDummyMain> builder)
        {
            var setting = DataBaseSettings.DummyMain;

            builder.ToTable(setting.DbTable, setting.DbSchema);

            builder.HasKey(x => x.Id).HasName(setting.DbPrimaryKey);            

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.PropBoolean).IsRequired();
            builder.Property(x => x.PropBooleanNullable);
            builder.Property(x => x.PropDate).IsRequired();
            builder.Property(x => x.PropDateNullable);
            builder.Property(x => x.PropDateTimeOffset).IsRequired();
            builder.Property(x => x.PropDateTimeOffsetNullable);
            builder.Property(x => x.PropDecimal).IsRequired();
            builder.Property(x => x.PropDecimalNullable);
            builder.Property(x => x.PropInt32).IsRequired();
            builder.Property(x => x.PropInt32Nullable);
            builder.Property(x => x.PropInt64).IsRequired();
            builder.Property(x => x.PropInt64Nullable);
            builder.Property(x => x.PropString).IsRequired().IsUnicode();
            builder.Property(x => x.PropStringNullable).IsUnicode();

            builder.Property(x => x.ObjectDummyOneToManyId)
                .IsRequired()
                .HasColumnName(setting.DbColumnNameForDummyOneToManyId);

            builder.HasIndex(x => x.Name).IsUnique().HasName(setting.DbUniqueIndexForName);

            builder.HasOne(x => x.ObjectDummyOneToMany)
                .WithMany(x => x.ObjectsDummyMain)
                .HasForeignKey(x => x.ObjectDummyOneToManyId)
                .HasConstraintName(setting.DbForeignKeyToDummyOneToMany);
        }

        /// <summary>
        /// Засеять тестовые данные.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели.</param>
        public static void SeedTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataEntityObjectDummyMain>().HasData(
                Enumerable.Range(1, 100).Select(id => CreateTestDataItem(id)).ToArray()
                );
        }

        #endregion Public methods

        #region Private methods

        private static DataEntityObjectDummyMain CreateTestDataItem(long id)
        {
            var isEven = id % 2 == 0;

            var day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime, 
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            return new DataEntityObjectDummyMain
            {
                Id = id,
                Name = $"Name-{id}",
                ObjectDummyOneToManyId = new Random(Guid.NewGuid().GetHashCode()).Next(1, 10),
                PropBoolean = isEven,
                PropBooleanNullable = isEven ? new bool?(!isEven) : null,
                PropDate = new DateTime(2018, 01, day),
                PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
                PropDateTimeOffset = dateAndOffsetLocal,
                PropDateTimeOffsetNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
                PropDecimal = 1000M + id + (id / 100M),
                PropDecimalNullable = isEven ? new decimal?(2000M + id + (id / 200M)) : null,
                PropInt32 = 1000 + (int)id,
                PropInt32Nullable = isEven ? new int?(1000 + (int)id) : null,
                PropInt64 = 3000 + id,
                PropInt64Nullable = isEven ? new long?(3000 + id) : null,
                PropString = $"PropString-{id}",
                PropStringNullable = isEven ? $"PropStringNullable-{id}" : null
            };
        }

        #endregion Private methods
    }
}