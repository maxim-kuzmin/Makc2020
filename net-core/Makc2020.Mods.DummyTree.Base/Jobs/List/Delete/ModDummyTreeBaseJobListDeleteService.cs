﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Exceptions;
using Makc2020.Core.Base.Common.Jobs.List.Delete;
using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.DummyTree.Base.Jobs.List.Delete
{
    /// <summary>
    /// Мод "DummyTree". Задания. Список. Получение. Сервис.
    /// </summary>
    public class ModDummyTreeBaseJobListDeleteService : CoreBaseExecutableServiceAsyncWithInput
        <
            ModDummyTreeBaseJobListDeleteInput
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
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public ModDummyTreeBaseJobListDeleteService(
            Func<ModDummyTreeBaseJobListDeleteInput, Task> executable,
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

        private ModDummyTreeBaseJobListDeleteInput TransformInput(ModDummyTreeBaseJobListDeleteInput input)
        {
            if (input == null)
            {
                input = new ModDummyTreeBaseJobListDeleteInput();
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