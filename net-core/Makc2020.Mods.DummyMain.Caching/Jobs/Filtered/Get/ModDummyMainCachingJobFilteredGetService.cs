//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Clients;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base.Jobs.Filtered.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Caching.Jobs.Filtered.Get
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModDummyMainCachingJobFilteredGetService : ModDummyMainBaseJobFilteredGetService
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="dataBaseSettings">Данные. Основа. Настройки.</param>
        /// <param name="cacheSettings">Кэширование. Настройки.</param>        
        /// <param name="cache">Кэш.</param>      
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        public ModDummyMainCachingJobFilteredGetService(
            Func<ModDummyMainBaseJobListGetInput, Task<ModDummyMainBaseJobFilteredGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            DataBaseSettings dataBaseSettings,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            if (cacheSettings.IsCachingEnabled)
            {
                var client = new CoreCachingClientWithChangeAndRead<ModDummyMainBaseJobFilteredGetOutput>(
                    "Filtered.Get",
                    cacheSettings,
                    cache,
                    coreCachingResourceErrors
                    );

                var tags = new[]
                {
                    dataBaseSettings.DummyMain.DbTableWithSchema
                };

                Executable = input =>
                {
                    var keys = new object[]
                    {
                        input.DataObjectDummyOneToManyName,
                        input.DataObjectDummyOneToManyIds,
                        input.DataObjectDummyOneToManyId,
                        input.DataName,
                        input.DataIds,
                        input.PageNumber,
                        input.PageSize,
                        input.SortField,
                        input.SortDirection
                    };

                    return client.Read(() => executable.Invoke(input), keys, tags);
                };
            }
        }

        #endregion Constructors
    }
}
