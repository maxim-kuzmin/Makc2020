//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Microsoft.Extensions.Logging;
using System;

namespace Makc2020.Apps.Api.Base.App.Samples.Mods.DummyMain.Base.Jobs
{
    /// <summary>
    /// Приложение. Примеры. Мод "DummyMain". Основа. Задания. Элемент. Получение.
    /// </summary>
    public class AppSampleModDummyMainBaseJobItemGet : AppSample
    {
        #region Properties

        private ModDummyMainBaseJobItemGetService JobItemGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="jobItemGet">Задание на получение элемента.</param>
        public AppSampleModDummyMainBaseJobItemGet(
            ILogger<AppSampleModDummyMainBaseJobItemGet> logger,
            ModDummyMainBaseJobItemGetService jobItemGet
            ) : base(logger)
        {
            JobItemGet = jobItemGet;
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
                result.Data = JobItemGet.Execute(input).CoreBaseExtTaskWithCurrentCulture(false).GetResult();

                JobItemGet.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                JobItemGet.OnError(ex, Logger, result);
            }

            var msg = result.CoreBaseExtJsonSerialize(CoreBaseExtJson.OptionsForLogger);

            Log(msg);
        }

        #endregion Protected methods
    }
}