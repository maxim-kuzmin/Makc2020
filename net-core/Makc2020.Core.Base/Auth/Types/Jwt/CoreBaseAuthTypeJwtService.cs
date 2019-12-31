//Author Maxim Kuzmin//makc//

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Makc2020.Core.Base.Auth.Types.Jwt
{
    /// <summary>
    /// Ядро. Основа. Аутентификация. Типы. JWT. Сервис.
    /// </summary>
    public class CoreBaseAuthTypeJwtService : ICoreBaseAuthTypeJwtService
    {
        #region Properties

        private ICoreBaseAuthTypeJwtSettings Settings { get; set; }

        private SigningCredentials SigningCredentials { get; set; }

        private Dictionary<string, string> LookupOfUserIdByRefreshTokenValue { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="settings">Настройки.</param>
        public CoreBaseAuthTypeJwtService(ICoreBaseAuthTypeJwtSettings settings)
        {
            Settings = settings;

            if (Settings == null) throw new ArgumentNullException(nameof(settings));

            if (Settings.SigningKey == null)
            {
                throw new ArgumentNullException(nameof(ICoreBaseAuthTypeJwtSettings.SigningKey));
            }

            SigningCredentials = new SigningCredentials(Settings.SigningKey, SecurityAlgorithms.HmacSha256);

            LookupOfUserIdByRefreshTokenValue = new Dictionary<string, string>();
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string CreateAccessToken(string userId, IEnumerable<Claim> userClaims)
        {
            var token = CreateJwtSecurityToken(userId, userClaims);

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        /// <inheritdoc/>
        public string CreateRefreshToken(string userId)
        {
            var token = CreateJwtSecurityToken(userId, null);

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            LookupOfUserIdByRefreshTokenValue[result] = userId;

            return result;
        }

        /// <inheritdoc/>
        public string GetUserIdByRefreshToken(string token)
        {
            LookupOfUserIdByRefreshTokenValue.TryGetValue(token, out string result);

            return result;
        }

        /// <inheritdoc/>
        public void RemoveRefreshToken(string token)
        {
            LookupOfUserIdByRefreshTokenValue.Remove(token);
        }

        #endregion Public methods

        #region Private methods

        private JwtSecurityToken CreateJwtSecurityToken(string userId, IEnumerable<Claim> userClaims)
        {
            var now = DateTime.UtcNow;

            var claims = new List<Claim>()
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userId),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };

            if (userClaims != null && userClaims.Any())
            {
                claims.AddRange(userClaims);
            }

            var expiresAt = now.AddDays(Settings.TimeToLiveInDaysOfRefreshToken);

            return new JwtSecurityToken(
                issuer: Settings.Issuer,
                audience: Settings.Audience,
                claims: claims,
                notBefore: now,
                expires: expiresAt,
                signingCredentials: SigningCredentials
                );
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            var period = date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

            return (long)Math.Round(period.TotalSeconds);
        }

        #endregion Private methods
    }
}
