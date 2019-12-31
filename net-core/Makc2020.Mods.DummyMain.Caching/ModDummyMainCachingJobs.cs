//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyMain.Caching.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyManyToMany.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get;

namespace Makc2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Задания.
    /// </summary>
    public class ModDummyMainCachingJobs
    {
        #region Properties

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModDummyMainCachingJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModDummyMainCachingJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModDummyMainCachingJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModDummyMainCachingJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModDummyMainCachingJobListGetService JobListGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </summary>
        public ModDummyMainCachingJobOptionsDummyManyToManyGetService JobOptionsDummyManyToManyGet { get; private set; }

        /// <summary>
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </summary>
        public ModDummyMainCachingJobOptionsDummyOneToManyGetService JobOptionsDummyOneToManyGet { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="cache">Кэш.</param>
        /// <param name="cacheSettings">Настройки кэша.</param>
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        /// <param name="service">Сервис.</param>
        public ModDummyMainCachingJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ICoreCachingCache cache,
            ICoreCachingCommonClientConfigSettings cacheSettings,            
            CoreCachingResourceErrors coreCachingResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors,
            ModDummyMainBaseService service
            )
        {
            JobItemDelete = new ModDummyMainCachingJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemGet = new ModDummyMainCachingJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemInsert = new ModDummyMainCachingJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemUpdate = new ModDummyMainCachingJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobListGet = new ModDummyMainCachingJobListGetService(
                service.GetList,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobOptionsDummyManyToManyGet = new ModDummyMainCachingJobOptionsDummyManyToManyGetService(
                service.GetOptionsDummyManyToMany,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobOptionsDummyOneToManyGet = new ModDummyMainCachingJobOptionsDummyOneToManyGetService(
                service.GetOptionsDummyOneToMany,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );
        }

        #endregion Constructor
    }
}
