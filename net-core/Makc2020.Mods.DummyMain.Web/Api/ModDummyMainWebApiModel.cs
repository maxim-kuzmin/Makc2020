//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Core.Base.Logging;
using Makc2020.Data.Base.Settings;
using Makc2020.Host.Web;
using Makc2020.Host.Web.Api;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Filtered.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Delete;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Filtered.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Delete;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Insert;
using Makc2020.Mods.DummyMain.Caching.Jobs.Item.Update;
using Makc2020.Mods.DummyMain.Caching.Jobs.List.Delete;
using Makc2020.Mods.DummyMain.Caching.Jobs.List.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyManyToMany.Get;
using Makc2020.Mods.DummyMain.Caching.Jobs.Options.DummyOneToMany.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Web.Api
{
    /// <summary>
    /// Мод "DummyMain". Веб. API. Модель.
    /// </summary>
    public class ModDummyMainWebApiModel : HostWebApiModel<HostWebState>
    {
        #region Properties

        private ModDummyMainCachingJobFilteredGetService AppJobFilteredGet { get; set; }

        private ModDummyMainCachingJobItemDeleteService AppJobItemDelete { get; set; }

        private ModDummyMainCachingJobItemGetService AppJobItemGet { get; set; }

        private ModDummyMainCachingJobItemInsertService AppJobItemInsert { get; set; }

        private ModDummyMainCachingJobItemUpdateService AppJobItemUpdate { get; set; }

        private ModDummyMainCachingJobListDeleteService AppJobListDelete { get; set; }

        private ModDummyMainCachingJobListGetService AppJobListGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyManyToManyGetService AppJobOptionsDummyManyToManyGet { get; set; }

        private ModDummyMainCachingJobOptionsDummyOneToManyGetService AppOptionsDummyOneToManyGet { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="appJobFilteredGet">Задание на получение отфильтрованного.</param>
        /// <param name="appJobItemDelete">Задание на удаление элемента.</param>
        /// <param name="appJobItemGet">Задание на получение элемента.</param>
        /// <param name="appJobItemInsert">Задание на вставку элемента.</param>
        /// <param name="appJobItemUpdate">Задание на обновление элемента.</param>
        /// <param name="appJobListGet">Задание на получение списка.</param>
        /// <param name="appJobOptionsDummyManyToManyGet">
        /// Задание на получение вариантов выбора сущности "DummyManyToMany".
        /// </param>
        /// <param name="appJobOptionsDummyOneToManyGet">
        /// Задание на получение вариантов выбора сущности "DummyOneToMany".
        /// </param>
        /// <param name="appLogger">Регистратор.</param>
        public ModDummyMainWebApiModel(
            ModDummyMainCachingJobFilteredGetService appJobFilteredGet,
            ModDummyMainCachingJobItemDeleteService appJobItemDelete,
            ModDummyMainCachingJobItemGetService appJobItemGet,
            ModDummyMainCachingJobItemInsertService appJobItemInsert,
            ModDummyMainCachingJobItemUpdateService appJobItemUpdate,
            ModDummyMainCachingJobListDeleteService appJobListDelete,
            ModDummyMainCachingJobListGetService appJobListGet,
            ModDummyMainCachingJobOptionsDummyManyToManyGetService appJobOptionsDummyManyToManyGet,
            ModDummyMainCachingJobOptionsDummyOneToManyGetService appJobOptionsDummyOneToManyGet,
            CoreBaseLoggingServiceWithCategoryName<ModDummyMainWebApiController> appLogger
            )
            : base(appLogger)
        {
            AppJobFilteredGet = appJobFilteredGet;
            AppJobItemDelete = appJobItemDelete;
            AppJobItemGet = appJobItemGet;
            AppJobItemInsert = appJobItemInsert;
            AppJobItemUpdate = appJobItemUpdate;
            AppJobListDelete = appJobListDelete;
            AppJobListGet = appJobListGet;
            AppJobOptionsDummyManyToManyGet = appJobOptionsDummyManyToManyGet;
            AppOptionsDummyOneToManyGet = appJobOptionsDummyOneToManyGet;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Построить действие "Отфильтрованное. Получение".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task<ModDummyMainBaseJobFilteredGetOutput>> execute,
            Action<ModDummyMainBaseJobFilteredGetResult> onSuccess,
            Action<Exception, ModDummyMainBaseJobFilteredGetResult> onError
            ) BuildActionFilteredGet(ModDummyMainBaseJobListGetInput input)
        {
            var job = AppJobFilteredGet;

            Task<ModDummyMainBaseJobFilteredGetOutput> execute() => job.Execute(input);

            void onSuccess(ModDummyMainBaseJobFilteredGetResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobFilteredGetResult result)
            {
                job.OnError(ex, AppLogger, result);
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
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, CoreBaseExecutionResult result)
            {
                job.OnError(ex, AppLogger, result);
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
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
            {
                job.OnError(ex, AppLogger, result);
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
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
            {
                job.OnError(ex, AppLogger, result);
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
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobItemGetResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Построить действие "Список. Удаление".
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Функции действия.</returns>
        public (
            Func<Task> execute,
            Action<CoreBaseExecutionResult> onSuccess,
            Action<Exception, CoreBaseExecutionResult> onError
            ) BuildActionListDelete(ModDummyMainBaseJobListDeleteInput input)
        {
            var job = AppJobListDelete;

            Task execute() => job.Execute(input);

            void onSuccess(CoreBaseExecutionResult result)
            {
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, CoreBaseExecutionResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

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
                job.OnSuccess(AppLogger, result, input);
            }

            void onError(Exception ex, ModDummyMainBaseJobListGetResult result)
            {
                job.OnError(ex, AppLogger, result);
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
            ) BuildActionOptionsDummyManyToManyGet()
        {
            var job = AppJobOptionsDummyManyToManyGet;

            Task<ModDummyMainBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(AppLogger, result);
            }

            void onError(Exception ex, ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnError(ex, AppLogger, result);
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
            ) BuildActionOptionsDummyOneToManyGet()
        {
            var job = AppOptionsDummyOneToManyGet;

            Task<ModDummyMainBaseCommonJobOptionListGetOutput> execute() => job.Execute();

            void onSuccess(ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnSuccess(AppLogger, result);
            }

            void onError(Exception ex, ModDummyMainBaseCommonJobOptionListGetResult result)
            {
                job.OnError(ex, AppLogger, result);
            }

            return (execute, onSuccess, onError);
        }

        /// <summary>
        /// Создать ключ объекта.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Ключ объекта.</returns>
        public string CreateObjectKey(long id)
        {
            return $"{DataBaseSettingDummyTree.DB_TABLE}-{id}";
        }

        #endregion Public methods    
    }
}