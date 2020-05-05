//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Logging;
using System.Collections.Generic;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Модель.
    /// </summary>
    /// <typeparam name="TState">Тип состояния.</typeparam>
    public class HostBaseModel<TState> : CoreBaseModel
        where TState : HostBaseState
    {
        #region Properties

        /// <summary>
        /// Состояние.
        /// </summary>
        protected TState State { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appLogger">Регистратор.</param>
        public HostBaseModel(CoreBaseLoggingService appLogger)
            : base(appLogger)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        /// <param name="state">Состояние.</param>
        public void Init(TState state)
        {
            State = state;

            var loggerState = new List<KeyValuePair<string, object>>();

            State.FillLoggerState(loggerState);

            AppLogger.Init(loggerState);
        }

        #endregion Public methods
    }
}
