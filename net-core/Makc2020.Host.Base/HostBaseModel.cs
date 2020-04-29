//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Microsoft.Extensions.Logging;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Модель.
    /// </summary>
    /// <typeparam name="TState">Тип состояния.</typeparam>
    public class HostBaseModel<TState> : CoreBaseModel
        where TState: HostBaseState
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
        /// <param name="extLogger">Регистратор.</param>
        public HostBaseModel(ILogger extLogger)
            : base(extLogger)
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
        }

        #endregion Public methods
    }
}
