//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Caching.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModDummyTreeCachingJobItemGetService : ModDummyTreeBaseJobItemGetService
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
        public ModDummyTreeCachingJobItemGetService(
            Func<ModDummyTreeBaseJobItemGetInput, Task<ModDummyTreeBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors            
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyTreeBaseJobItemGetOutput>(
                    "Item.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyTree.DbTableWithSchema
                };

                Executable = input =>
                {
                    var keys = new object[]
                    {
                        input.DataId,
                        input.DataName
                    };

                    return client.Read(() => executable.Invoke(input), keys, tags);
                };
            }
        }

        #endregion Constructors
    }
}
