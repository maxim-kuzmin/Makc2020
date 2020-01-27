//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Ldap.Config;
using Makc2020.Host.Base.Parts.Ldap.Jobs.Login;
using Novell.Directory.Ldap;

namespace Makc2020.Host.Base.Parts.Ldap
{
    /// <summary>
    /// Хост. Основа. Часть "LDAP". Сервис.
    /// </summary>
    public class HostBasePartLdapService
    {
        #region Properties

        private IHostBasePartLdapConfigSettings ConfigSettings { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="configSettings">Конфигурационные настройки.</param>
        public HostBasePartLdapService(IHostBasePartLdapConfigSettings configSettings)
        {
            ConfigSettings = configSettings;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Войти в систему.
        /// </summary>
        /// <param name="input">Ввод.</param>
        /// <returns>Задача с аутентифицированным пользователем.</returns>
        public HostBasePartLdapUser Login(HostBasePartLdapJobLoginInput input)
        {
            HostBasePartLdapUser result = null;

            var hosts = ConfigSettings.Hosts.GetEnumerator();

            string userName = $"{input.UserName}@{ConfigSettings.Domain}";

            while (hosts.MoveNext())
            {
                var host = hosts.Current;

                try
                {
                    using var cn = new LdapConnection
                    {
                        SecureSocketLayer = ConfigSettings.IsSecureSocketLayerEnabled
                    };

                    cn.Connect(host, ConfigSettings.Port);

                    cn.Bind(LdapConnection.LdapV3, userName, input.Password);

                    if (cn.Bound)
                    {
                        result = new HostBasePartLdapUser
                        {
                            UserName = userName
                        };
                    }
                }
                catch (LdapException ex)
                {
                    if (ex.ResultCode != LdapException.ConnectError)
                    {
                        throw;
                    }
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
