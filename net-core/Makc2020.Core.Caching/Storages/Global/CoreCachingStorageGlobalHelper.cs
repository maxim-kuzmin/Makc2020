//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Caching.Config;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Core.Caching.Storages.Local;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching.Storages.Global
{
    /// <summary>
    /// Ядро. Кэширование. Хранилища. Глобальное. Помощник.
    /// </summary>
    public sealed class CoreCachingStorageGlobalHelper
    {
        #region Properties

        /// <summary>
        /// Помощник.
        /// </summary>
        private CoreCachingStorageLocalHelper Helper { get; set; }

        /// <summary>
        /// Индекс базы данных.
        /// </summary>
        private int DbIndex { get; set; }

        /// <summary>
        /// Подключение.
        /// </summary>
        private ConnectionMultiplexer Connection { get; set; }

        /// <summary>
        /// Образец канала для удаления.
        /// </summary>
        private string ChannelPatternForRemoveData { get; set; }

        /// <summary>
        /// Образец канала для очистки.
        /// </summary>
        private string ChannelPatternForRemoveAllData { get; set; }

        /// <summary>
        /// Признак неисправности.
        /// </summary>
        public bool IsFaulty
        {
            get
            {
                return Helper.IsFaulty;
            }
        }

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        public int ExpiryInSeconds
        {
            get
            {
                return Helper.ExpiryInSeconds;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор помощника для глобального хранилища.
        /// </summary>
        /// <param name="helper">Помощник для локального хранилища.</param>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public CoreCachingStorageGlobalHelper(
            CoreCachingStorageLocalHelper helper,
            ICoreCachingConfigSettings configSettings,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
        {
            Helper = helper;

            DbIndex = configSettings.DbIndex;

            ChannelPatternForRemoveData = Helper.CacheKeyPrefix + ".remove.*";
            ChannelPatternForRemoveAllData = Helper.CacheKeyPrefix + ".flush*";

            var options = string.IsNullOrWhiteSpace(configSettings.Hosts)
                ?
                ConfigurationOptions.Parse(string.Concat(configSettings.Host, ":", configSettings.Port))
                :
                ConfigurationOptions.Parse(configSettings.Hosts);

            options.AllowAdmin = true;
            options.Password = configSettings.Password;
            options.AbortOnConnectFail = false;
            options.ConnectTimeout = configSettings.ConnectTimeout;

            Connection = ConnectionMultiplexer.Connect(options);

            if (!Connection.IsConnected)
            {
                throw new CoreBaseException(
                      string.Format(
                          coreCachingResourceErrors.GetStringFormatUnableToConnectToRedis(),
                          configSettings.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger)
                          )
                      );
            }
        }

        #endregion Constructors

        #region Рublic methods

        /// <summary>
        /// Подписаться на публикацию событий.
        /// </summary>
        /// <param name="onRemoveData">Обработчик события по удалению данных по ключу.</param>
        /// <param name="onRemoveAllData">Обработчик события по удалению всех данных.</param>
        public void Subscribe(Action<byte[]> onRemoveData, Action onRemoveAllData)
        {
            var subscriber = Connection.GetSubscriber();

            subscriber.Subscribe(ChannelPatternForRemoveData, (channel, value) => onRemoveData(value));
            subscriber.Subscribe(ChannelPatternForRemoveAllData, (channel, value) => onRemoveAllData());
        }

        /// <summary>
        /// Получить базу данных хранилища.
        /// </summary>
        /// <returns>База данных.</returns>
        public IDatabase GetDatabase()
        {
            return Connection.GetDatabase(DbIndex);
        }

        /// <summary>
        /// Получить все ключи в хранилище.
        /// </summary>
        /// <param name="pattern">Образец для поиска ключей.</param>
        /// <returns>Список ключей в хранилище.</returns>
        public IEnumerable<RedisKey> GetAllKeys(string pattern = null)
        {
            var result = new List<RedisKey>();

            foreach (var endpoint in Connection.GetEndPoints())
            {
                var server = Connection.GetServer(endpoint);

                if (!server.IsReplica && server.IsConnected)
                {
                    var keys = server.Keys(
                        database: DbIndex,
                        pattern: pattern != null ? ConvertToDataKey(pattern) : ConvertToDataKey("*")
                        );

                    result.AddRange(keys);
                }
            }

            return result;
        }

        /// <summary>
        /// Опубликовать событие по удалению данных.
        /// </summary>
        /// <param name="tags">Тэги, которые привязаны к удаляемым данным.</param>
        public void PublishToRemoveData(IEnumerable<string> tags)
        {
            if (tags != null && tags.Any())
            {
                var tagKeys = ConvertToTagKeys(tags);

                foreach (var tagKey in tagKeys)
                {
                    var channel = CreateChannelForRemoveData(tagKey);

                    GetDatabase().Publish(channel, tagKey);
                }
            }
            else
            {
                var channel = CreateChannelForRemoveAllData();

                GetDatabase().Publish(channel, string.Empty);
            }
        }

        /// <summary>
        /// Преобразовать ключ к ключу данных.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Ключ данных.</returns>
        public string ConvertToDataKey(string key)
        {
            return Helper.ConvertToDataKey(key);
        }

        /// <summary>
        /// Преобразовать ключи к ключам тэгов.
        /// </summary>
        /// <param name="keys">Ключи.</param>
        /// <returns>Ключи тэгов.</returns>
        public IEnumerable<string> ConvertToTagKeys(IEnumerable<string> keys)
        {
            return keys.Select(x => string.Concat(Helper.CacheKeyPrefix, ".Tag.", x)).ToArray();
        }

        #endregion Рublic methods

        #region Private methods

        /// <summary>
        /// Создать канал для удаления данных по ключу.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Канал для удаления данных.</returns>
        private string CreateChannelForRemoveData(string key)
        {
            return ChannelPatternForRemoveData.Substring(0, ChannelPatternForRemoveData.Length - 1) + key;
        }

        /// <summary>
        /// Создать канал для удаления всех данных.
        /// </summary>
        /// <returns>Канал для удаления всех данных.</returns>
        private string CreateChannelForRemoveAllData()
        {
            return ChannelPatternForRemoveAllData.Substring(0, ChannelPatternForRemoveAllData.Length - 1);
        }

        #endregion Private methods

        #region Async public methods

        /// <summary>
        /// Асинхронно подписаться на публикацию событий.
        /// </summary>
        /// <param name="onRemoveData">Обработчик события по удалению данных по ключу.</param>
        /// <param name="onRemoveAllData">Обработчик события по удалению всех данных.</param>
        public async Task SubscribeAsync(Action<byte[]> onRemoveData, Action onRemoveAllData)
        {
            var subscriber = Connection.GetSubscriber();

            var task1 = subscriber.SubscribeAsync(ChannelPatternForRemoveData, (channel, value) => onRemoveData(value));
            var task2 = subscriber.SubscribeAsync(ChannelPatternForRemoveAllData, (channel, value) => onRemoveAllData());

            await Task.WhenAll(task1, task2).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Асинхронно опубликовать событие по удалению данных.
        /// </summary>
        /// <param name="tags">Тэги, которые привязаны к удаляемым данным.</param>
        /// <returns>Задача.</returns>
        public async Task PublishToRemoveDataAsync(IEnumerable<string> tags)
        {
            if (tags != null && tags.Any())
            {
                var tagKeys = ConvertToTagKeys(tags);

                var tasks = new List<Task>();

                foreach (var tagKey in tagKeys)
                {
                    var channel = CreateChannelForRemoveData(tagKey);

                    tasks.Add(GetDatabase().PublishAsync(channel, tagKey));
                }

                await Task.WhenAll(tasks).CoreBaseExtTaskWithCurrentCulture(false);
            }
            else
            {
                var channel = CreateChannelForRemoveAllData();

                await GetDatabase().PublishAsync(channel, string.Empty).CoreBaseExtTaskWithCurrentCulture(false);
            }
        }

        #endregion Async public methods
    }
}