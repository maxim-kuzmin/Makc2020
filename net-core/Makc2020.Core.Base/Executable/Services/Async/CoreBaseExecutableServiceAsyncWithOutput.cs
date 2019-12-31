//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Executable.Services.Async
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис асинхронный с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceAsyncWithOutput<TOutput>
        : CoreBaseExecutableServiceWithOutput<TOutput>
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Func<Task<TOutput>> Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceAsyncWithOutput(
            Func<Task<TOutput>> executable,
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
        /// <returns>Задача с данными.</returns>
        public async Task<TOutput> Execute()
        {
            var result = await Executable.Invoke().CoreBaseExtTaskWithCurrentCulture(false);

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
