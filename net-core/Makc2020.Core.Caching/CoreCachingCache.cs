//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Core.Caching.Storages.Global;
using Makc2020.Core.Caching.Storages.Local;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Кэш.
    /// </summary>
    public class CoreCachingCache : ICoreCachingCache
    {
        #region Properties

        private CoreCachingStorages Storages { get; set; }

        private CoreCachingResourceErrors ResourceErrors { get; set; }

        private CoreCachingStorageGlobalHelper GlobalStorageHelper { get; set; }

        private CoreCachingStorageGlobalService GlobalStorageService { get; set; }

        private CoreCachingStorageLocalService LocalStorageService { get; set; }

        /// <inheritdoc/>
        public bool IsFaulty { get; private set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="resourceErrors">Ресурс ошибок.</param>
        /// <param name="storages">Хранилища.</param>
        public CoreCachingCache(CoreCachingResourceErrors resourceErrors, CoreCachingStorages storages)
        {
            ResourceErrors = resourceErrors;

            IsEnabled = Storages != null;

            if (IsEnabled)
            {
                GlobalStorageHelper = Storages?.Global?.Helper;
                GlobalStorageService = Storages?.Global?.Service;
                LocalStorageService = Storages?.Local?.Service;

                IsFaulty = GlobalStorageHelper != null && GlobalStorageHelper.IsFaulty;
            }
        }

        #endregion Constructors

        #region Рublic methods

        /// <inheritdoc/>
        public T Get<T>(CoreCachingKey key)
        {
            ThrowExceptionIfFaulty();

            T result = default;

            if (IsEnabled && !GlobalStorageHelper.IsFaulty)
            {
                result = LocalStorageService.GetData<T>(key);

                if (result != null) return result;

                if (GlobalStorageService != null)
                {
                    result = GlobalStorageService.GetData<T>(key);
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public bool Set<T>(CoreCachingKey key, T data)
        {
            ThrowExceptionIfFaulty();

            var isOk = !IsEnabled || false;

            if (!isOk && !GlobalStorageHelper.IsFaulty)
            {
                var value = LocalStorageService.PutData(key, data);

                isOk = value != null;

                if (isOk && GlobalStorageService != null)
                {
                    if (value is string valueString)
                    {
                        isOk = GlobalStorageService.PutData(key, valueString);
                    }
                    else
                    {
                        if (value is byte[] valueBytes)
                        {
                            isOk = GlobalStorageService.PutData(key, valueBytes);
                        }
                        else
                        {
                            isOk = false;
                        }
                    }
                }
            }

            return isOk;
        }

        /// <inheritdoc/>
        public bool Remove(IEnumerable<string> tags)
        {
            ThrowExceptionIfFaulty();

            var isOk = !IsEnabled || false;

            if (!isOk && !GlobalStorageHelper.IsFaulty)
            {
                isOk = LocalStorageService.RemoveData(tags);

                if (isOk && GlobalStorageService != null)
                {
                    GlobalStorageService.RemoveData(tags);

                    GlobalStorageHelper.PublishToRemoveData(tags);
                }
            }

            return isOk;
        }

        #endregion Рublic methods

        #region Private methods

        private void ThrowExceptionIfFaulty()
        {
            if (IsFaulty)
            {
                throw new CoreBaseException(ResourceErrors.GetStringCacheIsFaulty());
            }
        }

        #endregion Private methods

        #region Async public methods

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(CoreCachingKey key)
        {
            ThrowExceptionIfFaulty();

            T result = default;

            if (IsEnabled)
            {
                result = LocalStorageService.GetData<T>(key);

                if (result != null) return result;

                if (GlobalStorageService != null)
                {
                    result = await GlobalStorageService.GetDataAsync<T>(key).CoreBaseExtTaskWithCurrentCulture(false);
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<bool> SetAsync<T>(CoreCachingKey key, T data)
        {
            ThrowExceptionIfFaulty();

            var isOk = !IsEnabled || false;

            if (!isOk)
            {
                var value = LocalStorageService.PutData(key, data);

                isOk = value != null;

                if (isOk && GlobalStorageService != null)
                {
                    if (value is string valueString)
                    {
                        isOk = await GlobalStorageService.PutDataAsync(key, valueString).CoreBaseExtTaskWithCurrentCulture(false);
                    }
                    else
                    {
                        if (value is byte[] valueBytes)
                        {
                            isOk = await GlobalStorageService.PutDataAsync(key, valueBytes).CoreBaseExtTaskWithCurrentCulture(false);
                        }
                        else
                        {
                            isOk = false;
                        }
                    }
                }
            }

            return isOk;
        }

        /// <inheritdoc/>
        public async Task<bool> InvalidateAsync(IEnumerable<string> tags)
        {
            ThrowExceptionIfFaulty();

            var isOk = !IsEnabled || false;

            if (!isOk)
            {
                isOk = LocalStorageService.RemoveData(tags);

                if (isOk && GlobalStorageService != null)
                {
                    await GlobalStorageService.RemoveDataAsync(tags).CoreBaseExtTaskWithCurrentCulture(false);

                    await GlobalStorageHelper.PublishToRemoveDataAsync(tags).CoreBaseExtTaskWithCurrentCulture(false);
                }
            }

            return isOk;
        }

        #endregion Async public methods
    }
}