//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Jobs.Option.List.Get
{
    /// <summary>
    /// Ядро. Основа. Общее. Задания. Варианты выбора. Список. Получить. Вывод.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента списка.</typeparam>
    public class CoreBaseCommonJobOptionListGetOutput<TItem>
    {
        #region Properties

        /// <summary>
        /// Элементы.
        /// </summary>
        public TItem[] Items { get; set; }

        #endregion Properties
    }
}
