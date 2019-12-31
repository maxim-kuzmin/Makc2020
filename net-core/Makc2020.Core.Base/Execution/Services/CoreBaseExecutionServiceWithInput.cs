//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Execution.Services
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Сервисы. С вводом.
    /// </summary>
    /// <typeparam name="TInput">Тип ввода.</typeparam>
    public class CoreBaseExecutionServiceWithInput<TInput> : CoreBaseExecutionService
    {
        #region Properties

        /// <summary>
        /// Функция преобразования ввода.
        /// </summary>
        public Func<TInput, TInput> FuncTransformInput { get; set; }

        /// <summary>
        /// Функция получения сообщений об успехах.
        /// </summary>
        public Func<TInput, IEnumerable<string>> FuncGetSuccessMessages { get; set; }

        /// <summary>
        /// Функция получения сообщений о предупреждениях.
        /// </summary>
        public Func<TInput, IEnumerable<string>> FuncGetWarningMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutionServiceWithInput(CoreBaseResourceErrors coreBaseResourceErrors)
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
        /// <param name="input">Ввод.</param>
        public void OnSuccess(
            ILogger logger,
            CoreBaseExecutionResult result,
            TInput input
            )
        {
            Func<IEnumerable<string>> funcGetSuccessMessages = null;

            if (FuncGetSuccessMessages != null)
            {
                funcGetSuccessMessages = () => FuncGetSuccessMessages.Invoke(input);
            }

            Func<IEnumerable<string>> funcGetWarningMessages = null;

            if (FuncGetWarningMessages != null)
            {
                funcGetWarningMessages = () => FuncGetWarningMessages.Invoke(input);
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
