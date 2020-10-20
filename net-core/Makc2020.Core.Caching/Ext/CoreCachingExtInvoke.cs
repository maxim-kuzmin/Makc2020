//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Exceptions;
using Makc2020.Core.Base.Ext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makc2020.Core.Caching.Resources.Errors;

namespace Makc2020.Core.Caching.Ext
{
    /// <summary>
    /// Ядро. Кэширование. Расширение. Вызвать.
    /// </summary>
    public static class CoreCachingExtInvoke
    {
        #region Public methods

        /// <summary>
        /// Ядро. Кэширование. Расширение. Вызвать. Чтение.
        /// При этом происходит занесение в кэш результатов чтения.
        /// </summary>
        /// <typeparam name="T">Тип данных, возвращаемых функцией чтения.</typeparam>
        /// <param name="func">Функция чтения.</param>
        /// <param name="cache">Кэш.</param>
        /// <param name="cacheKey">Ключ кэша.</param>        
        /// <returns>Задача, возвращаемая функцией чтения.</returns>
        public static async Task<T> CoreCachingExtInvokeRead<T>(
            this Func<Task<T>> func,
            ICoreCachingCache cache,
            CoreCachingKey cacheKey            
            )
            where T : class
        {
            T result = null;

            var isCachingEnabled = cache != null && cache.IsEnabled && cacheKey != null;

            if (isCachingEnabled)
            {
                result = await cache.GetAsync<T>(cacheKey).CoreBaseExtTaskWithCurrentCulture(false);
            }

            if (result == null)
            {
                result = await func.Invoke().CoreBaseExtTaskWithCurrentCulture(false);

                if (isCachingEnabled)
                {
                    if (!await cache.SetAsync(cacheKey, result).CoreBaseExtTaskWithCurrentCulture(false))
                    {
                        result = null;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Ядро. Кэширование. Расширение. Вызвать. Изменение и чтение.
        /// При этом из кэша удаляются те данные, чей ключ содержит указанные тэги.
        /// </summary>
        /// <typeparam name="T">Тип данных, возвращаемых функцией изменения и чтения.</typeparam>
        /// <param name="func">Функция изменения и чтения.</param>
        /// <param name="cache">Кэш.</param>
        /// <param name="tags">
        /// Тэги, по которым будет производиться поиск ключей удаляемых из кэша данных.
        /// </param>
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        /// <returns>
        /// Задача, возвращаемая функцией изменения и чтения.
        /// </returns>
        public static async Task<T> CoreCachingExtInvokeChangeAndRead<T>(
            this Func<Task<T>> func,
            ICoreCachingCache cache,
            IEnumerable<string> tags,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
            where T : class
        {
            var result = await func.Invoke().CoreBaseExtTaskWithCurrentCulture(false);

            if (cache != null && cache.IsEnabled && tags != null && tags.Any())
            {
                if (!await cache.InvalidateAsync(tags).CoreBaseExtTaskWithCurrentCulture(false))
                {
                    throw new CoreCachingExceptionCantInvalidate(coreCachingResourceErrors);
                }
            }

            return result;
        }

        /// <summary>
        /// Ядро. Кэширование. Расширение. Вызвать. Изменение.
        /// При этом из кэша удаляются те данные, чей ключ содержит указанные тэги.
        /// </summary>
        /// <param name="func">Функция изменения.</param>
        /// <param name="cache">Кэш.</param>
        /// <param name="tags">
        /// Тэги, по которым будет производиться поиск ключей удаляемых из кэша данных.
        /// </param>
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        /// <returns>Задача, возвращаемая функцией изменения.</returns>
        public static async Task CoreCachingExtInvokeChange(
            this Func<Task> func,
            ICoreCachingCache cache,
            IEnumerable<string> tags,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
        {
            await func.Invoke().CoreBaseExtTaskWithCurrentCulture(false);

            if (cache != null && cache.IsEnabled && tags != null && tags.Any())
            {
                if (!await cache.InvalidateAsync(tags).CoreBaseExtTaskWithCurrentCulture(false))
                {
                    throw new CoreCachingExceptionCantInvalidate(coreCachingResourceErrors);
                }
            }
        }

        #endregion Public methods
    }
}
