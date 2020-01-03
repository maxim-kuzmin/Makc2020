//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Web;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyMain.Caching.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyManyToMany.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Модель.
    /// </summary>
    public class ModDummyMainWebApiModel : CoreWebModel
    {
        #region Properties

        private ModDummyMainCachingJobItemDeleteService AppJobItemDelete { get; set; }

        private ModDummyMainCachingJobItemGetService AppJobItemGet { get; set; }

        private ModDummyMainCachingJobItemInsertService AppJobItemInsert { get; set; }

        private ModDummyMainCachingJobItemUpdateService AppJobItemUpdate { get; set; }

        private ModDummyMainCachingJobListGetService AppJobListGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyManyToManyGetService AppJobOptionDummyManyToManyListGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyOneToManyGetService AppJobOptionDummyOneToManyListGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appJobItemDelete">Задание на удаление элемента.</param>
        /// <param name="appJobItemGet">Задание на получение элемента.</param>
        /// <param name="appJobItemInsert">Задание на вставку элемента.</param>
        /// <param name="appJobItemUpdate">Задание на обновление элемента.</param>
        /// <param name="appJobListGet">Задание на получение списка.</param>
        /// <param name="appJobOptionDummyManyToManyListGet">
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </param>
        /// <param name="appJobOptionDummyOneToManyListGet">
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </param>
        /// <param name="extLogger">Регистратор.</param>
        public ModDummyMainWebApiModel(
            ModDummyMainCachingJobItemDeleteService appJobItemDelete,
            ModDummyMainCachingJobItemGetService appJobItemGet,
            ModDummyMainCachingJobItemInsertService appJobItemInsert,
            ModDummyMainCachingJobItemUpdateService appJobItemUpdate,
            ModDummyMainCachingJobListGetService appJobListGet,
            ModDummyMainCachingJobOptionsDummyManyToManyGetService appJobOptionDummyManyToManyListGet,
            ModDummyMainCachingJobOptionsDummyOneToManyGetService appJobOptionDummyOneToManyListGet,
            ILogger<ModDummyMainWebApiController> extLogger
            )
            : base(extLogger)
        {
            AppJobItemDelete = appJobItemDelete;
            AppJobItemGet = appJobItemGet;
            AppJobItemInsert = appJobItemInsert;
            AppJobItemUpdate = appJobItemUpdate;
            AppJobListGet = appJobListGet;
            AppJobOptionDummyManyToManyListGet = appJobOptionDummyManyToManyListGet;
            AppJobOptionDummyOneToManyListGet = appJobOptionDummyOneToManyListGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyMainBaseJobListGetOutput>> execute,
            Action<ModDummyMainBaseJobListGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseJobListGetResult> onError
            ) BuildActionListGet(ModDummyMainBaseJobListGetInput input)
        {
            var job = AppJobListGet;

            Task<ModDummyMainBaseJobListGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyMainBaseJobListGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobListGetResult result)
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
            Func<Task<ModDummyMainBaseJobItemGetOutput>> execute,
            Action<ModDummyMainBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseJobItemGetResult> onError
            ) BuildActionItemGet(ModDummyMainBaseJobItemGetInput input)
        {
            var job = AppJobItemGet;

            Task<ModDummyMainBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyMainBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вариант выбора. Сущность "DummyManyToMany". Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyMainBaseCommonJobOptionListGetOutput>> execute,
            Action<ModDummyMainBaseCommonJobOptionListGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseCommonJobOptionListGetResult> onError
            ) BuildActionOptionDummyManyToManyListGet()
        {
            var job = AppJobOptionDummyManyToManyListGet;

            Task<ModDummyMainBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(ExtLogger, result);
            }

            void onError(Exception ex, ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnError(ex, ExtLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Вариант выбора. Сущность "DummyOneToMany". Список. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyMainBaseCommonJobOptionListGetOutput>> execute,
            Action<ModDummyMainBaseCommonJobOptionListGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseCommonJobOptionListGetResult> onError
            ) BuildActionOptionDummyOneToManyListGet()
        {
            var job = AppJobOptionDummyOneToManyListGet;

            Task<ModDummyMainBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(ExtLogger, result);
            }

            void onError(Exception ex, ModDummyMainBaseCommonJobOptionListGetResult result)
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
            Func<Task<ModDummyMainBaseJobItemGetOutput>> execute,
            Action<ModDummyMainBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseJobItemGetResult> onError
            ) BuildActionItemInsert(ModDummyMainBaseJobItemGetOutput input)
        {
            var job = AppJobItemInsert;

            Task<ModDummyMainBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyMainBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
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
            Func<Task<ModDummyMainBaseJobItemGetOutput>> execute,
            Action<ModDummyMainBaseJobItemGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseJobItemGetResult> onError
            ) BuildActionItemUpdate(ModDummyMainBaseJobItemGetOutput input)
        {
            var job = AppJobItemUpdate;

            Task<ModDummyMainBaseJobItemGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyMainBaseJobItemGetResult result)
            {
                job.OnSuccess(ExtLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
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
            ) BuildActionItemDelete(ModDummyMainBaseJobItemGetInput input)
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

        #endregion Public methods    
    }
}