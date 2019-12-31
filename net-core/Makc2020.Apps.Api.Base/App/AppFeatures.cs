//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common;
using Makc2020.Root.Apps.Api.Base;
using System.Collections.Generic;

namespace Makc2020.Apps.Api.Base.App
{
    /// <summary>
    /// Приложение. Функциональности.
    /// </summary>    
    public class AppFeatures : RootAppApiBaseFeatures
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
