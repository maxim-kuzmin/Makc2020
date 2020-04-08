//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base.Jobs.Calculate;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Delete;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Insert;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Update;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания.
    /// </summary>
    public class ModDummyTreeBaseJobs
    {
        #region Properties

        /// <summary>
        /// Задание на вычисление.
        /// </summary>
        public ModDummyTreeBaseJobCalculateService JobCalculate { get; private set; }

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModDummyTreeBaseJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModDummyTreeBaseJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModDummyTreeBaseJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModDummyTreeBaseJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModDummyTreeBaseJobListGetService JobListGet { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModDummyTreeBaseJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors,
            ModDummyTreeBaseService service
            )
        {
            JobCalculate = new ModDummyTreeBaseJobCalculateService(
                service.Calculate,
                coreBaseResourceErrors,
                resourceSuccesses
                );

            JobItemDelete = new ModDummyTreeBaseJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses
                );

            JobItemGet = new ModDummyTreeBaseJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors
                );

            JobItemInsert = new ModDummyTreeBaseJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobItemUpdate = new ModDummyTreeBaseJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobListGet = new ModDummyTreeBaseJobListGetService(
                service.GetList,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
