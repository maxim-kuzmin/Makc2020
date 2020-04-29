﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Host.Web;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Контроллер.
    /// </summary>
    [ApiController, Route("api/dummy-main")]
    public class ModDummyMainWebApiController : ControllerBase
    {
        #region Properties

        private ModDummyMainWebApiModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModDummyMainWebApiController(ModDummyMainWebApiModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="intputData">Ввод.</param>
        /// <returns>Результат выполнения.</returns>
        [Route("item"), HttpDelete]
        public async Task<IActionResult> DeleteItem([FromQuery] ModDummyMainBaseJobItemGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new CoreBaseExecutionResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemDelete(input);

            try
            {
                await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("list"), HttpGet]
        public async Task<IActionResult> GetList([FromQuery] ModDummyMainBaseJobListGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseJobListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionListGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpGet]
        public async Task<IActionResult> GetItem([FromQuery] ModDummyMainBaseJobItemGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemGet(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
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
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseCommonJobOptionListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionOptionDummyManyToManyListGet();

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
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
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseCommonJobOptionListGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionOptionDummyOneToManyListGet();

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPost]
        public async Task<IActionResult> InsertItem([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemInsert(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        /// <summary>
        /// Обновить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] ModDummyMainBaseJobItemGetOutput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyMainBaseJobItemGetResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionItemUpdate(input);

            try
            {
                result.Data = await execute().CoreBaseExtTaskWithCurrentCulture(false);

                onSuccess(result);
            }
            catch (Exception ex)
            {
                onError(ex, result);
            }

            return Ok(result);
        }

        #endregion Public methods
    }
}