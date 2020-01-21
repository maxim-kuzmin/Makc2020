//Author Maxim Kuzmin//makc//

using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Api.Base.App.Common
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
            Log($"### {GetType().Name} start ###");

            DoRun();

            Log($"### {GetType().Name} finish ###");
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Действительно запустить.
        /// </summary>
        protected abstract void DoRun();

        /// <summary>
        /// Регистрировать.
        /// </summary>
        /// <param name="msg">Сообщение.</param>
        protected void Log(string msg)
        {
            Logger.LogDebug(msg);

            Console.WriteLine();
            Console.WriteLine(msg);
            Console.WriteLine();
        }

        #endregion Protected methods
    }
}