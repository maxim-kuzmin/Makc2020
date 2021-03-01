//Author Maxim Kuzmin//makc//

using Makc2020.Core.Data.Entity;
using Makc2020.Data.Base;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Схема.
    /// </summary>
    public abstract class DataEntitySchema<TEntity> : CoreDataEntitySchema<TEntity, DataBaseSettings>
        where TEntity : class
    {
        #region Constructors

        /// <inheritdoc/>
        public DataEntitySchema(DataBaseSettings settings)
            : base(settings)
        {
        }

        #endregion Constructors
    }
}
