//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Executable.Services.Async
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис асинхронный с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceAsyncWithInputAndOutput<TInput, TOutput>
        : CoreBaseExecutableServiceWithInputAndOutput<TInput, TOutput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<TInput, Task<TOutput>> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceAsyncWithInputAndOutput(
            Func<TInput, Task<TOutput>> executable,
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
        /// <returns>Задача с выводом.</returns>
        public async Task<TOutput> Execute(TInput input)
        {
            var funcTransformInput = Execution.FuncTransformInput;

            if (funcTransformInput != null)
            {
                input = funcTransformInput.Invoke(input);
            }

            var result = await Executable.Invoke(input).CoreBaseExtTaskWithCurrentCulture(false);

            var funcTransformOutput = Execution.FuncTransformOutput;

            if (funcTransformOutput != null)
            {
                result = funcTransformOutput.Invoke(result);
            }

            return result;
        }

        #endregion Public methods
    }
}
