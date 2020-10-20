//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Makc2020.Core.Caching.Common.Client.Config;
using Makc2020.Core.Caching.Ext;
using Makc2020.Core.Caching.Resources.Errors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching.Clients
{
    /// <summary>
    /// Ядро. Модуль. Кэширование. Клиенты. Клиент с изменением и чтением кэшируемых данных.
    /// </summary>
    /// <typeparam name="T">Тип кэшируемых данных.</typeparam>
    public class CoreCachingClientWithChangeAndRead<T>
        where T: class
    {
        #region Properties

        /// <summary>
        /// Имя.
        /// </summary>
        private string Name { get; set; }

        /// <summary>
        /// Кэш.
        /// </summary>
        private ICoreCachingCache Cache { get; set; }

        /// <summary>
        /// Конфигурационные настройки.
        /// </summary>
        private ICoreCachingCommonClientConfigSettings ConfigSettings { get; set; }

        /// <summary>
        /// Ядро. Кэширование. Ресурсы. Ошибки.
        /// </summary>
        private CoreCachingResourceErrors CoreCachingResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>       
        /// <param name="cacheSettings">Кэширование. Настройки.</param>
        /// <param name="cache">Кэш.</param>    
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        public CoreCachingClientWithChangeAndRead(
            string name,
            ICoreCachingCommonClientConfigSettings cacheSettings,
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
        {
            Name = cacheSettings.CacheKeyPrefix + name;
            ConfigSettings = cacheSettings;
            Cache = cache;
            CoreCachingResourceErrors = coreCachingResourceErrors;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Прочитать данные.
        /// </summary>
        /// <param name="func">Функция для получения данных.</param>
        /// <param name="keys">Ключи. Они будут использоваться для формирования имени ключа кэширования.</param>
        /// <param name="tags">Тэги. Они будут использоваться в качестве тэгов ключа кэширования.</param>
        /// <returns>Задача с данными.</returns>
        public Task<T> Read(Func<Task<T>> func, object[] keys, string[] tags)
        {
            var nameParts = new List<object>();

            nameParts.Add(Name);

            if (keys != null && keys.Any())
            {
                nameParts.AddRange(keys);
            }

            var cacheKey = CreateCacheKey(nameParts, tags, ConfigSettings.CacheExpiryInSeconds);

            return func.CoreCachingExtInvokeRead(Cache, cacheKey);
        }

        /// <summary>
        /// Изменить и прочитать данные.
        /// </summary>
        /// <param name="func">Функция для получения данных.</param>
        /// <param name="tags">Тэги.</param>
        /// <returns>Задача с данными.</returns>
        public Task<T> ChangeAndRead(Func<Task<T>> func, string[] tags)
        {
            return func.CoreCachingExtInvokeChangeAndRead(Cache, tags, CoreCachingResourceErrors);
        }

        #endregion Public methods

        #region Private methods

        /// <summary>
        /// Создать ключ кэша.
        /// </summary>
        /// <param name="nameParts">Части имени.</param>
        /// <param name="tags">Тэги.</param>
        /// <param name="cacheExpiryInSeconds">Окончание срока действия кэша в секундах.</param>
        /// <returns>Ключ кэша.</returns>
        private CoreCachingKey CreateCacheKey(
            IEnumerable<object> nameParts,
            IEnumerable<string> tags,
            int cacheExpiryInSeconds
            )
        {
            if (nameParts == null || !nameParts.Any())
            {
                throw new ArgumentException("Enumeration is null or empty", "keyParts");
            }

            if (tags == null || !tags.Any())
            {
                throw new ArgumentException("Enumeration is null or empty", "tags");
            }

            if (cacheExpiryInSeconds < 0)
            {
                throw new ArgumentException(string.Format("{0} is less than zero", cacheExpiryInSeconds), "cacheExpiryInSeconds");
            }

            var result = new CoreCachingKey(
                string.Concat("{", string.Join(",", nameParts.Select(x => ConvertToString(x))), "}")
                );

            result.Tags = tags;
            result.CacheExpiryInSeconds = cacheExpiryInSeconds;

            return result;
        }

        private string ConvertToString(object obj)
        {
            if (obj == null) return "NULL";

            if (obj is string) return (string)obj;

            if (obj is IEnumerable)
            {
                var items = (IEnumerable)obj;

                var sb = new StringBuilder();

                foreach (var item in items)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }

                    sb.Append(ConvertToString(item));
                }

                return string.Concat("[", sb.Length > 0 ? sb.ToString() : string.Empty, "]");
            }

            if (obj is DateTime)
            {
                return ((DateTime)obj).CoreBaseExtConvertFromDateTimeToRoundTripString();
            }
            if (obj is DateTime?)
            {
                return ((DateTime?)obj).Value.CoreBaseExtConvertFromDateTimeToRoundTripString();
            }
            else if (obj is DateTimeOffset)
            {
                return ((DateTimeOffset)obj).CoreBaseExtConvertFromDateTimeOffsetToRoundTripString();
            }
            else if (obj is DateTimeOffset?)
            {
                return ((DateTimeOffset?)obj).Value.CoreBaseExtConvertFromDateTimeOffsetToRoundTripString();
            }

            return obj.ToString();
        }

        #endregion Private methods
    }
}