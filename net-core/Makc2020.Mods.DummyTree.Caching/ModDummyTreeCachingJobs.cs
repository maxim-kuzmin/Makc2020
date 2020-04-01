//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyTree.Caching.Jobs.List.Get;

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Задания.
    /// </summary>
    public class ModDummyTreeCachingJobs
    {
        #region Properties

        /// <summary>
        /// Задание на удаление элемента.
        /// </summary>
        public ModDummyTreeCachingJobItemDeleteService JobItemDelete { get; private set; }

        /// <summary>
        /// Задание на получение элемента.
        /// </summary>
        public ModDummyTreeCachingJobItemGetService JobItemGet { get; private set; }

        /// <summary>
        /// Задание на вставку элемента.
        /// </summary>
        public ModDummyTreeCachingJobItemInsertService JobItemInsert { get; private set; }

        /// <summary>
        /// Задание на обновление элемента.
        /// </summary>
        public ModDummyTreeCachingJobItemUpdateService JobItemUpdate { get; private set; }

        /// <summary>
        /// Задание на получение списка.
        /// </summary>
        public ModDummyTreeCachingJobListGetService JobListGet { get; private set; }

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
        public ModDummyTreeCachingJobs(            
            CoreBaseResourceErrors coreBaseResourceErrors,
            ICoreCachingCache cache,
            ICoreCachingCommonClientConfigSettings cacheSettings,            
            CoreCachingResourceErrors coreCachingResourceErrors,
            DataBaseSettings dataBaseSettings,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors,
            ModDummyTreeBaseService service
            )
        {
            JobItemDelete = new ModDummyTreeCachingJobItemDeleteService(
                service.DeleteItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemGet = new ModDummyTreeCachingJobItemGetService(
                service.GetItem,
                coreBaseResourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemInsert = new ModDummyTreeCachingJobItemInsertService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobItemUpdate = new ModDummyTreeCachingJobItemUpdateService(
                service.SaveItem,
                coreBaseResourceErrors,
                resourceSuccesses,
                resourceErrors,
                dataBaseSettings,
                cacheSettings,
                cache,
                coreCachingResourceErrors
                );

            JobListGet = new ModDummyTreeCachingJobListGetService(
                service.GetList,
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
