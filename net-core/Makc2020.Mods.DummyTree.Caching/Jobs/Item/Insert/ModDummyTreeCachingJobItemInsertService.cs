//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Insert;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Caching.Jobs.Item.Insert
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Задания. Элемент. Вставка. Сервис.
    /// </summary>
    public class ModDummyTreeCachingJobItemInsertService : ModDummyTreeBaseJobItemInsertService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        /// <param name="cacheSettings">Настройки кэширования.</param>        
        /// <param name="cache">Кэш.</param>        
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public ModDummyTreeCachingJobItemInsertService(
            Func<ModDummyTreeBaseJobItemGetOutput, Task<ModDummyTreeBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors, resourceSuccesses, resourceErrors, dataBaseSettings)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyTreeBaseJobItemGetOutput>(
                    "Item.Insert",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyTree.DbTableWithSchema
                };

                Executable = input => client.ChangeAndRead(() => executable.Invoke(input), tags);
            }
        }

        #endregion Constructors
    }
}
