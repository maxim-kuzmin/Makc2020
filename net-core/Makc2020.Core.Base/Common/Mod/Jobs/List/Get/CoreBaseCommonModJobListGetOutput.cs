//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Mod.Jobs.List.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Мод. Задания. Список. Получить. Вывод.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента списка.</typeparam>
    public class CoreBaseCommonModJobListGetOutput<TItem>
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
