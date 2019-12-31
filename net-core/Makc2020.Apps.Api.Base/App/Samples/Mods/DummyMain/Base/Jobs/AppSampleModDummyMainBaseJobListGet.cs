//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Api.Base.App.Samples.Mods.DummyMain.Base.Jobs
{
    /// <summary>
    /// Приложение. Примеры. Мод "DummyMain". Основа. Задания. Список. Получение.
    /// </summary>
    public class AppSampleModDummyMainBaseJobListGet : AppSample
    {
        #region Properties

        private ModDummyMainBaseJobListGetService JobListGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="jobListGet">Задание на получение списка.</param>
        public AppSampleModDummyMainBaseJobListGet(
            ILogger<AppSampleModDummyMainBaseJobListGet> logger,
            ModDummyMainBaseJobListGetService jobListGet
            ) : base(logger)
        {
            JobListGet = jobListGet;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            var input = new ModDummyMainBaseJobListGetInput
            {
                DataPageNumber = 2,
                DataPageSize = 3
            };

            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobListGetOutput>();

            try
            {
                result.Data = JobListGet.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                JobListGet.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                JobListGet.OnError(ex, Logger, result);
            }

            var msg = result.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

            Log(msg);
        }

        #endregion Protected methods
    }
}
