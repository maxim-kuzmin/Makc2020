//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Challenge.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания. Вызов. Получение. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobChallengeGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartExternalJobChallengeGetInput,
            ModIdentityServerWebMvcPartExternalJobChallengeGetOutput
        >
    {
        #region Properties

        private ModIdentityServerBaseResourceErrors ResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartExternalJobChallengeGetService(
            Func<ModIdentityServerWebMvcPartExternalJobChallengeGetInput, Task<ModIdentityServerWebMvcPartExternalJobChallengeGetOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModIdentityServerBaseResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceErrors = resourceErrors;

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

            if (ex is ModIdentityServerBaseExceptionInvalidReturnUrl)
            {
                result.Add(ResourceErrors.GetStringReturnUrlIsInvalid());
            }

            return result.Any() ? result : null;
        }

        private ModIdentityServerWebMvcPartExternalJobChallengeGetInput TransformInput(ModIdentityServerWebMvcPartExternalJobChallengeGetInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartExternalJobChallengeGetInput();
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