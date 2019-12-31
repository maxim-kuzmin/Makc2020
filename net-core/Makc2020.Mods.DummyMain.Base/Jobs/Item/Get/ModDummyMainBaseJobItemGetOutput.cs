//Author Maxim Kuzmin//makc//

using Makc2020.Data.Base.Objects;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Получение. Вывод.
    /// </summary>
    public class ModDummyMainBaseJobItemGetOutput
    {
        #region Properties

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyMain".
        /// </summary>
        public DataBaseObjectDummyMain ObjectDummyMain { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyManyToMany".
        /// </summary>
        public DataBaseObjectDummyManyToMany[] ObjectsDummyManyToMany { get; set; }

        /// <summary>
        /// Объекты, где хранятся данные сущности "DummyMainDummyManyToMany".
        /// </summary>
        public DataBaseObjectDummyMainDummyManyToMany[] ObjectsDummyMainDummyManyToMany { get; set; }

        /// <summary>
        /// Объект, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public DataBaseObjectDummyOneToMany ObjectDummyOneToMany { get; set; }

        #endregion Properties
    }
}