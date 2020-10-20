//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Common.Jobs.List.Delete;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Errors;
using Makc2020.Mods.DummyMain.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyMain.Base.Jobs.List.Delete
{
    /// <summary>
    /// Мод "DummyMain". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModDummyMainBaseJobListDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyMainBaseJobListDeleteInput
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
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public ModDummyMainBaseJobListDeleteService(
            Func<ModDummyMainBaseJobListDeleteInput, Task> executable,
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

                var errors = new List<string>();

                if (exception.FailedItems.Any())
                {
                    errors.Add(ResourceErrors.GetStringAreFailedToDelete(exception.FailedItems));
                }

                if (exception.RelatedItems.Any())
                {
                    errors.Add(ResourceErrors.GetStringCannotBeDeletedBecauseHaveRelatedData(exception.RelatedItems));
                }

                return errors;
            }

            return GetErrorMessagesOnInvalidInput(ex);
        }

        private IEnumerable<string> GetSuccessMessages(CoreBaseCommonJobListDeleteInput input)
        {
            return new[]
            {
                ResourceSuccesses.GetStringAreDeleted(input.DeletedItems)
            };
        }

        private ModDummyMainBaseJobListDeleteInput TransformInput(ModDummyMainBaseJobListDeleteInput input)
        {
            if (input == null)
            {
                input = new ModDummyMainBaseJobListDeleteInput();
            }

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