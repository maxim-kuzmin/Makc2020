//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Web;
using Makc2020.Mods.DummyTree.Base.Jobs.Calculate;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyTree.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyTree.Caching.Jobs.List.Get;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Web.Api
{
    /// <summary>
    /// Мод "DummyTree". Веб. API. Модель.
    /// </summary>
    public class ModDummyTreeWebApiModel : CoreWebModel
    {
        #region Properties

        private ModDummyTreeBaseJobCalculateService AppJobCalculate { get; set; }

        private ModDummyTreeCachingJobItemDeleteService AppJobItemDelete { get; set; }

        private ModDummyTreeCachingJobItemGetService AppJobItemGet { get; set; }

        private ModDummyTreeCachingJobItemInsertService AppJobItemInsert { get; set; }

        private ModDummyTreeCachingJobItemUpdateService AppJobItemUpdate { get; set; }

        private ModDummyTreeCachingJobListGetService AppJobListGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="appJobCalculate">Задание на вычисление.</param>
        /// <param name="appJobItemDelete">Задание на удаление элемента.</param>
        /// <param name="appJobItemGet">Задание на получение элемента.</param>
        /// <param name="appJobItemInsert">Задание на вставку элемента.</param>
        /// <param name="appJobItemUpdate">Задание на обновление элемента.</param>
        /// <param name="appJobListGet">Задание на получение списка.</param>
        /// <param name="extLogger">Регистратор.</param>
        public ModDummyTreeWebApiModel(
            ModDummyTreeBaseJobCalculateService appJobCalculate,
            ModDummyTreeCachingJobItemDeleteService appJobItemDelete,
            ModDummyTreeCachingJobItemGetService appJobItemGet,
            ModDummyTreeCachingJobItemInsertService appJobItemInsert,
            ModDummyTreeCachingJobItemUpdateService appJobItemUpdate,
            ModDummyTreeCachingJobListGetService appJobListGet,
            ILogger<ModDummyTreeWebApiController> extLogger
            )
            : base(extLogger)
        {
            AppJobCalculate = appJobCalculate;
            AppJobItemDelete = appJobItemDelete;
            AppJobItemGet = appJobItemGet;
            AppJobItemInsert = appJobItemInsert;
            AppJobItemUpdate = appJobItemUpdate;
            AppJobListGet = appJobListGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Вычисление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task> execute,
            Action<CoreBaseExecutionResult> onSuccess,
            Action<Exception, CoreBaseExecutionResult> onError
            ) BuildActionCalculate(ModDummyTreeBaseJobCalculateInput input)
        {
            var job = AppJobCalculate;

            Task execute() => job.Execute(input);

            void onSuccess(CoreBaseExecutionResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, CoreBaseExecutionResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Удаление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task> execute,
            Action<CoreBaseExecutionResult> onSuccess,
            Action<Exception, CoreBaseExecutionResult> onError
            ) BuildActionItemDelete(ModDummyTreeBaseJobItemGetInput input)
        {
            var job = AppJobItemDelete;

            Task execute() => job.Execute(input);

            void onSuccess(CoreBaseExecutionResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, CoreBaseExecutionResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyTreeBaseJobListGetOutput>> execute,
            Action<ModDummyTreeBaseJobListGetResult> onSuccess,
            Action<Exception, ModDummyTreeBaseJobListGetResult> onError
            ) BuildActionListGet(ModDummyTreeBaseJobListGetInput input)
        {
            var job = AppJobListGet;

            Task<ModDummyTreeBaseJobListGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyTreeBaseJobListGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyTreeBaseJobListGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyTreeBaseJobItemGetOutput>> execute,
            Action<ModDummyTreeBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyTreeBaseJobItemGetResult> onError
            ) BuildActionItemGet(ModDummyTreeBaseJobItemGetInput input)
        {
            var job = AppJobItemGet;

            Task<ModDummyTreeBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Вставка".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyTreeBaseJobItemGetOutput>> execute,
            Action<ModDummyTreeBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyTreeBaseJobItemGetResult> onError
            ) BuildActionItemInsert(ModDummyTreeBaseJobItemGetOutput input)
        {
            var job = AppJobItemInsert;

            Task<ModDummyTreeBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Элемент. Обновление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyTreeBaseJobItemGetOutput>> execute,
            Action<ModDummyTreeBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyTreeBaseJobItemGetResult> onError
            ) BuildActionItemUpdate(ModDummyTreeBaseJobItemGetOutput input)
        {
            var job = AppJobItemUpdate;

            Task<ModDummyTreeBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyTreeBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        #endregion Public methods    
    }
}