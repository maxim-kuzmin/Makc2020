//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobItemDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyTreeBaseJobItemGetInput
        >
    {
        #region Properties

        private ModDummyTreeBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        public ModDummyTreeBaseJobItemDeleteService(
            Func<ModDummyTreeBaseJobItemGetInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetSuccessMessages(ModDummyTreeBaseJobItemGetInput input)
        {
            return new[]
            {
                string.Format(
                    ResourceSuccesses.GetStringFormatObjectWithIdIsDeleted(),
                    input.DataId
                    )
            };
        }

        #endregion Private methods
    }
}