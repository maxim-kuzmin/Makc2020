//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;

namespace Makc2020.Core.Base.Executable.Services.Sync
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис синхронный с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceSyncWithInputAndOutput<TInput, TOutput>
        : CoreBaseExecutableServiceWithInputAndOutput<TInput, TOutput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<TInput, TOutput> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceSyncWithInputAndOutput(
            Func<TInput, TOutput> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(coreBaseResourceErrors)
        {
            Executable = executable;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Вывод.</returns>
        public TOutput Execute(TInput input)
        {
            var funcTransformInput = Execution.FuncTransformInput;

            if (funcTransformInput != null)
            {
                input = funcTransformInput.Invoke(input);
            }

            var result = Executable.Invoke(input);

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
