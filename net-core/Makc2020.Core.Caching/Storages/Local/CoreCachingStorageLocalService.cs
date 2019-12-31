//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Core.Caching.Storages.Local
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Локальное. Сервис.
    /// Данные хранятся в памяти.
    /// </summary>
    public class CoreCachingStorageLocalService
    {
        #region Properties

        /// <summary>
        /// Кэш.
        /// </summary>
        private IMemoryCache Cache { get; set; }

        /// <summary>
        /// Ключи данных, сгруппированные по тэгам.
        /// </summary>
        private Dictionary<string, HashSet<string>> DataKeysByTag { get; set; }

        /// <summary>
        /// Помощник.
        /// </summary>
        private CoreCachingStorageLocalHelper Helper { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор локального хранилища для кэширования.
        /// </summary>
        /// <param name="helper">Помощник.</param>
        /// <param name="cache">Кэш.</param>
        public CoreCachingStorageLocalService(CoreCachingStorageLocalHelper helper, IMemoryCache cache)
        {
            Helper = helper;

            Cache = cache;

            DataKeysByTag = new Dictionary<string, HashSet<string>>();
        }

        #endregion Constructors

        #region Рublic methods

        /// <summary>
        /// Получить данные из хранилища.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <returns>Данные.</returns>
        public T GetData<T>(CoreCachingKey key)
        {
            var dataKey = Helper.ConvertToDataKey(key.Name);

            var data = default(T);

            if (Cache != null)
            {
                if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]))
                {
                    data = (T)(dynamic)Cache.Get(dataKey);
                }
                else
                {
                    var value = (byte[])Cache.Get(dataKey);

                    if (value != null)
                    {
                        data = value.CoreBaseExtProtoBufDeserialize<T>();
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Поместить данные в хранилище.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Признак успешности выполнения.</returns>
        public object PutData<T>(CoreCachingKey key, T data)
        {
            object value = null;

            var isOk = Cache == null;

            if (isOk)
            {
                value = data;
            }
            else
            {
                var dataKey = Helper.ConvertToDataKey(key.Name);

                var expiry = key.GetCacheExpiryTimeSpan(Helper.ExpiryInSeconds);

                var absoluteExpiration = expiry.HasValue ? DateTime.Now.Add(expiry.Value) : (DateTime?)null;

                var options = new MemoryCacheEntryOptions();

                if (absoluteExpiration.HasValue)
                {
                    options.AbsoluteExpiration = absoluteExpiration.Value;
                }

                if (typeof(T) == typeof(byte[]) || typeof(T) == typeof(string))
                {
                    value = data;
                }
                else
                {
                    value = data.CoreBaseExtProtoBufSerialize();
                }

                lock (DataKeysByTag)
                {
                    foreach (var tag in key.Tags)
                    {
                        HashSet<string> dataKeys;

                        if (!DataKeysByTag.TryGetValue(tag, out dataKeys))
                        {
                            dataKeys = new HashSet<string>();

                            DataKeysByTag[tag] = dataKeys;
                        }

                        dataKeys.Add(dataKey);
                    }

                    Cache.Set(dataKey, value, options);
                }

                isOk = true;
            }

            return isOk ? value : null;
        }

        /// <summary>
        /// Удалить данные, связанные с указанными тэгами, из хранилища. 
        /// Если тэги не указаны или список тэгов пуст, из хранилища будут удалены все данные.
        /// </summary>
        /// <param name="tags">Тэги, которые будут удалены.</param>
        /// <returns>Признак успешности выполнения.</returns>
        public bool RemoveData(IEnumerable<string> tags = null)
        {
            var isOk = Cache == null;

            if (!isOk)
            {
                var tagsToRemove = tags != null && tags.Any()
                    ?
                    new HashSet<string>(tags)
                    :
                    null;

                IEnumerable<string> dataKeys = null;

                lock (DataKeysByTag)
                {
                    dataKeys = DataKeysByTag
                        .Where(x => tagsToRemove == null || tagsToRemove.Contains(x.Key))
                        .SelectMany(x => x.Value)
                        .Distinct()
                        .ToArray();

                    if (tagsToRemove != null)
                    {
                        foreach (var tag in tagsToRemove)
                        {
                            DataKeysByTag.Remove(tag);
                        }
                    }
                    else
                    {
                        DataKeysByTag.Clear();
                    }

                    foreach (var dataKey in dataKeys)
                    {
                        Cache.Remove(dataKey);
                    }
                }

                isOk = true;
            }

            return isOk;
        }

        #endregion Рublic methods
    }
}