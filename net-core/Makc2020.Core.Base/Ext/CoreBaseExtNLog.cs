//Author Maxim Kuzmin//makc//

using NLog;
using System;
using System.IO;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. NLog.
    /// </summary>
    public static class CoreBaseExtNLog
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. NLog. Загрузить конфигурацию.
        /// </summary>
        /// <param name="logFactory">Фабрика логирования.</param>
        /// <param name="absolutePathToFileWithoutExtension">Абсолютный путь к файлу без расширения.</param>
        /// <param name="environmentName">Имя окружения.</param>
        /// <returns>Фабрика логирования.</returns>
        public static LogFactory CoreBaseExtNLogLoadConfiguration(
            this LogFactory logFactory,
            string absolutePathToFileWithoutExtension,
            string environmentName
            )
        {
            const string fileExtension = ".xml";

            var machineName = Environment.MachineName.ToUpper();

            var filePath = $"{absolutePathToFileWithoutExtension}.m.{machineName}{fileExtension}";

            var isOk = false;

            if (File.Exists(filePath))
            {
                logFactory.LoadConfiguration(filePath);

                isOk = true;
            }

            if (!isOk && !string.IsNullOrWhiteSpace(environmentName))
            {
                filePath = $"{absolutePathToFileWithoutExtension}.{environmentName}{fileExtension}";

                if (File.Exists(filePath))
                {
                    logFactory.LoadConfiguration(filePath);

                    isOk = true;
                }
            }

            if (!isOk)
            {
                filePath = $"{absolutePathToFileWithoutExtension}{fileExtension}";

                if (File.Exists(filePath))
                {
                    logFactory.LoadConfiguration(filePath);

                    isOk = true;
                }
            }

            if (!isOk)
            {
                throw new FileNotFoundException($"NLog configuration file \"{filePath}\" not found");
            }

            return logFactory;
        }

        #endregion Public methods
    }
}
