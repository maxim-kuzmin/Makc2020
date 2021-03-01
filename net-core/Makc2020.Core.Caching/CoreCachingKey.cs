//Author Maxim Kuzmin//makc//

using System;
using System.Collections.Generic;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Ключ. 
    /// Кэширование данных осуществляется путём их размещения в хранилище. 
    /// Ключи в хранилище бывают двух типов - ключ тэга и ключ данных.
    /// Данные в хранилище размещаются по ключу данных, которому соответствует имя ключа. 
    /// Ключи данных, привязанные к тэгу, размещаются в хранилище по ключу этого тэга. 
    /// Одно и то же наименование ключа может быть связано с несколькими тэгами.
    /// Ключ кэширования должен содержать хотя бы одно значение в списке тэгов.    
    /// По ключу данных можно найти кэшируемые данные, а по ключу тэга - привязанные к нему ключи данных.
    /// Это даёт возможность удалять из хранилища все данные, связанные с каким-либо тэгом.
    /// В случае, если в таблице базы данных происходят изменения, следует удалить из хранилища все данные, 
    /// связанные с тэгом, соответствующим этой таблице.
    /// </summary>
    public class CoreCachingKey
    {
        #region Properties

        /// <summary>
        /// Имя ключа.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Окончание срока действия кэша в секундах.
        /// </summary>
        public int CacheExpiryInSeconds { get; set; }

        /// <summary>
        /// Тэги, которыми должны быть помечены данные, соответствующие ключу.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор ключа кэширования.
        /// </summary>
        /// <param name="name">Имя ключа.</param>
        public CoreCachingKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("String is null or empty or white space", "name");
            }

            Name = name;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить промежуток времени, по окончании которого прекратится срок действия кэша.
        /// </summary>
        /// <param name="defaultCacheExpiryInSeconds">Окончание срока действия в кэша секундах по умолчанию.</param>
        /// <returns>Промежуток времени, по окончании которого прекратится срок действия кэша.</returns>
        public TimeSpan? GetCacheExpiryTimeSpan(int defaultCacheExpiryInSeconds)
        {
            int cacheExpiryInSeconds = 0;

            if (CacheExpiryInSeconds > 0)
            {
                cacheExpiryInSeconds = CacheExpiryInSeconds;
            }
            else if (defaultCacheExpiryInSeconds > 0)
            {
                cacheExpiryInSeconds = defaultCacheExpiryInSeconds;
            }

            return cacheExpiryInSeconds > 0 ? TimeSpan.FromSeconds(cacheExpiryInSeconds) : (TimeSpan?)null;
        }

        #endregion Public methods
    }
}