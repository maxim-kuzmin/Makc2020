//Author Maxim Kuzmin//makc//

using Autofac;

namespace Makc2020.Data.Base.DiAutofac
{
    /// <summary>
    /// Данные. Основа. Внедрение зависимостей. Autofac. Модуль.
    /// </summary>
    public class DataBaseDiAutofacModule : Module
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Register//Settings//DataBaseSettings//

            builder.Register(x => ResolveContext(x).Settings).AsSelf();
        }

        #endregion Protected methods

        #region Private methods

        private DataBaseContext ResolveContext(IComponentContext resolver)
        {
            return resolver.Resolve<DataBaseContext>();
        }

        #endregion Private methods
    }
}