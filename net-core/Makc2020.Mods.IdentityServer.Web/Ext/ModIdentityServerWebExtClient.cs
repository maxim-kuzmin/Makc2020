//Author Maxim Kuzmin//makc//

using IdentityServer4.Stores;
using System.Threading.Tasks;

namespace Makc2020.Mods.IdentityServer.Web.Ext
{
    /// <summary>
    /// Мод "IdentityServer". Веб. Расширение. Клиент.
    /// </summary>
    public static class ModIdentityServerWebExtClient
    {
        #region Public methods

        /// <summary>
        /// Мод "IdentityServer". Веб. Расширение. Клиент. Требует ли PKCE.
        /// </summary>
        /// <param name="store">Хранилище клиентов.</param>
        /// <param name="clientId">Идентификатор клиента.</param>
        /// <returns>Признак того, что клиент требует PKCE.</returns>
        public static async Task<bool> ModIdentityServerWebExtClientIsPkceRequired(this IClientStore store, string clientId)
        {
            if (!string.IsNullOrWhiteSpace(clientId))
            {
                var client = await store.FindEnabledClientByIdAsync(clientId);

                return client?.RequirePkce == true;
            }

            return false;
        }

        #endregion Public methods
    }
}
