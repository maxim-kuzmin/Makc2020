//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Core.Web.Api;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Options.Get.Output;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyMain.Caching.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyManyToMany.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Контроллер.
    /// </summary>
    [Route("api/dummy-main")]
    public class ModDummyMainWebApiController : CoreWebApiController
    {
        #region Properties

        private ModDummyMainCachingJobItemDeleteService JobItemDelete { get; set; }

        private ModDummyMainCachingJobItemGetService JobItemGet { get; set; }

        private ModDummyMainCachingJobItemInsertService JobItemInsert { get; set; }

        private ModDummyMainCachingJobItemUpdateService JobItemUpdate { get; set; }

        private ModDummyMainCachingJobListGetService JobListGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyManyToManyGetService JobOptionsDummyManyToManyGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyOneToManyGetService JobOptionsDummyOneToManyGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="jobItemDelete">Задание на удаление элемента.</param>
        /// <param name="jobItemGet">Задание на получение элемента.</param>
        /// <param name="jobItemInsert">Задание на вставку элемента.</param>
        /// <param name="jobItemUpdate">Задание на обновление элемента.</param>
        /// <param name="jobListGet">Задание на получение списка.</param>
        /// <param name="jobOptionsDummyManyToManyGet">
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </param>
        /// <param name="jobOptionsDummyOneToManyGet">
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </param>
        public ModDummyMainWebApiController(
            ILogger<ModDummyMainWebApiController> logger,
            ModDummyMainCachingJobItemDeleteService jobItemDelete,
            ModDummyMainCachingJobItemGetService jobItemGet,
            ModDummyMainCachingJobItemInsertService jobItemInsert,
            ModDummyMainCachingJobItemUpdateService jobItemUpdate,
            ModDummyMainCachingJobListGetService jobListGet,
            ModDummyMainCachingJobOptionsDummyManyToManyGetService jobOptionsDummyManyToManyGet,
            ModDummyMainCachingJobOptionsDummyOneToManyGetService jobOptionsDummyOneToManyGet
            )
            : base(logger)
        {
            JobItemDelete = jobItemDelete;
            JobItemGet = jobItemGet;
            JobItemInsert = jobItemInsert;
            JobItemUpdate = jobItemUpdate;
            JobListGet = jobListGet;
            JobOptionsDummyManyToManyGet = jobOptionsDummyManyToManyGet;
            JobOptionsDummyOneToManyGet = jobOptionsDummyOneToManyGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("list"), HttpGet]
        public async Task<IActionResult> Get(ModDummyMainBaseJobListGetInput input)
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobListGetOutput>();

            var job = JobListGet;

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpGet]
        public async Task<IActionResult> Get(ModDummyMainBaseJobItemGetInput input)
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobItemGetOutput>();

            var job = JobItemGet;

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyManyToMany".
        /// </summary>
        /// <returns>Результат выполнения с вариантами выбора.</returns>
        [Route("options/dummy-many-to-many"), HttpGet]
        public async Task<IActionResult> GetOptionsDummyManyToMany()
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseCommonJobOptionsGetOutputList>();

            var job = JobOptionsDummyManyToManyGet;

            try
            {
                result.Data = await job.Execute().CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить варианты выбора сущности "DummyOneToMany".
        /// </summary>
        /// <returns>Результат выполнения с вариантами выбора.</returns>
        [Route("options/dummy-one-to-many"), HttpGet]
        public async Task<IActionResult> GetOptionsDummyOneToMany()
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseCommonJobOptionsGetOutputList>();

            var job = JobOptionsDummyOneToManyGet;

            try
            {
                result.Data = await job.Execute().CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPost]
        public async Task<IActionResult> Post([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobItemGetOutput>();

            var job = JobItemInsert;

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Обновить элемент.
        /// </summary>
        /// <param name="intput">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPut]
        public async Task<IActionResult> Put([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            var result = new CoreBaseExecutionResultWithData<ModDummyMainBaseJobItemGetOutput>();

            var job = JobItemUpdate;

            try
            {
                result.Data = await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="intputData">Ввод.</param>
        /// <returns>Результат выполнения.</returns>
        [Route("item"), HttpDelete]
        public async Task<IActionResult> Delete(ModDummyMainBaseJobItemGetInput input)
        {
            var result = new CoreBaseExecutionResult();

            var job = JobItemDelete;

            try
            {
                await job.Execute(input).CoreBaseExtTaskWithCurrentCulture(false);

                job.OnSuccess(Logger, result, input);
            }
            catch (Exception ex)
            {
                job.OnError(ex, Logger, result);
            }

            return Ok(result);
        }

        #endregion Public methods
    }
}