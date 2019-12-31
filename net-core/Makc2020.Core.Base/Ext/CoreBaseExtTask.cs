//Author Maxim Kuzmin//makc//

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Задача.
    /// </summary>
    public static class CoreBaseExtTask
    {
        /// <summary>
        /// Ядро. Основа. Расширение. Задача. С текущей культурой.
        /// </summary>
        /// <typeparam name="T">Тип результата.</typeparam>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Объект, который ожидает завершения асинхронной задачи.</returns>
        public static CultureAwaiter<T> CoreBaseExtTaskWithCurrentCulture<T>(this Task<T> task, bool continueOnCapturedContext)
        {
            return new CultureAwaiter<T>(task, continueOnCapturedContext);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Задача. С текущей культурой.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
        /// <returns>Объект, который ожидает завершения асинхронной задачи.</returns>
        public static CultureAwaiter CoreBaseExtTaskWithCurrentCulture(this Task task, bool continueOnCapturedContext)
        {
            return new CultureAwaiter(task, continueOnCapturedContext);
        }

        /// <summary>
        /// Объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.
        /// </summary>
        /// <typeparam name="T">Тип результата выполнения задачи.</typeparam>
        public struct CultureAwaiter<T> : ICriticalNotifyCompletion
        {
            private Task<T> Task { get; set; }

            private bool ContinueOnCapturedContext { get; set; }

            /// <summary>
            /// Конструктор.
            /// </summary>
            /// <param name="task">Задача.</param>
            /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
            public CultureAwaiter(Task<T> task, bool continueOnCapturedContext)
            {
                Task = task;
                ContinueOnCapturedContext = continueOnCapturedContext;
            }

            /// <summary>
            /// Получить объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.
            /// </summary>
            /// <returns>объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.</returns>
            public CultureAwaiter<T> GetAwaiter()
            {
                return this;
            }

            /// <summary>
            /// Признак завершения задачи.
            /// </summary>
            public bool IsCompleted
            {
                get { return Task.IsCompleted; }
            }

            /// <summary>
            /// Получить результат выполнения задачи.
            /// </summary>
            /// <returns>Результат выполнения задачи.</returns>
            public T GetResult()
            {
                return Task.GetAwaiter().GetResult();
            }

            /// <summary>
            /// Обработчик завершения задачи.
            /// </summary>
            /// <param name="continuation">Действие, которое должно быть выполнено по завершению задачи.</param>
            public void OnCompleted(Action continuation)
            {
                // The compiler will never call this method
                throw new NotImplementedException();
            }

            /// <summary>
            /// Небезопасный обработчик завершения задачи.
            /// </summary>
            /// <param name="continuation">Действие, которое должно быть выполнено по завершению задачи.</param>
            public void UnsafeOnCompleted(Action continuation)
            {
                var currentCulture = CultureInfo.CurrentCulture;
                var currentUICulture = CultureInfo.CurrentUICulture;

                Task.ConfigureAwait(ContinueOnCapturedContext).GetAwaiter().UnsafeOnCompleted(() =>
                {
                    var originalCulture = CultureInfo.CurrentCulture;
                    var originalUICulture = CultureInfo.CurrentUICulture;

                    CultureInfo.CurrentCulture = currentCulture;
                    CultureInfo.CurrentUICulture = currentUICulture;

                    try
                    {
                        continuation();
                    }
                    finally
                    {
                        CultureInfo.CurrentCulture = originalCulture;
                        CultureInfo.CurrentUICulture = originalUICulture;
                    }
                });
            }
        }

        /// <summary>
        /// Объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.
        /// </summary>
        public struct CultureAwaiter : ICriticalNotifyCompletion
        {
            private Task Task { get; set; }

            private bool ContinueOnCapturedContext { get; set; }

            /// <summary>
            /// Конструктор.
            /// </summary>
            /// <param name="task">Задача.</param>
            /// <param name="continueOnCapturedContext">Продолжить на захваченном контексте.</param>
            public CultureAwaiter(Task task, bool continueOnCapturedContext)
            {
                Task = task;
                ContinueOnCapturedContext = continueOnCapturedContext;
            }

            /// <summary>
            /// Получить объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.
            /// </summary>
            /// <returns>объект, который ожидает завершения асинхронной задачи с сохранением текущей культуры.</returns>
            public CultureAwaiter GetAwaiter()
            {
                return this;
            }

            /// <summary>
            /// Признак завершения задачи.
            /// </summary>
            public bool IsCompleted
            {
                get { return Task.IsCompleted; }
            }

            /// <summary>
            /// Получить результат выполнения задачи.
            /// </summary>
            /// <returns>Результат выполнения задачи.</returns>
            public void GetResult()
            {
                Task.GetAwaiter().GetResult();
            }

            /// <summary>
            /// Обработчик завершения задачи.
            /// </summary>
            /// <param name="continuation">Действие, которое должно быть выполнено по завершению задачи.</param>
            public void OnCompleted(Action continuation)
            {
                // The compiler will never call this method
                throw new NotImplementedException();
            }

            /// <summary>
            /// Небезопасный обработчик завершения задачи.
            /// </summary>
            /// <param name="continuation">Действие, которое должно быть выполнено по завершению задачи.</param>
            public void UnsafeOnCompleted(Action continuation)
            {
                var currentCulture = CultureInfo.CurrentCulture;
                var currentUICulture = CultureInfo.CurrentUICulture;

                Task.ConfigureAwait(ContinueOnCapturedContext).GetAwaiter().UnsafeOnCompleted(() =>
                {
                    var originalCulture = CultureInfo.CurrentCulture;
                    var originalUICulture = CultureInfo.CurrentUICulture;

                    CultureInfo.CurrentCulture = currentCulture;
                    CultureInfo.CurrentUICulture = currentUICulture;

                    try
                    {
                        continuation();
                    }
                    finally
                    {
                        CultureInfo.CurrentCulture = originalCulture;
                        CultureInfo.CurrentUICulture = originalUICulture;
                    }
                });
            }
        }
    }
}