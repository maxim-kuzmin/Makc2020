//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Обработка. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput,
            ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProcessService(
            Func<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput, Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProcessOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput TransformInput(ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLogoutPostProcessInput();
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