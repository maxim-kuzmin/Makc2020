//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Core.Caching
{
    /// <summary>
    /// Ядро. Кэширование. Кэш. Интерфейс
    /// </summary>
    public interface ICoreCachingCache
    {
        #region Properties

        /// <summary>
        /// Признак неисправности кэша.
        /// </summary>
        bool IsFaulty { get; }

        /// <summary>
        /// Признак включения кэша.
        /// </summary>
        bool IsEnabled { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Получить данные из кэша.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <returns>Данные.</returns>
        T Get<T>(CoreCachingKey key);

        /// <summary>
        /// Вставить данные в кэш.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Признак успешности выполнения.</returns>
        bool Set<T>(CoreCachingKey key, T data);

        /// <summary>
        /// Удалить данные, связанные с указанными тэгами, из кэша. 
        /// Если тэги не указаны или список тэгов пуст, из кэша будут удалены все данные.
        /// </summary>
        /// <param name="tags">Тэги.</param>
        /// <returns>Признак успешности выполнения.</returns>
        bool Remove(IEnumerable<string> tags = null);

        #endregion Methods

        #region Async methods

        /// <summary>
        /// Асинхронно получить данные.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <returns>Задача с полученными из кэша данными.</returns>
        Task<T> GetAsync<T>(CoreCachingKey key);

        /// <summary>
        /// Асинхронно вставить данные.
        /// </summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="key">Ключ.</param>
        /// <param name="data">Данные.</param>
        /// <returns>Задача с признаком успешности выполнения.</returns>
        Task<bool> SetAsync<T>(CoreCachingKey key, T data);

        /// <summary>
        /// Асинхронно сделать недействительными (удалить из кэша) данные, связанные с указанными тэгами. 
        /// Если список тэгов пуст, из кэша будут удалены все данные.
        /// </summary>
        /// <param name="tags">Тэги.</param>
        /// <returns>Задача с признаком успешности выполнения.</returns>
        Task<bool> InvalidateAsync(IEnumerable<string> tags = null);

        #endregion Async methods
    }
}