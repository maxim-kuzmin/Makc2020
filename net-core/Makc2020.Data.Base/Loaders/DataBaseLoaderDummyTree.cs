//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "DummyTree".
    /// </summary>
    public class DataBaseLoaderDummyTree : CoreBaseDataLoader<DataBaseObjectDummyTree>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderDummyTree(DataBaseObjectDummyTree data = null)
            : base(data ?? new DataBaseObjectDummyTree())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectDummyTree source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.ParentId)))
            {
                Data.ParentId = source.ParentId;
            }

            if (props.Contains(nameof(Data.ChildCount)))
            {
                Data.ChildCount = source.ChildCount;
            }

            if (props.Contains(nameof(Data.DescendantCount)))
            {
                Data.DescendantCount = source.DescendantCount;
            }

            if (props.Contains(nameof(Data.ObjectDummyMainId)))
            {
                Data.ObjectDummyMainId = source.ObjectDummyMainId;
            }

            if (props.Contains(nameof(Data.Level)))
            {
                Data.Level = source.Level;
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
                nameof(Data.ParentId),
                nameof(Data.ChildCount),
                nameof(Data.DescendantCount),
                nameof(Data.ObjectDummyMainId),
                nameof(Data.Level)
            };
        }

        #endregion Protected methods
    }
}
