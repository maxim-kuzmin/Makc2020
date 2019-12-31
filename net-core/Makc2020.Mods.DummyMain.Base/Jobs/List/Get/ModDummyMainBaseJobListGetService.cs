//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.List.Get
{
    /// <summary>
    /// Мод "DummyMain". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobListGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModDummyMainBaseJobListGetInput,
            ModDummyMainBaseJobListGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyMainBaseJobListGetService(
            Func<ModDummyMainBaseJobListGetInput, Task<ModDummyMainBaseJobListGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModDummyMainBaseJobListGetInput TransformInput(ModDummyMainBaseJobListGetInput input)
        {
            if (input == null)
            {
                input = new ModDummyMainBaseJobListGetInput();
            }

            input.Normalize();

            return input;
        }

        #endregion Private methods
    }
}