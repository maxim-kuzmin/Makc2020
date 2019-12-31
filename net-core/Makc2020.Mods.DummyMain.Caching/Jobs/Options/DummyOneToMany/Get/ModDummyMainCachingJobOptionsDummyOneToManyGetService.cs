//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Options.Get.Output;
using Makc2020.Mods.DummyMain.Base.Jobs.Options.DummyOneToMany.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Варианты выбора. Сущность "DummyOneToMany". Получение. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobOptionsDummyOneToManyGetService :
        ModDummyMainBaseJobOptionsDummyOneToManyGetService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        /// <param name="cacheSettings">Настройки кэширования.</param>        
        /// <param name="cache">Кэш.</param>      
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public ModDummyMainCachingJobOptionsDummyOneToManyGetService(
            Func<Task<ModDummyMainBaseCommonJobOptionsGetOutputList>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyMainBaseCommonJobOptionsGetOutputList>(
                    "Options.DummyOneToMany.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyOneToMany.DbTableWithSchema
                };

                Executable = () =>
                {
                    return client.Read(() => executable.Invoke(), null, tags);
                };
            }
        }

        #endregion Constructors
    }
}
