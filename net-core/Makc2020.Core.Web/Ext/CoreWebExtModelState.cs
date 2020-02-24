//Author Maxim Kuzmin//makc//

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Makc2020.Core.Base.Execution;

namespace Makc2020.Core.Web.Ext
{
    /// <summary>
    /// Ядро. Веб. Расширение. Состояние модели.
    /// </summary>
    public static class CoreWebExtModelState
    {
        #region Public methods

        /// <summary>
        /// Ядро. Веб. Расширение. Состояние модели. Заполнить.
        /// </summary>
        /// <param name="modelState">Состояние модели.</param>
        /// <param name="execResult">Результат выполнения.</param>
        public static void CoreWebExtModelStateFill(this ModelStateDictionary modelState, CoreBaseExecutionResult execResult)
        {
            foreach (var errorMessage in execResult.ErrorMessages)
            {
                modelState.AddModelError(string.Empty, errorMessage);
            }
        }

        #endregion Public methods
    }
}
