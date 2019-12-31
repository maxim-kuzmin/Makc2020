//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;

namespace Makc2020.Data.Base.Loaders
{
    /// <summary>
    /// Данные. Основа. Загрузчики. Сущность "RoleClaim".
    /// </summary>
    public class DataBaseLoaderRoleClaim : CoreBaseDataLoader<DataBaseObjectRoleClaim>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataBaseLoaderRoleClaim(DataBaseObjectRoleClaim data = null)
            : base(data ?? new DataBaseObjectRoleClaim())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="props">Загружаемые свойства.</param>
        public void LoadDataFrom(DataBaseObjectRoleClaim source, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.ClaimType)))
            {
                Data.ClaimType = source.ClaimType;
            }

            if (props.Contains(nameof(Data.ClaimValue)))
            {
                Data.ClaimValue = source.ClaimValue;
            }

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.Id;
            }

            if (props.Contains(nameof(Data.RoleId)))
            {
                Data.RoleId = source.RoleId;
            }
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateLoadableDataProperties()
        {
            return new HashSet<string>
            {                
                nameof(Data.ClaimType),
                nameof(Data.ClaimValue),
                nameof(Data.Id),
                nameof(Data.RoleId)
            };
        }

        #endregion Protected methods
    }
}
