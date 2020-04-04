//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Makc2020.Data.Entity.Db
{
    /// <summary>
    /// Данные. Entity Framework. База данных. Контекст.
    /// </summary>
    public abstract class DataEntityDbContext : IdentityDbContext
        <
            DataEntityObjectUser,
            DataEntityObjectRole,
            long,
            DataEntityObjectUserClaim,
            DataEntityObjectUserRole,
            DataEntityObjectUserLogin,
            DataEntityObjectRoleClaim,
            DataEntityObjectUserToken
        >
    {
        #region Properties        

        /// <summary>
        /// Сущность "DummyMain".
        /// </summary>
        public DbSet<DataEntityObjectDummyMain> DummyMain { get; set; }

        /// <summary>
        /// Сущность "DummyManyToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyManyToMany> DummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyMainDummyManyToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyMainDummyManyToMany> DummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Сущность "DummyOneToMany".
        /// </summary>
        public DbSet<DataEntityObjectDummyOneToMany> DummyOneToMany { get; set; }

        /// <summary>
        /// Сущность "DummyTree".
        /// </summary>
        public DbSet<DataEntityObjectDummyTree> DummyTree { get; set; }

        /// <summary>
        /// Сущность "DummyTreeLink".
        /// </summary>
        public DbSet<DataEntityObjectDummyTreeLink> DummyTreeLink { get; set; }

        #endregion Properties

        #region Constructors

        /// <inheritdoc/>
        public DataEntityDbContext(DbContextOptions<DataEntityDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors
    }
}