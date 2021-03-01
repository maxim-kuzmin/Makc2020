//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Makc2020.Core.Data.Entity
{
    /// <summary>
    /// Ядро. Данные. Entity Framework. Схема.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TSettings">Тип настроек.</typeparam>
    public abstract class CoreDataEntitySchema<TEntity, TSettings> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Настройки.
        /// </summary>
        protected TSettings Settings { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public CoreDataEntitySchema(TSettings settings)
        {
            Settings = settings;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        #endregion Public methods
    }
}
