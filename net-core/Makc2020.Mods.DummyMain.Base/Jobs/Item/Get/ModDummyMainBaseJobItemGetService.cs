//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobItemGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModDummyMainBaseJobItemGetInput,
            ModDummyMainBaseJobItemGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyMainBaseJobItemGetService(
            Func<ModDummyMainBaseJobItemGetInput, Task<ModDummyMainBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
            Execution.FuncTransformOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

        private ModDummyMainBaseJobItemGetInput TransformInput(ModDummyMainBaseJobItemGetInput input)
        {
            if (input == null)
            {
                input = new ModDummyMainBaseJobItemGetInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        private ModDummyMainBaseJobItemGetOutput TransformOutput(ModDummyMainBaseJobItemGetOutput output)
        {
            return output.ObjectDummyMain != null ? output : null;
        }

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            return GetErrorMessagesOnInvalidInput(ex);
        }

        #endregion Private methods
    }
}