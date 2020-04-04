//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "DummyTreeLink".
    /// </summary>
    public class DataBaseLoaderDummyTreeLink : CoreBaseDataLoader<DataBaseObjectDummyTreeLink>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderDummyTreeLink(DataBaseObjectDummyTreeLink data = null)
            : base(data ?? new DataBaseObjectDummyTreeLink())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectDummyTreeLink source, HashSet<string> props = null)
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
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {
                nameof(Data.Id),
                nameof(Data.ParentId)
            };
        }

        #endregion Protected methods
    }
}
