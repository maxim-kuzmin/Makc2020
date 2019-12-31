//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Item.Insert
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Вставка. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobItemInsertService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModDummyMainBaseJobItemGetOutput,
            ModDummyMainBaseJobItemGetOutput
        >
    {
        #region Properties

        /// <summary>
        /// Ресурсы успехов.
        /// </summary>
        protected ModDummyMainBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Ресурсы ошибок.
        /// </summary>
        protected ModDummyMainBaseResourceErrors ResourceErrors { get; set; }

        /// <summary>
        /// Настройки основы данных.
        /// </summary>
        protected DataBaseSettings DataBaseSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>
        /// <param name="dataBaseSettings">Настройки основы данных.</param>
        public ModDummyMainBaseJobItemInsertService(
            Func<ModDummyMainBaseJobItemGetOutput, Task<ModDummyMainBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors,
            DataBaseSettings dataBaseSettings
            ) : base(executable,  coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;
            DataBaseSettings = dataBaseSettings;

            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncGetSuccessMessages = GetSuccessMessages;
        }

        #endregion Constructors

        #region Protected methods

        /// <summary>
        /// Получить сообщения об ошибках.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <returns>Сообщения.</returns>
        protected virtual IEnumerable<string> GetErrorMessages(Exception ex)
        {
            var msg = ex.ToString();

            var setting = DataBaseSettings.DummyMain;

            if (msg.Contains(setting.DbUniqueIndexForName))
            {
                return new[]
                {
                    string.Format(
                        ResourceErrors.GetStringFormatFieldValueIsNotUnique(), 
                        "Name"
                        )
                };
            }

            return null;
        }

        /// <summary>
        /// Получить сообщения об успехах.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <param name="output">Вывод.</param>
        /// <returns>Сообщения.</returns>
        protected virtual IEnumerable<string> GetSuccessMessages(
            ModDummyMainBaseJobItemGetOutput input,
            ModDummyMainBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsInserted(),
                    output.ObjectDummyMain.Id
                    )
            };
        }

        #endregion Protected methods
    }
}