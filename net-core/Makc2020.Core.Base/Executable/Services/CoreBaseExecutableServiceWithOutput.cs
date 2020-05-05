//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Execution.Services;
using Makc2020.Core.Base.Logging;
using Makc2020.Core.Base.Resources.Errors;

namespace Makc2020.Core.Base.Executable.Services
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис с выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutableServiceWithOutput<TOutput>
        : CoreBaseExecutableService<CoreBaseExecutionServiceWithOutput<TOutput>>
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceWithOutput(CoreBaseResourceErrors coreBaseResourceErrors)
            : base(new CoreBaseExecutionServiceWithOutput<TOutput>(coreBaseResourceErrors))
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>   
        public void OnSuccess(CoreBaseLoggingService logger, CoreBaseExecutionResultWithData<TOutput> result)
        {
            Execution.OnSuccess(logger, result);
        }

        #endregion Public methods
    }
}
