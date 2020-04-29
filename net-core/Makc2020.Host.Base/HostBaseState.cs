//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth;

namespace Makc2020.Host.Base
{
    /// <summary>
    /// Хост. Основа. Состояние.
    /// </summary>
    public class HostBaseState
    {
        #region Properties

        /// <summary>
        /// Пользователь.
        /// </summary>
        public HostBasePartAuthUser User { get; set; }

        #endregion Properties
    }
}
