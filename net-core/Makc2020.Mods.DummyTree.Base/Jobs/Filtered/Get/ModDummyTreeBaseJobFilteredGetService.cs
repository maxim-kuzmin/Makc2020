//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Filtered.Get
{
    /// <summary>
    /// Мод "DummyTree". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobFilteredGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModDummyTreeBaseJobListGetInput,
            ModDummyTreeBaseJobFilteredGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyTreeBaseJobFilteredGetService(
            Func<ModDummyTreeBaseJobListGetInput, Task<ModDummyTreeBaseJobFilteredGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModDummyTreeBaseJobListGetInput TransformInput(ModDummyTreeBaseJobListGetInput input)
        {
            if (input == null)
            {
                input = new ModDummyTreeBaseJobListGetInput();
            }

            input.Normalize();

            return input;
        }

        #endregion Private methods
    }
}