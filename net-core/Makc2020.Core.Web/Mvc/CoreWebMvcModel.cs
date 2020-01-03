//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Makc2020.Core.Web.Mvc
{
    /// <summary>
    /// Ядро. Веб. MVC. Модель.
    /// </summary>
    public class CoreWebMvcModel : CoreWebModel
    {
        #region Properties

        private ICompositeViewEngine ExtViewEngine { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        /// <param name="extPrincipal">Принципал.</param>
        /// <param name="extViewEngine">Средство создания представлений.</param>
        public CoreWebMvcModel(
            ILogger extLogger,
            IPrincipal extPrincipal,
            ICompositeViewEngine extViewEngine
            ) : base(
                extLogger,
                extPrincipal
                )
        {
            ExtViewEngine = extViewEngine;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Получить частичное представление в виде строки.
        /// </summary>
        /// <param name="viewName">Имя представления.</param>
        /// <param name="model">Модель.</param>
        /// <returns>Строка, содержащее представление.</returns>
        public async Task<string> GetPartialViewAsString(
            string viewName,
            object model,
            ControllerContext controllerContext,
            ViewDataDictionary viewData,
            ITempDataDictionary tempData
            )
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controllerContext.ActionDescriptor.ActionName;
            }

            viewData.Model = model;

            using var writer = new StringWriter();

            var viewResult = ExtViewEngine.FindView(controllerContext, viewName, false);

            var viewContext = new ViewContext(
                controllerContext,
                viewResult.View,
                viewData,
                tempData,
                writer,
                new HtmlHelperOptions()
                );

            await viewResult.View.RenderAsync(viewContext);

            var result = writer.GetStringBuilder().ToString();

            return result;
        }

        #endregion Public methods
    }
}