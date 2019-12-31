//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Makc2020.Apps.Api.Base.App.Samples.Core.Base.Resources
{
    /// <summary>
    /// Приложение. Примеры. Ядро. Основа. Ресурсы. Ошибки.
    /// </summary>
    public class AppSampleCoreBaseResourceErrors : AppSample
    {
        #region Properties

        private CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="logger">Регистратор.</param>
        /// <param name="coreBaseResourceErrors">Ядро. Основа. Ресурсы. Ошибки.</param>
        public AppSampleCoreBaseResourceErrors(
            ILogger<AppSampleCoreBaseResourceErrors> logger,
            CoreBaseResourceErrors coreBaseResourceErrors
            ) : base(logger)
        {
            CoreBaseResourceErrors = coreBaseResourceErrors;
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

            Log(msg);
        }

        private string CreateMessage()
        {
            return string.Join(" @ ", new[]
            {
                CoreBaseResourceErrors.GetStringFormatMessagePartWithUrl(),
                CoreBaseResourceErrors.GetStringFormatMessageWithCode(),
                CoreBaseResourceErrors.GetStringUnknownError()
            });
        }

        #endregion Private methods
    }
}
