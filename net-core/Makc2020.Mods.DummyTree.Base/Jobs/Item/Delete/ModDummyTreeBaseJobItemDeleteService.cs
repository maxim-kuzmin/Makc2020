//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyTree". Основа. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobItemDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyTreeBaseJobItemDeleteInput
        >
    {
        #region Properties

        private ModDummyTreeBaseResourceSuccesses ResourceSuccesses { get; set; }

        private ModDummyTreeBaseResourceErrors ResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        public ModDummyTreeBaseJobItemDeleteService(
            Func<ModDummyTreeBaseJobItemDeleteInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyTreeBaseResourceSuccesses resourceSuccesses,
            ModDummyTreeBaseResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            if (ex.GetType() == typeof(CoreBaseCommonExceptionNonDeleted))
            {
                var exception = (CoreBaseCommonExceptionNonDeleted)ex;

                if (exception.FailedItems != null && exception.FailedItems.Any())
                {
                    return new[]
                    {
                        ResourceErrors.GetStringIsFailedToDelete(exception.FailedItems.First())
                    };
                }
                else if (exception.RelatedItems != null && exception.RelatedItems.Any())
                {
                    return new[]
                    {
                        ResourceErrors.GetStringCannotBeDeletedBecauseHasRelatedData(exception.RelatedItems.First())
                    };
                }
            }

            return GetErrorMessagesOnInvalidInput(ex);
        }

        private IEnumerable<string> GetSuccessMessages(ModDummyTreeBaseJobItemDeleteInput input)
        {
            return new[]
            {
                ResourceSuccesses.GetStringIsDeleted(input.DataName)
            };
        }

        private ModDummyTreeBaseJobItemDeleteInput TransformInput(ModDummyTreeBaseJobItemDeleteInput input)
        {
            if (input == null)
            {
                input = new ModDummyTreeBaseJobItemDeleteInput();
            }

            input.Normalize();

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        #endregion Private methods
    }
}