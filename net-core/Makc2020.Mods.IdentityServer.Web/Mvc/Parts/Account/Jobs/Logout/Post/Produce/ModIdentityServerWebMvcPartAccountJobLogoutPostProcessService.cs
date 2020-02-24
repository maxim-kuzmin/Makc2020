//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Mvc.Parts.Account.Jobs.Logout.Post.Produce
{
    /// <summary>
    /// Мод "IdentityServer". Веб. MVC. Часть "Account". Задания. Выход из системы. Отправка. Создание отклика. Сервис.
    /// </summary>
    public class ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput,
            ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput
        >
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public ModIdentityServerWebMvcPartAccountJobLogoutPostProduceService(
            Func<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput, Task<ModIdentityServerWebMvcPartAccountJobLogoutPostProduceOutput>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput TransformInput(ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput input)
        {
            if (input == null)
            {
                input = new ModIdentityServerWebMvcPartAccountJobLogoutPostProduceInput();
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