//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Localization;

namespace Makc2020.Core.Caching.Resources.Errors
{
    /// <summary>
    /// Ядро. Кэширование. Ресурсы. Ошибки.
    /// </summary>
    public class CoreCachingResourceErrors
    {
        #region Properties

        private IStringLocalizer<CoreCachingResourceErrors> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CoreCachingResourceErrors(IStringLocalizer<CoreCachingResourceErrors> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить строку "Кэш неисправен".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringCacheIsFaulty()
        {
            return Localizer["Кэш неисправен"];
        }

        /// <summary>
        /// Получить строку "Не получается удалить данные из кэша".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringCantRemoveDataFromCache()
        {
            return Localizer["Не получается удалить данные из кэша"];
        }

        /// <summary>
        /// Получить строку форматирования "Не удалось подключиться к Redis с конфигурацией: {0}".
        /// </summary>
        /// <returns>Строка.</returns>
        public string GetStringFormatUnableToConnectToRedis()
        {
            return Localizer["Не удалось подключиться к Redis с конфигурацией: {0}"];
        }

        #endregion Public methods
    }
}