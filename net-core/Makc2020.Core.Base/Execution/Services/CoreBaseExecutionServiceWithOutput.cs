//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Execution.Services
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Сервисы. С выводом.
    /// </summary>
    /// <typeparam name="TOutput">Тип вывода.</typeparam>    
    public class CoreBaseExecutionServiceWithOutput<TOutput> : CoreBaseExecutionService
    {
        #region Properties

        /// <summary>
        /// Функция преобразования вывода.
        /// </summary>
        public Func<TOutput, TOutput> FuncTransformOutput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<TOutput, IEnumerable<string>> FuncGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<TOutput, IEnumerable<string>> FuncGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutionServiceWithOutput(CoreBaseResourceErrors coreBaseResourceErrors)
            : base(coreBaseResourceErrors)
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>   
        /// <param name="output">Вывод.</param>
        public void OnSuccess(
            ILogger logger,
            CoreBaseExecutionResultWithData<TOutput> result
            )
        {
            Func<IEnumerable<string>> funcGetSuccessMessages = null;

            if (FuncGetSuccessMessages != null)
            {
                funcGetSuccessMessages = () => FuncGetSuccessMessages.Invoke(result.Data);
            }

            Func<IEnumerable<string>> funcGetWarningMessages = null;

            if (FuncGetWarningMessages != null)
            {
                funcGetWarningMessages = () => FuncGetWarningMessages.Invoke(result.Data);
            }

            DoOnSuccess(
                logger,
                result,
                funcGetSuccessMessages,
                funcGetWarningMessages
                );
        }

        #endregion Public methods
    }
}
