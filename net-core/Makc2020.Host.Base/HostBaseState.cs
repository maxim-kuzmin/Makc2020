//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth;
using System.Collections.Generic;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Состояние.
    /// </summary>
    public class HostBaseState
    {
        #region Properties

        /// <summary>
        /// Ключ объекта.
        /// </summary>
        public string ObjectKey { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public HostBasePartAuthUser User { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Заполнить состояние регистратора.
        /// </summary>
        /// <param name="loggerState">Состояние регистратора.</param>
        public virtual void FillLoggerState(List<KeyValuePair<string, object>> loggerState)
        {
            if (!string.IsNullOrWhiteSpace(ObjectKey))
            {
                loggerState.Add(KeyValuePair.Create<string, object>("HostBaseState.ObjectKey", ObjectKey));
            }

            if (User != null && User.Id > 0)
            {
                loggerState.Add(KeyValuePair.Create<string, object>("HostBaseState.UserId", User.Id));
            }
        }

        #endregion Public methods
    }
}
