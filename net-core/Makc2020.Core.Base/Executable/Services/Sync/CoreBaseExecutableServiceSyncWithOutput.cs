//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;

namespace Makc2020.Core.Base.Executable.Services.Sync
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис синхронный с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceSyncWithOutput<TOutput>
        : CoreBaseExecutableServiceWithOutput<TOutput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<TOutput> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceSyncWithOutput(
            Func<TOutput> executable,
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
        /// <returns>Вывод.</returns>
        public TOutput Execute()
        {
            var result = Executable.Invoke();

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
