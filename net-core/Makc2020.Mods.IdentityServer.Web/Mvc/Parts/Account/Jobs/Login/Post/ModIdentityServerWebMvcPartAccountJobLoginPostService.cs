//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLoginPostInput,
            ModIdentityServerWebMvcPartAccountCommonJobLoginOutput
        >
    {
        #region Properties

        private ModIdentityServerBaseResourceErrors ResourceErrors { get; set; }

        private ModIdentityServerBaseResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLoginPostService(
            Func<ModIdentityServerWebMvcPartAccountJobLoginPostInput, Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            ModIdentityServerBaseResourceSuccesses resourceSuccesses,
            ModIdentityServerBaseResourceErrors resourceErrors
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

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            var result = new List<string>();

            var errorMessages = GetErrorMessagesOnInvalidInput(ex);

            if (errorMessages != null)
            {
                result.AddRange(errorMessages);
            }

            if (ex is ModIdentityServerBaseExceptionLogin)
            {
                result.Add(ResourceErrors.GetStringUserLoginIsFailed());
            } else if (ex is ModIdentityServerBaseExceptionInvalidReturnUrl)
            {
                result.Add(ResourceErrors.GetStringReturnUrlIsInvalid());
            }

            return result.Any() ? result : null;
        }

        private IEnumerable<string> GetSuccessMessages(
            ModIdentityServerWebMvcPartAccountJobLoginPostInput input,
            ModIdentityServerWebMvcPartAccountCommonJobLoginOutput output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringLoginIsSuccessful()
            };
        }

        private ModIdentityServerWebMvcPartAccountJobLoginPostInput TransformInput(ModIdentityServerWebMvcPartAccountJobLoginPostInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLoginPostInput();
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