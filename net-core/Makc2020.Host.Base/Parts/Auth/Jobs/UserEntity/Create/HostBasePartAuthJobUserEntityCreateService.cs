﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Executable.Services.Async;
using Makc2020.Core.Base.Execution.Exceptions;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Entity.Objects;
using Makc2020.Host.Base.Parts.Auth.Resources.Errors;
using Makc2020.Host.Base.Parts.Auth.Resources.Successes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Host.Base.Parts.Auth.Jobs.UserEntity.Create
{
    /// <summary>
    /// Хост. Основа. Часть "Auth". Задания. Сущность пользователя. Создание. Сервис.
    /// </summary>
    public class HostBasePartAuthJobUserEntityCreateService : CoreBaseExecutableServiceAsyncWithInputAndOutput
        <
            HostBasePartAuthJobUserEntityCreateInput,
            DataEntityObjectUser
        >
    {
        #region Properties

        private HostBasePartAuthResourceErrors ResourceErrors { get; set; }

        private HostBasePartAuthResourceSuccesses ResourceSuccesses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="executable">Выполняемое.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        /// <param name="resourceSuccesses">Ресурсы. Успехи.</param>
        /// <param name="resourceErrors">Ресурсы. Ошибки.</param>
        public HostBasePartAuthJobUserEntityCreateService(
            Func<HostBasePartAuthJobUserEntityCreateInput, Task<DataEntityObjectUser>> executable,
            CoreBaseResourceErrors coreBaseResourceErrors,
            HostBasePartAuthResourceSuccesses resourceSuccesses,
            HostBasePartAuthResourceErrors resourceErrors
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
            if (ex is HostBasePartAuthJobUserEntityCreateException)
            {
                return new[]
                {
                    ResourceErrors.GetStringFailedToCreateUser()
                };
            }

            return null;
        }

        private IEnumerable<string> GetSuccessMessages(
            HostBasePartAuthJobUserEntityCreateInput input,
            DataEntityObjectUser output
            )
        {
            return new[]
            {
                ResourceSuccesses.GetStringCurrentUserIsCreated()
            };
        }

        private HostBasePartAuthJobUserEntityCreateInput TransformInput(HostBasePartAuthJobUserEntityCreateInput input)
        {
            if (input == null)
            {
                input = new HostBasePartAuthJobUserEntityCreateInput();
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
