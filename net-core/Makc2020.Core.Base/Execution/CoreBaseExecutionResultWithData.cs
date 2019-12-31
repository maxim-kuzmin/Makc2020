//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Execution
{
    /// <summary>
    /// Ядро. Основа. Выполнение. Результат с данными.
    /// </summary>
    /// <typeparam name="T">Тип данных.</typeparam>
    public class CoreBaseExecutionResultWithData<T> : CoreBaseExecutionResult
    {
        #region Properties

        /// <summary>
        /// Данные.
        /// </summary>
        public T Data { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public CoreBaseExecutionResultWithData()
        {
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public CoreBaseExecutionResultWithData(T data)
        {
            Data = data;
        }

        #endregion Constructors
    }
}
