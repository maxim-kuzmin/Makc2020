//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Executable.Services.Async
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис асинхронный без ввода и вывода.
    /// </summary>
    public class CoreBaseExecutableServiceAsyncWithoutInputAndOutput
        : CoreBaseExecutableServiceWithoutInputAndOutput
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<Task> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceAsyncWithoutInputAndOutput(
            Func<Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(coreBaseResourceErrors)
        {
            Executable = executable;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        ///  Выполнить.
        /// </summary>
        /// <returns>Задача.</returns>
        public Task Execute()
        {
            return Executable.Invoke();
        }

        #endregion Public methods
    }
}
