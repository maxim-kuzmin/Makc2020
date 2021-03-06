﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Common.Jobs.Login;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Post.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Отправка. Создание отклика. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginPostProduceService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput,
            ModIdentityServerWebMvcPartAccountCommonJobLoginOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLoginPostProduceService(
            Func<ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput, Task<ModIdentityServerWebMvcPartAccountCommonJobLoginOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput TransformInput(ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLoginPostProduceInput();
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