//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Mods.Auth.Base.Settings.Errors;
using Makc2020.Mods.Auth.Base.Settings.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Base.Jobs.Register
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Регистрация. Сервис.
    /// </summary>
    public class ModAuthBaseJobRegisterService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModAuthBaseJobRegisterInput,
            HostBasePartAuthUser
        >
    {
        #region Properties

        private ModAuthBaseResourceErrors ResourceErrors { get; set; }

        private ModAuthBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public ModAuthBaseJobRegisterService(
            Func<ModAuthBaseJobRegisterInput, Task<HostBasePartAuthUser>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModAuthBaseResourceSuccesses resourceSuccesses,
            ModAuthBaseResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;

            Execution.FuncTransformInput = TransformInput;
            Execution.FuncGetSuccessMessages = GetSuccessMessages;
            Execution.FuncGetErrorMessages = GetErrorMessages;
        }

        #endregion Constructors

        #region Private methods

        private ModAuthBaseJobRegisterInput TransformInput(ModAuthBaseJobRegisterInput input)
        {
            if (input == null)
            {
                input = new ModAuthBaseJobRegisterInput();
            }

            var invalidProperties = input.GetInvalidProperties();

            if (invalidProperties.Any())
            {
                throw new CoreExecutionExceptionInvalidInput(invalidProperties);
            }

            return input;
        }

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            var result = new List<string>();

            var errorMessages = GetErrorMessagesOnInvalidInput(ex);

            if (errorMessages != null)
            {
                result.AddRange(errorMessages);
            }

            if (ex is ModAuthBaseJobRegisterException)
            {
                result.Add(ResourceErrors.GetStringUserRegistrationIsFailed());
            }

            return result.Any() ? result : null;
        }

        private IEnumerable<string> GetSuccessMessages(
            ModAuthBaseJobRegisterInput input,
            HostBasePartAuthUser output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringUserIsRegistered()
            };
        }

        #endregion Private methods
    }
}
