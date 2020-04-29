//Author Maxim Kuzmin//makc//

using Makc2020.Host.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Makc2020.Host.Web.Mvc
{
    /// <summary>
    /// Хост. Веб. MVC. Модель.
    /// </summary>
    /// <typeparam name="TState">Тип состояния.</typeparam>
    public class HostWebMvcModel<TState> : HostBaseModel<TState>
        where TState : HostWebState
    {
        #region Properties

        private ICompositeViewEngine ExtViewEngine { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="extLogger">Регистратор.</param>
        /// <param name="extViewEngine">Средство создания представлений.</param>
        public HostWebMvcModel(ILogger extLogger, ICompositeViewEngine extViewEngine) 
            : base(extLogger)
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