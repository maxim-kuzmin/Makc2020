//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Jobs.List.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Список. Получить. Вывод.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента списка.</typeparam>
    public class CoreBaseCommonJobListGetOutput<TItem>
    {
        #region Properties

        /// <summary>
        /// Элементы.
        /// </summary>
        public TItem[] Items { get; set; }

        /// <summary>
        /// Общее число элементов.
        /// </summary>
        public long TotalCount { get; set; }

        #endregion Properties
    }
}
