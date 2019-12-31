//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Data
{
    /// <summary>
    /// Ядро. Основа. Данные. Обёртка. 
    /// В основном предназначена для обёртки с целью сериализации данных, которые имеют типы значений. 
    /// </summary>
    /// <typeparam name="T">Тип данных.</typeparam>
    public class CoreBaseDataWrapper<T>
    {
        #region Properties

        /// <summary>
        /// Данные.
        /// </summary>
        public T Data { get; set; }

        #endregion Properties

        #region Controllers

        /// <summary>
        /// Конструктор обёртки для данных.
        /// </summary>
        public CoreBaseDataWrapper()
        {
        }

        /// <summary>
        /// Конструктор обёртки для данных.
        /// </summary>
        /// <param name="data">Данные.</param>
        public CoreBaseDataWrapper(T data)
        {
            Data = data;
        }

        #endregion Controllers
    }
}
