//Author Maxim Kuzmin//makc//

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Makc2020.Data.Entity.Db;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Makc2020.Root.Base.DiAutofac
{
    /// <summary>
    /// Корень. Основа. Внедрение зависимостей. Autofac. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootBaseDiAutofacServer<TContext, TFeatures, TConfigurator> :
        RootBaseServer<TContext, TFeatures, TConfigurator>
        where TContext : RootBaseContext<TFeatures>
        where TFeatures : RootBaseDiAutofacFeatures
        where TConfigurator : RootBaseDiAutofacConfigurator
    {
        #region Private methods
        
        private ILifetimeScope LifetimeScope { get; set; }

        #endregion Private methods

        #region Public methods

        /// <summary>
        /// Настроить контейнер.
        /// </summary>
        /// <param name="builder">Построитель контейнера.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            RegisterModule(builder);

            Features?.RegisterModule(builder);
        }

        /// <inheritdoc/>
        public sealed override void OnStopped()
        {
            base.OnStopped();

            LifetimeScope.Dispose();
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override IServiceCollection CreateServices()
        {
            var result = base.CreateServices();

            var builder = new ContainerBuilder();

            builder.Populate(result);

            ConfigureContainer(builder);

            return result;
        }

        /// <inheritdoc/>
        protected override TService GetService<TService>()
            where TService: class
        {
            if (LifetimeScope != null)
            {
                return LifetimeScope.ResolveOptional<TService>();
            }
            else
            {
                return base.GetService<TService>();
            }
        }

        /// <inheritdoc/>
        protected override void InitConfigurator(TConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.DataEntityDbContextEnable(GetService<DataEntityDbFactory>);
            configurator.IdentityEnable();
        }

        /// <summary>
        /// Зарегистрировать модуль.
        /// </summary>
        /// <param name="builder">Построитель.</param>
        protected abstract void RegisterModule(ContainerBuilder builder);

        /// <inheritdoc/>
        protected sealed override void UseServiceProvider(IServiceProvider serviceProvider)
        {
            base.UseServiceProvider(serviceProvider);

            LifetimeScope = serviceProvider.GetAutofacRoot().BeginLifetimeScope();
        }

        #endregion Protected methods
    }
}
