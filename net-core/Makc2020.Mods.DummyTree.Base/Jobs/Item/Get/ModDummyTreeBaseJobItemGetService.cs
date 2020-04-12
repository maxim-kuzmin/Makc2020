//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Tree.Item.Get;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Get
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Получение. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobItemGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            CoreBaseCommonJobTreeItemGetInput,
            ModDummyTreeBaseJobItemGetOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModDummyTreeBaseJobItemGetService(
            Func<CoreBaseCommonJobTreeItemGetInput, Task<ModDummyTreeBaseJobItemGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
            Execution.FuncTransformOutput = TransformOutput;
        }

        #endregion Constructors

        #region Private methods

        private CoreBaseCommonJobTreeItemGetInput TransformInput(CoreBaseCommonJobTreeItemGetInput input)
        {
            if (input == null)
            {
                input = new CoreBaseCommonJobTreeItemGetInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        private ModDummyTreeBaseJobItemGetOutput TransformOutput(ModDummyTreeBaseJobItemGetOutput output)
        {
            return output.ObjectDummyTree != null ? output : null;
        }

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            return GetErrorMessagesOnInvalidInput(ex);
        }

        #endregion Private methods
    }
}