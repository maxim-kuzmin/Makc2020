//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Mod.Jobs.Options.Get.Output
{
    /// <summary>
    /// Ядро. Основа. Общее. Мод. Задания. Варианты выбора. Получить. Вывод. Элемент.
    /// </summary>
    /// <typeparam name="TValue">Тип значения.</typeparam>
    public class CoreBaseCommonModJobOptionsGetOutputItem<TValue>
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
