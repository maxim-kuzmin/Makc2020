//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base
{
    /// <summary>
    /// Ядро. Основа. Окружение.
    /// </summary>
    public class CoreBaseEnvironment
    {
        #region Properties

        /// <summary>
        /// Базовый путь: абсолютный путь к папке, относительно которой указываются пути к файлам.
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        #endregion Properties
    }
}
