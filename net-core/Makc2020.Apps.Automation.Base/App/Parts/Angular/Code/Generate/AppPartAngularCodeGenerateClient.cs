//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Automation.Base.App.Common.Code.Generate;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Logging;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.Angular.Jobs.Code.Generate;
using System;

namespace Makc2020.Apps.Automation.Base.App.Parts.Angular.Code.Generate
{
    /// <summary>
    /// Приложение. Часть "Angular". Код. Генерация. Клиент.
    /// </summary>
    public class AppPartAngularCodeGenerateClient : AppCommonCodeGenerateClient<ModAutomationBasePartAngularJobCodeGenerateService>
    {
        #region Constructors

        /// <inheritdoc/>
        public AppPartAngularCodeGenerateClient(
            CoreBaseLoggingServiceWithCategoryName<AppPartAngularCodeGenerateClient> logger,
            ModAutomationBasePartAngularJobCodeGenerateService job
            ) : base(logger, job)
        {
        }

        #endregion Constructors        

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            var input = new ModAutomationBaseCommonJobCodeGenerateInput
            {
                FileHandleProgress = new AppCommonCodeGenerateProgress(HandleFileProgress),
                FolderHandleProgress = new AppCommonCodeGenerateProgress(HandleFolderProgress)
            };
            
            var result = new CoreBaseExecutionResult();

            try
            {
                Job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                Job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                Job.OnError(ex, Logger, result);
            }

            var msg = result.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

            Show(msg, false);
        }

        #endregion Protected methods
    }
}