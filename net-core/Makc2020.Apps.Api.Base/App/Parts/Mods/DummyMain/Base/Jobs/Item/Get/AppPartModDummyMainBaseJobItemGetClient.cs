//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App.Common;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.Base.Jobs.Item.Get
{
    /// <summary>
    /// Приложение. Часть "Mods". Мод "DummyMain". Основа. Задания. Элемент. Получение. Клиент.
    /// </summary>
    public class AppPartModDummyMainBaseJobItemGetClient : AppCommonClient
    {
        #region Properties

        private ModDummyMainBaseJobItemGetService Job { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="job">Задание.</param>
        public AppPartModDummyMainBaseJobItemGetClient(
            ILogger<AppPartModDummyMainBaseJobItemGetClient> logger,
            ModDummyMainBaseJobItemGetService job
            ) : base(logger)
        {
            Job = job;
        }

        #endregion Constructors        

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            var input = new ModDummyMainBaseJobItemGetInput
            {
                DataId = 1
            };

            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobItemGetOutput>();

            try
            {
                result.Data = Job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

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