//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Makc2020.Core.Base.Logging
{
    /// <summary>
    /// Ядро. Основа. Логирование. Сервис.
    /// </summary>
    public class CoreBaseLoggingService
    {
        #region Properties

        private ILogger ExtLogger { get; set; }

        private IReadOnlyList<KeyValuePair<string, object>> State { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        public CoreBaseLoggingService(ILogger extLogger)
        {
            ExtLogger = extLogger;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        /// <param name="state">Состояние.</param>
        public void Init(IReadOnlyList<KeyValuePair<string, object>> state)
        {
            State = state;
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.Log(logLevel, exception, message, args));
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void Log(LogLevel logLevel, EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.Log(logLevel, eventId, message, args));
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void Log(LogLevel logLevel, string message, params object[] args)
        {
            Execute(() => ExtLogger.Log(logLevel, message, args));
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.Log(logLevel, eventId, exception, message, args));
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="message">
        /// Format string of the log message in message template format. Example:
        /// "User {User} logged in from {Address}"
        /// </param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void LogCritical(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogCritical(message, args));
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">
        /// Format string of the log message in message template format. Example:
        /// "User {User} logged in from {Address}"
        /// </param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void LogCritical(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogCritical(exception, message, args));
        }

        /// <summary>
        /// Formats and writes a critical log message.
        /// </summary>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">
        /// Format string of the log message in message template format. Example:
        /// "User {User} logged in from {Address}"
        /// </param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void LogCritical(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogCritical(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes a critical log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogCritical(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a debug log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogDebug(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogDebug(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a debug log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogDebug(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogDebug(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes a debug log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogDebug(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogDebug(exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a debug log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogDebug(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogDebug(message, args));
        }

        //
        // Summary:
        //     Formats and writes an error log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogError(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogError(message, args));
        }

        //
        // Summary:
        //     Formats and writes an error log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogError(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogError(exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes an error log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogError(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogError(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes an error log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogError(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogError(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes an informational log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogInformation(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes an informational log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogInformation(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogInformation(exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes an informational log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogInformation(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogInformation(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes an informational log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogInformation(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogInformation(message, args));
        }

        //
        // Summary:
        //     Formats and writes a trace log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogTrace(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogTrace(message, args));
        }
        //
        // Summary:
        //     Formats and writes a trace log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogTrace(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogTrace(exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a trace log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogTrace(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogTrace(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes a trace log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogTrace(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a warning log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogWarning(EventId eventId, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogWarning(eventId, message, args));
        }

        //
        // Summary:
        //     Formats and writes a warning log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   eventId:
        //     The event id associated with the log.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogWarning(eventId, exception, message, args));
        }

        //
        // Summary:
        //     Formats and writes a warning log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogWarning(string message, params object[] args)
        {
            Execute(() => ExtLogger.LogWarning(message, args));
        }

        //
        // Summary:
        //     Formats and writes a warning log message.
        //
        // Parameters:
        //   logger:
        //     The Microsoft.Extensions.Logging.ILogger to write to.
        //
        //   exception:
        //     The exception to log.
        //
        //   message:
        //     Format string of the log message in message template format. Example:
        //     "User {User} logged in from {Address}"
        //
        //   args:
        //     An object array that contains zero or more objects to format.
        public void LogWarning(Exception exception, string message, params object[] args)
        {
            Execute(() => ExtLogger.LogWarning(exception, message, args));
        }

        #endregion Public methods

        #region Private methods

        private void Execute(Action executable)
        {
            if (State != null)
            {
                using (ExtLogger.BeginScope(State))
                {
                    executable.Invoke();
                }
            }
            else
            {
                executable.Invoke();
            }
        }

        #endregion Private methods
    }
}
