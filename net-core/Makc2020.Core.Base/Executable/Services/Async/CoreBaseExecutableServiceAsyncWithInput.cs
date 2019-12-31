//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Executable.Services.Async
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис асинхронный с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class CoreBaseExecutableServiceAsyncWithInput<TInput>
        : CoreBaseExecutableServiceWithInput<TInput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<TInput, Task> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceAsyncWithInput(
            Func<TInput, Task> executable,
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
        /// <param name="input">Ввод.</param>
        /// <returns>Задача.</returns>
        public Task Execute(TInput input)
        {
            var funcTransformInput = Execution.FuncTransformInput;

            if (funcTransformInput != null)
            {
                input = funcTransformInput.Invoke(input);
            }

            return Executable.Invoke(input);
        }

        #endregion Public methods
    }
}
