//Author Maxim Kuzmin//makc//

using Makc2020.Apps.Api.Base.App.Common;
using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Makc2020.Apps.Api.Base.App.Parts.Core.Base.Resources.Errors
{
    /// <summary>
    /// Приложение. Часть "Core". Ядро. Основа. Ресурсы. Ошибки. Клиент.
    /// </summary>
    public class AppPartCoreBaseResourceErrorsClient : AppCommonClient
    {
        #region Properties

        private CoreBaseResourceErrors Resource { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="resource">Ресурс.</param>
        public AppPartCoreBaseResourceErrorsClient(
            ILogger<AppPartCoreBaseResourceErrorsClient> logger,
            CoreBaseResourceErrors resource
            ) : base(logger)
        {
            Resource = resource;
        }

        #endregion Constructors

        #region Protected methods

        /// <inheritdoc/>
        protected sealed override void DoRun()
        {
            LogWithCulture("en");
            LogWithCulture("fr");
            LogWithCulture("ru");
        }

        #endregion Protected methods

        #region Private methods

        private void LogWithCulture(string cultureName)
        {
            var ci = CultureInfo.GetCultureInfo(cultureName);

            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;

            var msg = $"{cultureName}: {CreateMessage()}";

            Show(msg);
        }

        private string CreateMessage()
        {
            return string.Join(" @ ", new[]
            {
                Resource.GetStringFormatMessagePartWithUrl(),
                Resource.GetStringFormatMessageWithCode(),
                Resource.GetStringUnknownError()
            });
        }

        #endregion Private methods
    }
}
