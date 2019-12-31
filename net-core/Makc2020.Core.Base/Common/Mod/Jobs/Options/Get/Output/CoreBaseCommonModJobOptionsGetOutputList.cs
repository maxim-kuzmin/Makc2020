//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Mod.Jobs.Options.Get.Output
{
    /// <summary>
    /// Ядро. Основа. Общее. Мод. Задания. Варианты выбора. Получить. Вывод. Список.
    /// </summary>
    /// <typeparam name="TItem">Тип элемента списка.</typeparam>
    public class CoreBaseCommonModJobOptionsGetOutputList<TItem>
    {
        #region Properties

        /// <summary>
        /// Элементы.
        /// </summary>
        public TItem[] Items { get; set; }

        #endregion Properties
    }
}
