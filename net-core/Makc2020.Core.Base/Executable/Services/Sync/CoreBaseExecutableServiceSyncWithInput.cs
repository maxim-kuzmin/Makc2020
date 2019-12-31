//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;

namespace Makc2020.Core.Base.Executable.Services.Sync
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис синхронный с вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class CoreBaseExecutableServiceSyncWithInput<TInput>
        : CoreBaseExecutableServiceWithInput<TInput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Action<TInput> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceSyncWithInput(
            Action<TInput> executable,
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
        public void Execute(TInput input)
        {
            var funcTransformInput = Execution.FuncTransformInput;

            if (funcTransformInput != null)
            {
                input = funcTransformInput.Invoke(input);
            }

            Executable.Invoke(input);
        }

        #endregion Public methods
    }
}