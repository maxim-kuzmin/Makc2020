//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Ext;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching.Storages.Global
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Глобальное. Сервис.
    /// </summary>
    public partial class CoreCachingStorageGlobalService
    {
        #region Properties

        /// <summary>
        /// Помощник.
        /// </summary>
        private CoreCachingStorageGlobalHelper Helper { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор глобального хранилища для кэширования.
        /// </summary>
        /// <param name="helper">Помощник.</param>
        public CoreCachingStorageGlobalService(CoreCachingStorageGlobalHelper helper)
        {
            Helper = helper;
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

            T data = default;

            var db = Helper.GetDatabase();

            if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]))
            {
                data = (T)(dynamic)db.StringGet(dataKey);
            }
            else
            {
                byte[] value = db.StringGet(dataKey);

                if (value != null)
                {
                    data = value.CoreBaseExtProtoBufDeserialize<T>();
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
        public bool PutData<T>(CoreCachingKey key, T data)
        {
            var dataKey = Helper.ConvertToDataKey(key.Name);

            var isOk = PutDataToDatabase(dataKey, data);

            if (isOk)
            {
                var expiry = key.GetCacheExpiryTimeSpan(Helper.ExpiryInSeconds);

                if (expiry.HasValue)
                {
                    var db = Helper.GetDatabase();

                    isOk = db.KeyExpire(dataKey, expiry);
                }

                if (isOk)
                {
                    var tagKeys = Helper.ConvertToTagKeys(key.Tags);

                    BindDataKeyToTagKeys(tagKeys, dataKey);
                }
            }

            return isOk;
        }

        /// <summary>
        /// Удалить данные, связанные с указанными тэгами, из хранилища. 
        /// Если тэги не указаны или список тэгов пуст, из хранилища будут удалены все данные.
        /// </summary>
        /// <param name="tags">Тэги.</param>
        public void RemoveData(IEnumerable<string> tags)
        {
            if (tags != null && tags.Any())
            {
                var tagKeys = Helper.ConvertToTagKeys(tags);

                DeleteTagKeysWithData(tagKeys);
            }
            else
            {
                var keys = Helper.GetAllKeys().ToArray();

                if (keys.Any())
                {
                    var db = Helper.GetDatabase();

                    db.KeyDelete(keys);
                }
            }
        }

        #endregion Рublic methods

        #region Private methods

        /// <summary>
        /// Удалить ключи тэгов вместе с привязанными к ним данными.
        /// </summary>
        /// <param name="tagKeys">Ключи тэгов.</param>
        private void DeleteTagKeysWithData(IEnumerable<string> tagKeys)
        {
            var keysToDelete = new List<string>();

            var db = Helper.GetDatabase();

            foreach (var tagKey in tagKeys)
            {
                keysToDelete.Add(tagKey);

                keysToDelete.AddRange(db.ListRange(tagKey, 0, -1).Select(x => x.ToString()));
            }

            db.KeyDelete(keysToDelete.Select(x => (RedisKey)x).ToArray());
        }

        /// <summary>
        /// Привязать ключ данных к ключам тэгов.
        /// </summary>
        /// <param name="tagKeys">Ключи тэгов.</param>
        /// <param name="dataKey">Ключ данных.</param>       
        private void BindDataKeyToTagKeys(IEnumerable<string> tagKeys, string dataKey)
        {
            var db = Helper.GetDatabase();

            foreach (var tagKey in tagKeys)
            {
                db.ListRightPush(tagKey, dataKey);
            }
        }

        /// <summary>
        /// Поместить данные в базу данных.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="dataKey">Ключ данных.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Признак успешности выполнения.</returns>
        private bool PutDataToDatabase<T>(string dataKey, T data)
        {
            var isOk = false;

            if (data != null)
            {
                RedisValue value;

                if (typeof(T) == typeof(byte[]))
                {
                    value = data as byte[];
                }
                else if (typeof(T) == typeof(string))
                {
                    value = data as string;
                }
                else
                {
                    value = data.CoreBaseExtProtoBufSerialize();
                }

                var db = Helper.GetDatabase();

                isOk = db.StringSet(dataKey, value);
            }

            return isOk;
        }

        #endregion Private methods

        #region Async public methods

        /// <summary>
        /// Асинхронно получить данные из хранилища.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <returns>Задача с полученными из хранилища данными.</returns>
        public async Task<T> GetDataAsync<T>(CoreCachingKey key)
        {
            var dataKey = Helper.ConvertToDataKey(key.Name);

            T data = default;

            var db = Helper.GetDatabase();

            if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]))
            {
                data = (T)(dynamic)await db.StringGetAsync(dataKey).CoreBaseExtTaskWithCurrentCulture(false);
            }
            else
            {
                byte[] value = await db.StringGetAsync(dataKey).CoreBaseExtTaskWithCurrentCulture(false);

                if (value != null)
                {
                    data = value.CoreBaseExtProtoBufDeserialize<T>();
                }
            }

            return data;
        }

        /// <summary>
        /// Асинхронно поместить данные в хранилище.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Задача с признаком успешности выполнения.</returns>
        public async Task<bool> PutDataAsync<T>(CoreCachingKey key, T data)
        {
            var dataKey = Helper.ConvertToDataKey(key.Name);

            var isOk = await PutDataToDatabaseAsync(dataKey, data).CoreBaseExtTaskWithCurrentCulture(false);

            if (isOk)
            {
                var expiry = key.GetCacheExpiryTimeSpan(Helper.ExpiryInSeconds);

                if (expiry.HasValue)
                {
                    var db = Helper.GetDatabase();

                    isOk = await db.KeyExpireAsync(dataKey, expiry).CoreBaseExtTaskWithCurrentCulture(false);
                }

                if (isOk)
                {
                    var tagKeys = Helper.ConvertToTagKeys(key.Tags);

                    await BindDataKeyToTagKeysAsync(tagKeys, dataKey).CoreBaseExtTaskWithCurrentCulture(false);
                }
            }

            return isOk;
        }

        /// <summary>
        /// Асинхронно удалить данные, связанные с указанными тэгами, из хранилища. 
        /// Если тэги не указаны или список тэгов пуст, из хранилища будут удалены все данные.
        /// </summary>
        /// <param name="tags">Тэги.</param>
        /// <returns>Задача.</returns>
        public async Task RemoveDataAsync(IEnumerable<string> tags)
        {
            if (tags != null && tags.Any())
            {
                var tagKeys = Helper.ConvertToTagKeys(tags);

                await DeleteTableKeysWithDataAsync(tagKeys).CoreBaseExtTaskWithCurrentCulture(false);
            }
            else
            {
                var keys = Helper.GetAllKeys().ToArray();

                if (keys.Any())
                {
                    var db = Helper.GetDatabase();

                    await db.KeyDeleteAsync(keys).CoreBaseExtTaskWithCurrentCulture(false);
                }
            }
        }

        #endregion Async public methods

        #region Async private methods

        /// <summary>
        /// Асинхронно удалить ключи тэгов вместе с привязанными к ним данными.
        /// </summary>
        /// <param name="tagKeys">Ключи тэгов.</param>
        /// <returns>Задача.</returns>
        private async Task DeleteTableKeysWithDataAsync(IEnumerable<string> tagKeys)
        {
            var keysToDelete = new List<string>();

            var db = Helper.GetDatabase();

            foreach (var tagKey in tagKeys)
            {
                keysToDelete.Add(tagKey);

                keysToDelete.AddRange(db.ListRange(tagKey, 0, -1).Select(x => x.ToString()));
            }

            await db.KeyDeleteAsync(keysToDelete.Select(x => (RedisKey)x).ToArray()).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Асинхронно привязать ключ данных к ключам тэгов.
        /// </summary>
        /// <param name="tagKeys">Ключи таблиц.</param>
        /// <param name="dataKey">Ключ данных.</param>
        /// <returns>Задача.</returns>
        private async Task BindDataKeyToTagKeysAsync(IEnumerable<string> tagKeys, string dataKey)
        {
            var tasks = new List<Task<long>>();

            var db = Helper.GetDatabase();

            foreach (var tagKey in tagKeys)
            {
                tasks.Add(db.ListRightPushAsync(tagKey, dataKey));
            }

            await Task.WhenAll(tasks).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Асинхронно поместить данные в базу данных.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="dataKey">Ключ данных.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Задача с признаком успешности выполнения.</returns>
        private async Task<bool> PutDataToDatabaseAsync<T>(string dataKey, T data)
        {
            var isOk = false;

            if (data != null)
            {
                RedisValue value;

                if (typeof(T) == typeof(byte[]))
                {
                    value = data as byte[];
                }
                else if (typeof(T) == typeof(string))
                {
                    value = data as string;
                }
                else
                {
                    value = data.CoreBaseExtProtoBufSerialize();
                }

                var db = Helper.GetDatabase();

                isOk = await db.StringSetAsync(dataKey, value).CoreBaseExtTaskWithCurrentCulture(false);
            }

            return isOk;
        }

        #endregion Async private methods
    }
}