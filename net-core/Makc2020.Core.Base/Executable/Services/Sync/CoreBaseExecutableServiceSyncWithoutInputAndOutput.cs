//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using System;

namespace Makc2020.Core.Base.Executable.Services.Sync
{
    /// <summary>
    /// Ядро. Основа. Выполняемое. Сервис синхронный без ввода и вывода.
    /// </summary>
    public class CoreBaseExecutableServiceSyncWithoutInputAndOutput
        : CoreBaseExecutableServiceWithoutInputAndOutput
    {
        #region Properties

        /// <summary>
        /// Выполняемое.
        /// </summary>
        public Action Executable { get; protected set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public CoreBaseExecutableServiceSyncWithoutInputAndOutput(
            Action executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(coreBaseResourceErrors)
        {
            Executable = executable;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Выполнить.
        /// </summary>
        public void Execute()
        {
            Executable.Invoke();
        }

        #endregion Public methods
    }
}
