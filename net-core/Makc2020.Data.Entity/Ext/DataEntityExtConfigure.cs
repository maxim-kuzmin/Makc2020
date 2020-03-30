//Author Maxim Kuzmin//makc//

using Makc2020.Data.Entity.Db;
using Makc2020.Data.Entity.Objects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Data.Entity.Ext
{
    /// <summary>
    /// Данные. Entity Framework. Расширение. Настроить.
    /// </summary>
    public static class DataEntityExtConfigure
    {
        #region Public methods

        /// <summary>
        /// Данные. Entity Framework. Расширение. Настроить. Контекст базы данных.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="funcGetDataEntityDbFactory">Функция получения фабрики базы данных.</param>
        /// <returns>Сервисы.</returns>
        /// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
        public static IServiceCollection DataEntityExtConfigureDbContext<TDbContext>(
            this IServiceCollection services,
            Func<DataEntityDbFactory> funcGetDataEntityDbFactory
            )
            where TDbContext : DataEntityDbContext
        {
            return services.AddDbContext<TDbContext>(
                options => funcGetDataEntityDbFactory.Invoke()
                    .BuildDbContextOptions(options)
                );
        }

        /// <summary>
        /// Данные. Entity Framework. Расширение. Настроить. Идентичность.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <returns>Построитель идентичности.</returns>
        /// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
        public static IdentityBuilder DataEntityExtConfigureIdentity<TDbContext>(this IServiceCollection services)
            where TDbContext : DataEntityDbContext
        {
            return services.AddIdentity<DataEntityObjectUser, DataEntityObjectRole>(options =>
            {
                options.User.AllowedUserNameCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+\";
            })
                .AddEntityFrameworkStores<TDbContext>()
                .AddDefaultTokenProviders();
        }

        #endregion Public methods
    }
}
