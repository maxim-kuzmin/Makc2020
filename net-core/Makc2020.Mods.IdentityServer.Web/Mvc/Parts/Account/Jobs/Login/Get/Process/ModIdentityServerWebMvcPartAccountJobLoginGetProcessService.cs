//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Login.Get.Process
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Вход в систему. Получение. Обработка. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLoginGetProcessService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput,
            ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLoginGetProcessService(
            Func<ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput, Task<ModIdentityServerWebMvcPartAccountJobLoginGetProcessOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput TransformInput(ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLoginGetProcessInput();
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