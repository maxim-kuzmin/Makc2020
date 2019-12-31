//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Схема.
    /// </summary>
    public abstract class DataEntitySchema<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        protected DataBaseSettings DataBaseSettings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public DataEntitySchema(DataBaseSettings dataBaseSettings)
        {
            DataBaseSettings = dataBaseSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        #endregion Public methods
    }
}
