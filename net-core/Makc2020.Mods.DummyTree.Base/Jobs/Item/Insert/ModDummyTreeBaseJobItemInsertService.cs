//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Data.Base.Objects;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Insert
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Вставка. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobItemInsertService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModDummyTreeBaseJobItemGetOutput,
            ModDummyTreeBaseJobItemGetOutput
        >
    {
        #region Properties

        /// <summary>
        /// Ресурсы успехов.
        /// </summary>
        protected ModDummyTreeBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Ресурсы ошибок.
        /// </summary>
        protected ModDummyTreeBaseResourceErrors ResourceErrors { get; set; }

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
        public ModDummyTreeBaseJobItemInsertService(
            Func<ModDummyTreeBaseJobItemGetOutput, Task<ModDummyTreeBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors,
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

            var setting = DataBaseSettings.DummyTree;

            if (msg.Contains(setting.DbUniqueIndexForParentIdAndName))
            {
                DataBaseObjectDummyTree obj;

                return new[]
                {
                    string.Format(
                        ResourceErrors.GetStringFormatFieldValueIsNotUnique(),
                        nameof(obj.Name)
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
            ModDummyTreeBaseJobItemGetOutput input,
            ModDummyTreeBaseJobItemGetOutput output
            )
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsInserted(),
                    output.ObjectDummyTree.Id
                    )
            };
        }

        #endregion Protected methods
    }
}