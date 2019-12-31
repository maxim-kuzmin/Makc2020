//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Executable
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис.
    /// </summary>
    /// <typeparam name="TExecutionService">Тип сервиса выполнения.</typeparam>
    public class CoreBaseExecutableService<TExecutionService> where TExecutionService: CoreBaseExecutionService
    {
        #region Properties

        /// <summary>
        /// Сервис выполнения.
        /// </summary>
        protected TExecutionService Execution { get; private set; }

        /// <summary>
        /// Ресурсы ошибок ядра.
        /// </summary>
        protected CoreBaseResourceErrors CoreBaseResourceErrors => Execution.CoreBaseResourceErrors;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="execution">Выполнение.</param>
        public CoreBaseExecutableService(TExecutionService execution)
        {
            Execution = execution;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// В случае возникновения ошибки.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения задания с данными.</param>
        public void OnError(
            Exception ex,
            ILogger logger,
            CoreBaseExecutionResult result
            )
        {
            Execution.OnError(ex, logger, result);
        }

        #endregion Public methods

        /// <summary>
        /// Получить сообщения об ошибках на недействительный ввод.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <returns>Сообщения об ошибках.</returns>
        protected IEnumerable<string> GetErrorMessagesOnInvalidInput(Exception ex)
        {
            if (ex is CoreExecutionExceptionInvalidInput)
            {
                var ivalidProperties = ((CoreExecutionExceptionInvalidInput)ex).InvalidProperties;

                return new[]
                {
                    string.Format(
                        CoreBaseResourceErrors.GetStringFormatMessageIvalidInput(),
                        string.Join(", ", ivalidProperties)
                        )
                };
            }

            return null;
        }

    }
}