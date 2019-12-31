//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Db;
using Makc2020.Core.Base.Ext;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Data.Db.Loaders
{
    /// <summary>
    /// Данные. База данных. Загрузчики. Сущность "DummyMain".
    /// </summary>
    public class DataDbLoaderDummyMain : DataBaseLoaderDummyMain, ICoreBaseDataDbLoader
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataDbLoaderDummyMain(DataBaseObjectDummyMain data = null)
            : base(data ?? new DataBaseObjectDummyMain())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="ordinal">Порядковый номер, начиная с которого нужно считывать данные.</param>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Задача с порядковым номером, начиная с которого нужно считывать следующие данные.</returns>
        public async Task<int> LoadDataFrom(DbDataReader source, int ordinal, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = await source.GetFieldValueAsync<string>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.ObjectDummyOneToManyId)))
            {
                Data.ObjectDummyOneToManyId = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropBoolean)))
            {
                Data.PropBoolean = await source.GetFieldValueAsync<bool>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropBooleanNullable)))
            {
                Data.PropBooleanNullable = await source.CoreBaseExtDbDataReadBooleanNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropDate)))
            {
                Data.PropDate = await source.GetFieldValueAsync<DateTime>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropDateNullable)))
            {
                Data.PropDateNullable = await source.CoreBaseExtDbDataReadDateTimeNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropDateTimeOffset)))
            {
                Data.PropDateTimeOffset = await source.GetFieldValueAsync<DateTimeOffset>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropDateTimeOffsetNullable)))
            {
                Data.PropDateTimeOffsetNullable = await source.CoreBaseExtDbDataReadDateTimeOffsetNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropDecimal)))
            {
                Data.PropDecimal = await source.GetFieldValueAsync<decimal>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false); 
            }

            if (props.Contains(nameof(Data.PropDecimalNullable)))
            {
                Data.PropDecimalNullable = await source.CoreBaseExtDbDataReadDecimalNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropInt32)))
            {
                Data.PropInt32 = await source.GetFieldValueAsync<int>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropInt32Nullable)))
            {
                Data.PropInt32Nullable = await source.CoreBaseExtDbDataReadInt32NullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropInt64)))
            {
                Data.PropInt64 = await source.GetFieldValueAsync<long>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropInt64Nullable)))
            {
                Data.PropInt64Nullable = await source.CoreBaseExtDbDataReadInt64NullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropString)))
            {
                Data.PropString = await source.GetFieldValueAsync<string>(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (props.Contains(nameof(Data.PropStringNullable)))
            {
                Data.PropStringNullable = await source.CoreBaseExtDbDataReadStringNullableAsync(ordinal++).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return ordinal;
        }

        #endregion Public methods
    }
}