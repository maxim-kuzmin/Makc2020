//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "DummyMain".
    /// </summary>
    public class DataBaseLoaderDummyMain : CoreBaseDataLoader<DataBaseObjectDummyMain>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderDummyMain(DataBaseObjectDummyMain data = null)
            : base(data ?? new DataBaseObjectDummyMain())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectDummyMain source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name ?? string.Empty;
            }

            if (props.Contains(nameof(Data.ObjectDummyOneToManyId)))
            {
                Data.ObjectDummyOneToManyId = source.ObjectDummyOneToManyId;
            }

            if (props.Contains(nameof(Data.PropBoolean)))
            {
                Data.PropBoolean = source.PropBoolean;
            }

            if (props.Contains(nameof(Data.PropBooleanNullable)))
            {
                Data.PropBooleanNullable = source.PropBooleanNullable;
            }

            if (props.Contains(nameof(Data.PropDate)))
            {
                Data.PropDate = source.PropDate;
            }

            if (props.Contains(nameof(Data.PropDateNullable)))
            {
                Data.PropDateNullable = source.PropDateNullable;
            }

            if (props.Contains(nameof(Data.PropDateTimeOffset)))
            {
                Data.PropDateTimeOffset = source.PropDateTimeOffset;
            }

            if (props.Contains(nameof(Data.PropDateTimeOffsetNullable)))
            {
                Data.PropDateTimeOffsetNullable = source.PropDateTimeOffsetNullable;
            }

            if (props.Contains(nameof(Data.PropDecimal)))
            {
                Data.PropDecimal = source.PropDecimal;
            }

            if (props.Contains(nameof(Data.PropDecimalNullable)))
            {
                Data.PropDecimalNullable = source.PropDecimalNullable;
            }

            if (props.Contains(nameof(Data.PropInt32)))
            {
                Data.PropInt32 = source.PropInt32;
            }

            if (props.Contains(nameof(Data.PropInt32Nullable)))
            {
                Data.PropInt32Nullable = source.PropInt32Nullable;
            }

            if (props.Contains(nameof(Data.PropInt64)))
            {
                Data.PropInt64 = source.PropInt64;
            }

            if (props.Contains(nameof(Data.PropInt64Nullable)))
            {
                Data.PropInt64Nullable = source.PropInt64Nullable;
            }

            if (props.Contains(nameof(Data.PropString)))
            {
                Data.PropString = source.PropString ?? string.Empty;
            }

            if (props.Contains(nameof(Data.PropStringNullable)))
            {
                Data.PropStringNullable = source.PropStringNullable;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.Id),
                nameof(Data.Name),
                nameof(Data.ObjectDummyOneToManyId),
                nameof(Data.PropBoolean),
                nameof(Data.PropBooleanNullable),
                nameof(Data.PropDate),
                nameof(Data.PropDateNullable),
                nameof(Data.PropDateTimeOffset),
                nameof(Data.PropDateTimeOffsetNullable),
                nameof(Data.PropDecimal),
                nameof(Data.PropDecimalNullable),
                nameof(Data.PropInt32),
                nameof(Data.PropInt32Nullable),
                nameof(Data.PropInt64),
                nameof(Data.PropInt64Nullable),
                nameof(Data.PropString),
                nameof(Data.PropStringNullable)
            };
        }

        #endregion Protected methods
    }
}
