﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Exceptions;
using Makc2020.Mods.IdentityServer.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Base.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Обработка. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostProcessService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput,
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput
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
        public ModIdentityServerWebMvcPartAccountJobLoginPostProcessService(
            Func<ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput, Task<ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput>> executable,
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
            }
            else if (ex is ModIdentityServerBaseExceptionDomainUserNotFound exDomainUserNotFound)
            {
                result.Add(ResourceErrors.GetStringDomainUserNotFound(exDomainUserNotFound.UserName));
            }
            else if (ex is ModIdentityServerBaseExceptionDomainUserGroupsNotFound exDomainUserGroupsNotFound)
            {
                result.Add(ResourceErrors.GetStringDomainUserGroupsNotFound(exDomainUserGroupsNotFound.UserName));
            }
            else if (ex is ModIdentityServerBaseExceptionInvalidReturnUrl)
            {
                result.Add(ResourceErrors.GetStringReturnUrlIsInvalid());
            }
            else if (ex is ModIdentityServerBaseExceptionLdapGroupsSearchFailed)
            {
                result.Add(ResourceErrors.GetStringLdapGroupsSearchFailed(ex.Message));
            }
            else if (ex is ModIdentityServerBaseExceptionLdapLoginFailed)
            {
                result.Add(ResourceErrors.GetStringLdapLoginFailed());
            }
            else if (ex is ModIdentityServerBaseExceptionLdapUserHasNotGroups)
            {
                result.Add(ResourceErrors.GetStringLdapUserHasNoGroups());
            }
            else if (ex is ModIdentityServerBaseExceptionUserHasNotRoles)
            {
                result.Add(ResourceErrors.GetStringUserHasNoRoles());
            }

            return result.Any() ? result : null;
        }

        private IEnumerable<string> GetSuccessMessages(
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput input,
            ModIdentityServerWebMvcPartAccountJobLoginPostProcessOutput output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringLoginIsSuccessful()
            };
        }

        private ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput TransformInput(ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLoginPostProcessInput();
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