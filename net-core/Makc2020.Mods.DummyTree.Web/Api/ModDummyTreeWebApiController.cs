//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Item.Get.Item;
using Makc2020.Core.Base.Common.Jobs.Tree.Item.Get;
using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Ext;
using Makc2020.Host.Web;
using Makc2020.Mods.DummyTree.Base.Jobs.Calculate;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Web.Api
{
    /// <summary>
    /// Мод "DummyTree". Веб. API. Контроллер.
    /// </summary>
    [ApiController, Route("api/dummy-tree")]
    public class ModDummyTreeWebApiController : ControllerBase
    {
        #region Properties

        private ModDummyTreeWebApiModel MyModel { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ModDummyTreeWebApiController(ModDummyTreeWebApiModel model)
        {
            MyModel = model;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Вычислить.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения.</returns>
        [Route("calculate"), HttpPut]
        public async Task<IActionResult> Calculate([FromBody] ModDummyTreeBaseJobCalculateInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new CoreBaseExecutionResult();

            var (execute, onSuccess, onError) = MyModel.BuildActionCalculate(input);

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
        /// Удалить элемент.
        /// </summary>
        /// <param name="intputData">Ввод.</param>
        /// <returns>Результат выполнения.</returns>
        [Route("item"), HttpDelete]
        public async Task<IActionResult> DeleteItem([FromQuery] CoreBaseCommonJobItemGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext, MyModel.CreateObjectKey(input.DataId)));

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
        /// Получить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpGet]
        public async Task<IActionResult> GetItem([FromQuery] CoreBaseCommonJobTreeItemGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext, MyModel.CreateObjectKey(input.RootId)));

            var result = new ModDummyTreeBaseJobItemGetResult();

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
        /// Получить список.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными списка.</returns>
        [Route("list"), HttpGet]
        public async Task<IActionResult> GetList([FromQuery] ModDummyTreeBaseJobListGetInput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyTreeBaseJobListGetResult();

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
        /// Добавить элемент.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Результат выполнения с данными элемента.</returns>
        [Route("item"), HttpPost]
        public async Task<IActionResult> InsertItem([FromBody] ModDummyTreeBaseJobItemGetOutput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext));

            var result = new ModDummyTreeBaseJobItemGetResult();

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
        public async Task<IActionResult> UpdateItem([FromBody] ModDummyTreeBaseJobItemGetOutput input)
        {
            MyModel.Init(HostWebState.Create(HttpContext, MyModel.CreateObjectKey(input.ObjectDummyTree.Id)));

            var result = new ModDummyTreeBaseJobItemGetResult();

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