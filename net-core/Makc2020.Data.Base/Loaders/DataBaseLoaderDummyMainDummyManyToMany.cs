//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "DummyMainDummyManyToMany".
    /// </summary>
    public class DataBaseLoaderDummyMainDummyManyToMany : CoreBaseDataLoader<DataBaseObjectDummyMainDummyManyToMany>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderDummyMainDummyManyToMany(DataBaseObjectDummyMainDummyManyToMany data = null)
            : base(data ?? new DataBaseObjectDummyMainDummyManyToMany())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectDummyMainDummyManyToMany source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ObjectDummyMainId)))
            {
                Data.ObjectDummyMainId = source.ObjectDummyMainId;
            }

            if (props.Contains(nameof(Data.ObjectDummyManyToManyId)))
            {
                Data.ObjectDummyManyToManyId = source.ObjectDummyManyToManyId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.ObjectDummyMainId),
                nameof(Data.ObjectDummyManyToManyId)
            };
        }

        #endregion Protected methods
    }
}