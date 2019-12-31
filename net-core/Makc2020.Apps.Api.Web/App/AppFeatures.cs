//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Root.Apps.Api.Web;
using System.Collections.Generic;

namespace Makc2020.Apps.Api.Web.App
{
    /// <summary>
    /// Приложение. Функциональности.
    /// </summary>    
    public class AppFeatures : RootAppApiWebFeatures
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="commonFeatures">Обобщённые функциональности.</param>
        public AppFeatures(IEnumerable<ICoreBaseCommonFeature> commonFeatures)
            : base(commonFeatures)
        {
        }

        #endregion Constructors
    }
}
