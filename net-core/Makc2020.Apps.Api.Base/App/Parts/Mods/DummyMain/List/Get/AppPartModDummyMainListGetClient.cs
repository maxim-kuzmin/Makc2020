//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.App;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Base.Logging;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using System;

namespace Makc2020.Apps.Api.Base.App.Parts.Mods.DummyMain.List.Get
{
    /// <summary>
    /// Приложение. Часть "Mods". Мод "DummyMain". Основа. Задания. Список. Получение. Клиент.
    /// </summary>
    public class AppPartModDummyMainListGetClient : CoreBaseCommonAppClient
    {
        #region Properties

        private ModDummyMainBaseJobListGetService Job { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="job">Задание.</param>
        public AppPartModDummyMainListGetClient(
            CoreBaseLoggingServiceWithCategoryName<AppPartModDummyMainListGetClient> logger,
            ModDummyMainBaseJobListGetService job
            ) : base(logger)
        {
            Job = job;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            var input = new ModDummyMainBaseJobListGetInput
            {
                PageNumber = 2,
                PageSize = 3
            };

            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobListGetOutput>();

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
