//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base.Parts.Auth;
using Makc2020.Host.Base.Parts.Auth.Ext;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace Makc2020.Root.Apps.Api.Web.Policies.Admin
{
    /// <summary>
    /// Мод "Auth". Веб. Политики. Администратор. Обработчик.
    /// </summary>
    public class ModAuthWebPolicyAdminHandler : AuthorizationHandler<ModAuthWebPolicyAdminRequirement>
    {
        #region Protected methods

        /// <inheritdoc/>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ModAuthWebPolicyAdminRequirement requirement)
        {
            var user = context.User.HostBasePartAuthExtCreateUser();

            if (user != null)
            {
                var isOk = user.Roles.Select(r => r.Name).Contains(HostBasePartAuthSettings.ROLE_Administrator);

                if (isOk)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }

        #endregion Protected methods
    }
}