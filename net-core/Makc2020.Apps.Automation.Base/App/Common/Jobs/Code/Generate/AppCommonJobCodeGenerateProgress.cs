//Author Maxim Kuzmin//makc//

using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using System;

namespace Makc2020.Apps.Automation.Base.App.Common.Jobs.Code.Generate
{
    /// <summary>
    /// Приложение. Общее. Задания. Код. Генерация. Прогресс.
    /// </summary>
    public class AppCommonJobCodeGenerateProgress : IProgress<ModAutomationBaseCommonJobCodeGenerateInfo>
    {
        #region Properties

        private Action<ModAutomationBaseCommonJobCodeGenerateInfo> ActionReport { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="actionReport">Действие "Report"/</param>
        public AppCommonJobCodeGenerateProgress(Action<ModAutomationBaseCommonJobCodeGenerateInfo> actionReport)
        {
            ActionReport = actionReport;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void Report(ModAutomationBaseCommonJobCodeGenerateInfo value)
        {
            ActionReport.Invoke(value);
        }

        #endregion Public methods
    }
}
