//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Delete;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Update;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Options.DummyManyToMany.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Options.DummyOneToMany.Get;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;

namespace Makc2020.Mods.DummyMain.Base
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания.
    /// </summary>
    public class ModDummyMainBaseJobs
    {
        #region Properties

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModDummyMainBaseJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModDummyMainBaseJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModDummyMainBaseJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModDummyMainBaseJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModDummyMainBaseJobListGetService JobListGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </summary>
        public ModDummyMainBaseJobOptionsDummyManyToManyGetService JobOptionsDummyManyToManyGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </summary>
        public ModDummyMainBaseJobOptionsDummyOneToManyGetService JobOptionsDummyOneToManyGet { get; private set; }

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
        public ModDummyMainBaseJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors,
            ModDummyMainBaseService service
            )
        {
            JobItemDelete = new ModDummyMainBaseJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses
                );

            JobItemGet = new ModDummyMainBaseJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors
                );

            JobItemInsert = new ModDummyMainBaseJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobItemUpdate = new ModDummyMainBaseJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings
                );

            JobListGet = new ModDummyMainBaseJobListGetService(
                service.GetList,
                coreBaseResourceErrors
                );

            JobOptionsDummyManyToManyGet = new ModDummyMainBaseJobOptionsDummyManyToManyGetService(
                service.GetOptionsDummyManyToMany,
                coreBaseResourceErrors
                );

            JobOptionsDummyOneToManyGet = new ModDummyMainBaseJobOptionsDummyOneToManyGetService(
                service.GetOptionsDummyOneToMany,
                coreBaseResourceErrors
                );
        }

        #endregion Constructor
    }
}
