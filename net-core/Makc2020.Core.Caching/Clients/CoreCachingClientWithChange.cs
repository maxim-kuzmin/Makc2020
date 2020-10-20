//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Ext;
using Makc2020.Core.Caching.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching.Clients
{
    /// <summary>
    /// Ядро. Модуль. Кэширование. Клиенты. Клиент с изменением кэшируемых данных.
    /// </summary>    
    public class CoreCachingClientWithChange
    {
        #region Properties

        /// <summary>
        /// Кэш.
        /// </summary>
        private ICoreCachingCache Cache { get; set; }

        /// <summary>
        /// Ядро. Кэширование. Ресурсы. Ошибки.
        /// </summary>
        private CoreCachingResourceErrors CoreCachingResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="cache">Кэш.</param>
        /// <param name="coreCachingResourceErrors">Ядро. Кэширование. Ресурсы. Ошибки.</param>
        public CoreCachingClientWithChange(
            ICoreCachingCache cache,
            CoreCachingResourceErrors coreCachingResourceErrors
            )
        {
            Cache = cache;
            CoreCachingResourceErrors = coreCachingResourceErrors;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Изменить и прочитать данные.
        /// </summary>
        /// <param name="func">Функция для получения данных.</param>
        /// <param name="tags">Тэги.</param>
        /// <returns>Задача с данными.</returns>
        public Task Change(Func<Task> func, string[] tags)
        {
            return func.CoreCachingExtInvokeChange(Cache, tags, CoreCachingResourceErrors);
        }

        #endregion Public methods
    }
}
