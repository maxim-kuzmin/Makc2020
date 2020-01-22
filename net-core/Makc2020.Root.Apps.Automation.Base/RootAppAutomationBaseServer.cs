//Author Maxim Kuzmin//makc//

using Makc2020.Root.Base;

namespace Makc2020.Root.Apps.Automation.Base
{
    /// <summary>
    /// Корень. Приложение "API". Основа. Сервер.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста.</typeparam>
    /// <typeparam name="TModules">Тип модулей.</typeparam>
    /// <typeparam name="TConfigurator">Тип конфигуратора.</typeparam>
    public abstract class RootAppAutomationBaseServer<TContext, TModules, TConfigurator> :
        RootBaseServer<TContext, TModules, TConfigurator>
        where TContext: RootAppAutomationBaseContext<TModules>
        where TModules: RootAppAutomationBaseModules
        where TConfigurator : RootAppAutomationBaseConfigurator<TContext, TModules>
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void InitConfigurator(TConfigurator configurator)
        {
            base.InitConfigurator(configurator);

            configurator.DataEntityDbContextDisable();
            IsMigrateDatabaseEnabled = false;

            configurator.IdentityDisable();
            IsSeedAuthEnabled = false;
        }

        #endregion Protected methods
    }
}
