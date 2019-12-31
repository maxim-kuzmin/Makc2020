//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace Makc2020.Root.Base
{
    /// <summary>
    /// Корень. Основа. Контекст.
    /// </summary>
    /// <typeparam name="TFeatures">Тип функциональностей.</typeparam>
    public abstract class RootBaseContext<TFeatures>
        where TFeatures : RootBaseFeatures
    {
        #region Properties

        private UnhandledExceptionEventHandler UnhandledExceptionHandler { get; set; }

        private CultureInfo CurrentCulture { get; set; }

        /// <summary>
        /// Функциональности.
        /// </summary>
        protected TFeatures Features { get; private set; }

        /// <summary>
        /// Регистратор.
        /// </summary>
        protected ILogger Logger { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="features">Функциональности.</param>
        /// <param name="logger">Регистратор.</param>
        public RootBaseContext(TFeatures features, ILogger logger)
        {
            Features = features;
            Logger = logger;

            UnhandledExceptionHandler = (s, e) => GetLoggedErrorWithCurrentCulture(e.ExceptionObject);

            AppDomain.CurrentDomain.UnhandledException -= UnhandledExceptionHandler;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Инициализировать текущую культуру приложения.
        /// Установка текущей культуры важна для правильного извлечения ресурсов и 
        /// преобразований в строковое представление.
        /// Культуру нужно устанавливать при запуске главного потока настольного приложения,
        /// либо в начале запроса веб-приложения.
        /// </summary>
        /// <param name="cultureName">Имя культуры.</param>
        public void InitCurrentCulture(string cultureName)
        {
            CurrentCulture = CultureInfo.GetCultureInfo(cultureName);

            CultureInfo.CurrentCulture = CurrentCulture;
            CultureInfo.CurrentUICulture = CurrentCulture;

            Logger.LogDebug($"RootBaseContext.InitCurrentCulture: Culture name: {cultureName}");
        }

        /// <summary>
        /// Выполнить любое действие в рамках текущей культуры для того, чтобы корректно извлекать ресурсы.
        /// </summary>
        /// <param name="action">Действие.</param>
        public void ExecuteActionWithCurrentCulture(Action action)
        {
            if (CurrentCulture != null)
            {
                var ci = CultureInfo.CurrentCulture;
                var ciUI = CultureInfo.CurrentUICulture;

                CultureInfo.CurrentCulture = CurrentCulture;
                CultureInfo.CurrentUICulture = CurrentCulture;

                action();

                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ciUI;
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// Выполнить любую функцию в рамках текущей культуры, чтобы корректно извлекать ресурсы.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого функцией значения.</typeparam>
        /// <param name="func">Функция.</param>
        /// <returns>Значение, возвращаемое функцией.</returns>
        public T ExecuteFuncWithCurrentCulture<T>(Func<T> func)
        {
            T result = default;

            ExecuteActionWithCurrentCulture(() => result = func());

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Получение записанной в журнал ошибке с учётом текущей культуры.
        /// </summary>
        /// <param name="exceptionObject">Объект исключения, приведшего к возникновению ошибки.</param>
        /// <returns>Ошибка.</returns>
        protected CoreBaseError GetLoggedErrorWithCurrentCulture(object exceptionObject)
        {
            return ExecuteFuncWithCurrentCulture(() => GetLoggedError(exceptionObject));
        }

        /// <summary>
        /// Создание ошибки.
        /// Если исключение равно нулю, заносить в журнал ничего не нужно.
        /// </summary>
        /// <param name="exception">Исключение, приведшее к возникновению ошибки.</param>
        /// <returns>Ошибка.</returns>
        protected abstract CoreBaseError CreateError(Exception exception);

        /// <summary>
        /// Зарегистрировать ошибку.
        /// </summary>
        /// <param name="error">Ошибка.</param>
        protected void LogError(CoreBaseError error)
        {
            if (error.ShouldBeLogged && Logger != null)
            {
                Logger.LogCritical(error.Exception, error.CreateMessageWithCode());
            }
        }

        #endregion Protected methods

        #region Private methods

        /// <summary>
        /// Получение зарегистрированной ошибки.
        /// </summary>
        /// <param name="exceptionObject">Объект исключения, приведшего к возникновению ошибки.</param>
        /// <returns>Зарегистрированная ошибка.</returns>
        private CoreBaseError GetLoggedError(object exceptionObject)
        {
            CoreBaseError result = null;

            try
            {
                Exception exception = null;

                if (exceptionObject is Exception)
                {
                    exception = (Exception)exceptionObject;
                }

                result = CreateError(exception);

                LogError(result);
            }
            catch (Exception ex)
            {
                if (result == null)
                {
                    result = CreateError(ex);
                }

                LogError(result);
            }

            return result;
        }

        #endregion Private methods
    }
}
