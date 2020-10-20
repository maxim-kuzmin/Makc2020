//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.Item.Delete
{
    /// <summary>
    /// Мод "DummyMain". Основа. Задания. Элемент. Удаление. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobItemDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyMainBaseJobItemDeleteInput
        >
    {
        #region Properties

        private ModDummyMainBaseResourceSuccesses ResourceSuccesses { get; set; }

        private ModDummyMainBaseResourceErrors ResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        public ModDummyMainBaseJobItemDeleteService(
            Func<ModDummyMainBaseJobItemDeleteInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModDummyMainBaseResourceSuccesses resourceSuccesses,
            ModDummyMainBaseResourceErrors resourceErrors
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

        private IEnumerable<string> GetSuccessMessages(ModDummyMainBaseJobItemDeleteInput input)
        {
            return new[]
            {
                ResourceSuccesses.GetStringIsDeleted(input.DataName)
            };
        }

        private ModDummyMainBaseJobItemDeleteInput TransformInput(ModDummyMainBaseJobItemDeleteInput input)
        {
            if (input == null)
            {
                input = new ModDummyMainBaseJobItemDeleteInput();
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