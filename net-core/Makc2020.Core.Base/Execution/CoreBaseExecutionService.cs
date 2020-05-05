//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Logging;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Core.Base.Execution
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Сервис.
    /// </summary>
    public class CoreBaseExecutionService
    {
        #region Properties

        /// <summary>
        /// Ресурсы ошибок ядра.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Функция получения сообщений об ошибках.
        /// </summary>
        public Func<Exception, IEnumerable<string>> FuncGetErrorMessages { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutionService(CoreBaseResourceErrors coreBaseResourceErrors)
        {
            CoreBaseResourceErrors = coreBaseResourceErrors;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Сделать в случае успеха.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения.</param>
        /// <param name="funcGetSuccessMessages">Функция получения сообщений об успехах.</param>
        /// <param name="funcGetWarningMessages">Функция получения сообщений о предупреждениях.</param>
        protected void DoOnSuccess(
            CoreBaseLoggingService logger,
            CoreBaseExecutionResult result,
            Func<IEnumerable<string>> funcGetSuccessMessages,
            Func<IEnumerable<string>> funcGetWarningMessages
            )
        {
            result.IsOk = true;

            if (funcGetSuccessMessages != null)
            {
                var messages = funcGetSuccessMessages();

                if (messages != null && messages.Any())
                {
                    result.SuccessMessages.CoreBaseExtCollectionAddRange(messages);
                }
            }

            if (funcGetWarningMessages != null)
            {
                var messages = funcGetWarningMessages();

                if (messages != null && messages.Any())
                {
                    result.WarningMessages.CoreBaseExtCollectionAddRange(messages);
                }
            }

#if TEST || DEBUG
            LogResultOnTestOrDebug(logger, result);
#endif        
        }

        #endregion Protected methods

        #region Public methods

        /// <summary>
        /// В случае возникновения ошибки.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <param name="logger">Регистратор.</param>
        /// <param name="result">Результат выполнения задания с данными.</param>
        public void OnError(
            Exception ex,
            CoreBaseLoggingService logger,
            CoreBaseExecutionResult result
            )
        {
            string errorMessage = null;

            var errorMessages = GetErrorMessages(ex);

            if (errorMessages != null && errorMessages.Any())
            {
                result.ErrorMessages.CoreBaseExtCollectionAddRange(errorMessages);
            }
            else
            {
                var error = new CoreBaseError(ex, CoreBaseResourceErrors);

                errorMessage = error.CreateMessageWithCode();

                result.ErrorMessages.Add(errorMessage);
            }

            if (logger != null)
            {
                if (errorMessage == null && errorMessages != null && errorMessages.Any())
                {
                    errorMessage = string.Join(". ", errorMessages);
                }

                logger.LogError(ex, errorMessage);
            }
        }

        #endregion Public methods

        #region Private methods

        /// <summary>
        /// Получить сообщения об ошибке.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <returns>Сообщения об ошибках.</returns>
        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            IEnumerable<string> errorMessages = null;

            if (FuncGetErrorMessages != null)
            {
                errorMessages = FuncGetErrorMessages.Invoke(ex);
            }

            if (errorMessages == null || !errorMessages.Any())
            {
                string errorMessage = null;

                if (ex is CoreBaseException)
                {
                    errorMessage = ex.Message;
                }

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessages = new[] { errorMessage };
                }
            }

            return errorMessages;
        }

        private void LogResultOnTestOrDebug(CoreBaseLoggingService logger, CoreBaseExecutionResult result)
        {
            if (logger != null)
            {
                var msg = result.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

                logger.LogDebug(msg);
            }
        }

        #endregion Private methods
    }
}
