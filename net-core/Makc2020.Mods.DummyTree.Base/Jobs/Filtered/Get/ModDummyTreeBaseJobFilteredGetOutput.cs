//Author Maxim Kuzmin//makc//

namespace Makc2020.Mods.DummyTree.Base.Jobs.Filtered.Get
{
    /// <summary>
    /// Мод "DummyTree". Задания. Отфильтрованное. Получение. Вывод.
    /// </summary>
    public class ModDummyTreeBaseJobFilteredGetOutput
    {
        #region Properties

        /// <summary>
        /// Данные: идентификаторы.
        /// </summary>
        public long[] DataIds { get; set; }

        /// <summary>
        /// Данные: наименования.
        /// </summary>
        public string[] DataNames { get; set; }

        #endregion Properties
    }
}