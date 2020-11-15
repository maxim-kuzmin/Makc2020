//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Entity.Db;
using Makc2020.Mods.Auth.Base.Resources.Errors;
using Makc2020.Mods.Auth.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.Auth.Base
{
    /// <summary>
    /// Мод "Auth". Основа. Внешнее.
    /// </summary>
    public class ModAuthBaseExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModAuthBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModAuthBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        /// <summary>
        /// Данные. Entity Framework. База данных. Фабрика.
        /// </summary>
        public DataEntityDbFactory DataEntityDbFactory { get; set; }

        #endregion Properties
    }
}
