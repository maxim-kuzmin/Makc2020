//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Контекст.
    /// </summary>
    public sealed class CoreCachingContext
    {
        #region Properties

        private IMemoryCache MemoryCache { get; set; }

        private CoreCachingStorages Storages { get; set; }

        /// <summary>
        /// Кэш.
        /// </summary>
        public ICoreCachingCache Cache { get; private set; }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public CoreCachingConfig Config { get; private set; }

        /// <summary>
        /// Ресурсы.
        /// </summary>
        public CoreCachingResources Resources { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="config">Конфигурация.</param>
        /// <param name="externals">Внешнее.</param>
        public CoreCachingContext(CoreCachingConfig config, CoreCachingExternals externals)
        {            
            Config = config;

            MemoryCache = new MemoryCache(externals.MemoryCacheOptions ?? new MemoryCacheOptions());

            Resources = new CoreCachingResources(externals.ResourceErrorsLocalizer);

            InitStorages();

            var helper = Storages?.Global?.Helper;

            if (helper != null && !helper.IsFaulty)
            {
                helper.Subscribe(RemoveDataFromLocalStorage, RemoveAllDataFromLocalStorage);
            }

            Cache = CreateCache();
        }

        #endregion Constructors

        #region Private methods

        private ICoreCachingCache CreateCache()
        {
            return new CoreCachingCache(Resources.Errors, Storages);
        }

        private void RemoveAllDataFromLocalStorage()
        {
            Storages.Local.Service.RemoveData();
        }

        private void RemoveDataFromLocalStorage(byte[] tagBytes)
        {
            var buffer = Encoding.Convert(Encoding.GetEncoding("iso-8859-1"), Encoding.UTF8, tagBytes);

            var tag = Encoding.UTF8.GetString(buffer, 0, tagBytes.Count());

            Storages.Local.Service.RemoveData(new[] { tag });
        }

        private void InitStorages()
        {
            if (Config.Settings.IsCachingEnabled)
            {
                Storages = new CoreCachingStorages(MemoryCache, Config.Settings, Resources.Errors);
            }
        }

        #endregion Private methods
    }
}