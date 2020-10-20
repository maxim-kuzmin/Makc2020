//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Sync;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Errors;
using Makc2020.Host.Base.Parts.Ldap.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Makc2020.Host.Base.Parts.Ldap.Jobs.Login
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Задания. Вход в систему. Сервис.
    /// </summary>
    public class HostBasePartLdapJobLoginService : CoreBaseExecutableServiceSyncWithInputAndOutput
        <
            HostBasePartLdapJobLoginInput,
            HostBasePartLdapUser
        >
    {
        #region Properties

        private HostBasePartLdapResourceErrors ResourceErrors { get; set; }
        
        private HostBasePartLdapResourceSuccesses ResourceSuccesses { get; set; }        

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public HostBasePartLdapJobLoginService(
            Func<HostBasePartLdapJobLoginInput, HostBasePartLdapUser> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartLdapResourceSuccesses resourceSuccesses,
            HostBasePartLdapResourceErrors resourceErrors
            ) : base(executable, coreBaseResourceErrors)
        {
            ResourceSuccesses = resourceSuccesses;
            ResourceErrors = resourceErrors;

            Execution.FuncGetSuccessMessages = GetSuccessMessages;
            Execution.FuncGetErrorMessages = GetErrorMessages;
            Execution.FuncTransformInput = TransformInput;
        }

        #endregion Constructors

        #region Private methods

        private IEnumerable<string> GetErrorMessages(Exception ex)
        {
            if (ex is HostBasePartLdapJobLoginException)
            {
                return new[]
                {
                    ResourceErrors.GetStringFailedToLogin()
                };
            }

            return null;
        }

        private IEnumerable<string> GetSuccessMessages(
            HostBasePartLdapJobLoginInput input,
            HostBasePartLdapUser output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringLoginIsSuccessful()
            };
        }

        private HostBasePartLdapJobLoginInput TransformInput(HostBasePartLdapJobLoginInput input)
        {
            if (input == null)
            {
                input = new HostBasePartLdapJobLoginInput();
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
