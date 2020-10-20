//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.Seed
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Посев. Сервис.
    /// </summary>
    public class HostBasePartAuthJobSeedService : CoreBaseExecutableServiceAsyncWithInput
        <
            HostBasePartAuthJobSeedInput
        >
    {
        #region Properties

        private HostBasePartAuthResourceErrors ResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>     
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public HostBasePartAuthJobSeedService(
            Func<HostBasePartAuthJobSeedInput, Task> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartAuthResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceErrors = resourceErrors;

            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            var result = new List<string>();

            var errorMessages = GetErrorMessagesOnInvalidInput(ex);

            if (errorMessages != null)
            {
                result.AddRange(errorMessages);
            }

            if (ex is HostBasePartAuthJobSeedException)
            {
                result.Add(ResourceErrors.GetStringUserSeedIsFailed());
            }

            return result.Any() ? result : null;
        }

        private HostBasePartAuthJobSeedInput TransformInput(HostBasePartAuthJobSeedInput input)
        {
            if (input == null)
            {
                input = new HostBasePartAuthJobSeedInput();
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
