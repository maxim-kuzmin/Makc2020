//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Mod.Auth.Base.Common.Jobs.Login.Jwt;
using Makc2020.Mods.Auth.Base.Settings.Errors;
using Makc2020.Mods.Auth.Base.Settings.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Mods.Auth.Base.Jobs.Refresh.Jwt
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Обновление. JWT. Сервис.
    /// </summary>
    public class ModAuthBaseJobRefreshJwtService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            ModAuthBaseJobRefreshJwtInput,
            ModAuthBaseCommonJobLoginJwtOutput
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
        /// <param name="resourceSuccesses">Ресурсы успехов.</param>
        /// <param name="resourceErrors">Ресурсы ошибок.</param>        
        public ModAuthBaseJobRefreshJwtService(
            Func<ModAuthBaseJobRefreshJwtInput, Task<ModAuthBaseCommonJobLoginJwtOutput>> executable,
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

        private ModAuthBaseJobRefreshJwtInput TransformInput(ModAuthBaseJobRefreshJwtInput input)
        {
            if (input == null)
            {
                input = new ModAuthBaseJobRefreshJwtInput();
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

            if (ex is ModAuthBaseJobRefreshJwtException)
            {
                result.Add(ResourceErrors.GetStringTokenRefreshIsFailed());
            }

            return result.Any() ? result : null;
        }

        private IEnumerable<string> GetSuccessMessages(
            ModAuthBaseJobRefreshJwtInput input,
            ModAuthBaseCommonJobLoginJwtOutput output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringTokenIsRefreshed()
            };
        }

        #endregion Private methods
    }
}
