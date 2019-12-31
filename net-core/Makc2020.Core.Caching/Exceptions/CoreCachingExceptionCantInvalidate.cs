//Author Maxim Kuzmin//makc//

using Makc2020.Core.Caching.Resources.Errors;
using System;

namespace Makc2020.Core.Caching.Exceptions
{
    /// <summary>
    /// Ядро. Кэширование. Исключения. Исключение, возникающее при невозможности 
    /// сделать данные в кэше недействительными.
    /// </summary>
    public class CoreCachingExceptionCantInvalidate : Exception
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coreCachingResourceErrors">Ресурсы ошибок ядра кэширования.</param>
        public CoreCachingExceptionCantInvalidate(CoreCachingResourceErrors coreCachingResourceErrors)
            : base(coreCachingResourceErrors.GetStringCantRemoveDataFromCache())
        {
        }

        #endregion Constructors
    }
}
