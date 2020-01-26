//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Microsoft.Extensions.Logging;

namespace Makc2020.Apps.Automation.Base.App.Common.Jobs.Code.Generate
{
    /// <summary>
    /// Приложение. Общее. Задания. Код. Генерация. Клиент.
    /// </summary>
    public abstract class AppCommonJobCodeGenerateClient<TJob> : AppCommonClient
        where TJob: ModAutomationBaseCommonJobCodeGenerateService
    {
        #region Properties

        /// <summary>
        /// Задание.
        /// </summary>
        protected TJob Job { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="job">Задание.</param>
        public AppCommonJobCodeGenerateClient(ILogger logger, TJob job) : base(logger)
        {
            Job = job;
        }

        #endregion Constructors        

        #region Protected methods

        /// <summary>
        /// Обработать прогресс файла.
        /// </summary>
        /// <param name="info">Информация.</param>
        protected void HandleFileProgress(ModAutomationBaseCommonJobCodeGenerateInfo info)
        {
            Show($"File {info.Number} from {info.Count}: {info.Path}");
        }

        /// <summary>
        /// Обработать прогресс папки.
        /// </summary>
        /// <param name="info">Информация.</param>
        protected void HandleFolderProgress(ModAutomationBaseCommonJobCodeGenerateInfo info)
        {
            Show($"Folder {info.Number} from {info.Count}: {info.Path}");
        }

        #endregion Private methods
    }
}