//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Common.Client.Config;

namespace Makc2020.Core.Caching.Config
{
    /// <summary>
    /// Ядро. Кэширование. Конфигурация. Настройки. Интерфейс.
    /// </summary>
    public interface ICoreCachingConfigSettings : ICoreCachingCommonClientConfigSettings
    {
        #region Properties

        /// <summary>
        /// Таймаут подключения к глобальному хранилищу.
        /// </summary>
        int ConnectTimeout { get; }

        /// <summary>
        /// Индекс базы данных в глобальном хранилище.
        /// </summary>
        int DbIndex { get; }

        /// <summary>
        /// Хост глобального хранилища.
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Хосты глобального хранилища.
        /// </summary>
        string Hosts { get; }

        /// <summary>
        /// Признак включения глобального хранилища.
        /// </summary>
        bool IsGlobalStorageEnabled { get; }

        /// <summary>
        /// Пароль для подключения к глобальному хранилищу.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Порт глобального хранилища.
        /// </summary>
        int Port { get; }

        #endregion Properties
    }
}