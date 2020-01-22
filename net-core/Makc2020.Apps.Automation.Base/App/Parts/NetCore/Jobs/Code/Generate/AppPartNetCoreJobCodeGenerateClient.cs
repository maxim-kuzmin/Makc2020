//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Automation.Base.App.Common.Jobs.Code.Generate;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Mods.Automation.Base.Common.Code.Generate;
using Makc2020.Mods.Automation.Base.Parts.NetCore.Jobs.Code.Generate;
using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Automation.Base.App.Parts.NetCore.Jobs.Code.Generate
{
    /// <summary>
    /// Приложение. Часть "NetCore". Задания. Код. Генерация. Клиент.
    /// </summary>
    public class AppPartNetCoreJobCodeGenerateClient : AppCommonJobCodeGenerateClient<ModAutomationBasePartNetCoreJobCodeGenerateService>
    {
        #region Constructors

        /// <inheritdoc/>
        public AppPartNetCoreJobCodeGenerateClient(
            ILogger<AppPartNetCoreJobCodeGenerateClient> logger,
            ModAutomationBasePartNetCoreJobCodeGenerateService job
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
                FileHandleProgress = new AppCommonJobCodeGenerateProgress(HandleFileProgress),
                FolderHandleProgress = new AppCommonJobCodeGenerateProgress(HandleFolderProgress)
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

            Log(msg);
        }

        #endregion Protected methods
    }
}