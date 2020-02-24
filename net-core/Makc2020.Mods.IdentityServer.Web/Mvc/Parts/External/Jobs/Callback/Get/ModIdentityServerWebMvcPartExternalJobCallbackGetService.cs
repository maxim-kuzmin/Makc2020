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

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External.Jobs.Callback.Get
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "External". Задания. Обратный вызов. Получение. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartExternalJobCallbackGetService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartExternalJobCallbackGetInput,
            ModIdentityServerWebMvcPartExternalJobCallbackGetOutput
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
        public ModIdentityServerWebMvcPartExternalJobCallbackGetService(
            Func<ModIdentityServerWebMvcPartExternalJobCallbackGetInput, Task<ModIdentityServerWebMvcPartExternalJobCallbackGetOutput>> executable,
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

            if (ex is ModIdentityServerBaseExceptionExternalAuthentication)
            {
                result.Add(ResourceErrors.GetStringExternalAuthenticationIsFailed());
            } else if (ex is ModIdentityServerBaseExceptionUnknownUserId)
            {
                result.Add(ResourceErrors.GetStringUnknownUserId());
            }

            return result.Any() ? result : null;
        }

        private ModIdentityServerWebMvcPartExternalJobCallbackGetInput TransformInput(ModIdentityServerWebMvcPartExternalJobCallbackGetInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartExternalJobCallbackGetInput();
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