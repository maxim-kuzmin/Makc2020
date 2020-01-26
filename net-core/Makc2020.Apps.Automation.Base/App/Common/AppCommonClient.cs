//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Automation.Base.App.Common
{
    /// <summary>
    /// Приложение. Общее. Клиент.
    /// </summary>
    public abstract class AppCommonClient
    {
        #region Properties

        protected ILogger Logger { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        public AppCommonClient(ILogger logger)
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