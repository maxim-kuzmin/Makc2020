//Author Maxim Kuzmin//makc//

using Makc2020.Mods.IdentityServer.Web.Mvc.Parts.External;

namespace Makc2020.Apps.IdentityServer.Web.Controllers
{
    public class ExternalController : ModIdentityServerWebMvcPartExternalController
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="model">Модель.</param>
        public ExternalController(ModIdentityServerWebMvcPartExternalModel model)
            : base(model)
        {
        }

        #endregion Constructors
    }
}
