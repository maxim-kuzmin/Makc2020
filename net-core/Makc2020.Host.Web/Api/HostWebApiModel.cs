//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using Makc2020.Host.Base;

namespace Makc2020.Host.Web.Api
{
    /// <summary>
    /// Хост. Веб. Модель.
    /// </summary>
    /// <typeparam name="TState">Тип состояния.</typeparam>
    public class HostWebApiModel<TState> : HostBaseModel<TState>
        where TState : HostWebState
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appLogger">Регистратор.</param>
        public HostWebApiModel(CoreBaseLoggingService appLogger)
            : base(appLogger)
        {
        }

        #endregion Constructors
    }
}
