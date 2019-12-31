//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Makc2020.Core.Base.Auth.Types.Oidc;

namespace Makc2020.Mods.Auth.Base.Config.Settings
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Типы. Интерфейс.
    /// </summary>
    public interface IModAuthBaseConfigSettingTypes
    {
        #region Properties

        /// <summary>
        /// JWT.
        /// </summary>
        ICoreBaseAuthTypeJwtSettings Jwt { get; }

        /// <summary>
        /// OIDC.
        /// </summary>
        ICoreBaseAuthTypeOidcSettings Oidc { get; }

        #endregion Properties
    }
}