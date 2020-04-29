//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base;
using Microsoft.Extensions.Logging;

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
        /// <param name="extLogger">Регистратор.</param>
        public HostWebApiModel(ILogger extLogger)
            : base(extLogger)
        {
        }

        #endregion Constructors
    }
}
