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

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.Name;
            }

            if (props.Contains(nameof(Data.ParentId)))
            {
                Data.ParentId = source.ParentId;
            }

            if (props.Contains(nameof(Data.TreeChildCount)))
            {
                Data.TreeChildCount = source.TreeChildCount;
            }

            if (props.Contains(nameof(Data.TreeDescendantCount)))
            {
                Data.TreeDescendantCount = source.TreeDescendantCount;
            }

            if (props.Contains(nameof(Data.TreeLevel)))
            {
                Data.TreeLevel = source.TreeLevel;
            }

            if (props.Contains(nameof(Data.TreePath)))
            {
                Data.TreePath = source.TreePath;
            }

            if (props.Contains(nameof(Data.TreeSort)))
            {
                Data.TreeSort = source.TreeSort;
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
                nameof(Data.ParentId),
                nameof(Data.TreeChildCount),
                nameof(Data.TreeDescendantCount),                
                nameof(Data.TreeLevel),
                nameof(Data.TreePath),
                nameof(Data.TreeSort)
            };
        }

        #endregion Protected methods
    }
}
