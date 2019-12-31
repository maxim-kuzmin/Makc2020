//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Auth.Types.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Makc2020.Mods.Auth.Base.Config.Settings.Types
{
    /// <summary>
    /// Мод "Auth". Основа. Конфигурация. Настройки. Типы. JWT.
    /// </summary>
    public class ModAuthBaseConfigSettingTypeJwt : ICoreBaseAuthTypeJwtSettings
    {
        #region Properties

        /// <inheritdoc/>
        public string Issuer { get; set; }

        /// <inheritdoc/>
        public string Audience { get; set; }

        /// <inheritdoc/>
        public string SecretKey { get; set; }

        /// <inheritdoc/>
        public int TimeToLiveInMinutesOfAccessToken { get; set; }

        /// <inheritdoc/>
        public int TimeToLiveInDaysOfRefreshToken { get; set; }

        /// <inheritdoc/>
        public SymmetricSecurityKey SigningKey { get; private set; }

        #endregion Properties

        #region Internal methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        internal void Init()
        {
            SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }

        #endregion Internal methods
    }
}