//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Execution.Services;
using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;

namespace Makc2020.Core.Base.Executable.Services
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис с вводом и выводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceWithInputAndOutput<TInput, TOutput>
        : CoreBaseExecutableService<CoreBaseExecutionServiceWithInputAndOutput<TInput, TOutput>>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceWithInputAndOutput(CoreBaseResourceErrors coreBaseResourceErrors)
            : base(new CoreBaseExecutionServiceWithInputAndOutput<TInput, TOutput>(coreBaseResourceErrors))
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>
        /// <param name="input">Ввод.</param>        
        public void OnSuccess(ILogger logger, CoreBaseExecutionResultWithData<TOutput> result, TInput input)
        {
            Execution.OnSuccess(logger, result, input);
        }

        #endregion Public methods
    }
}
