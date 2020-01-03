//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Jobs.Option.Item.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Вариант выбора. Элемент. Получить. Вывод. 
    /// </summary>
    /// <typeparam name="TValue">Тип значения.</typeparam>
    public class CoreBaseCommonJobOptionItemGetOutput<TValue>
    {
        #region Properties

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        public TValue Value { get; set; }

        #endregion Properties
    }
}
