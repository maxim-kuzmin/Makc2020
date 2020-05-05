//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Logging;
using System;

namespace Makc2020.Core.Base.Common.App
{
    /// <summary>
    /// Ядро. Основа. Общее. Приложение. Клиент.
    /// </summary>
    public abstract class CoreBaseCommonAppClient
    {
        #region Properties

        protected CoreBaseLoggingService Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        public CoreBaseCommonAppClient(CoreBaseLoggingService logger)
        {
            Logger = logger;
        }

        #endregion Constructors

        #region Public methods

        public void Run()
        {
            Show($"### {GetType().Name} start ###");

            DoRun();

            Show($"### {GetType().Name} finish ###");
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Действительно запустить.
        /// </summary>
        protected abstract void DoRun();

        /// <summary>
        /// Показать.
        /// </summary>
        /// <param name="msg">Сообщение.</param>
        /// <param name="isLoggingNeeded">Признак необходимости логирования. По-умолчанию: true.</param>
        protected void Show(string msg, bool isLoggingNeeded = true)
        {
            if (isLoggingNeeded)
            {
                Logger.LogDebug(msg);
            }

            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine();
        }

        #endregion Protected methods
    }
}