//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Db;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;
using Microsoft.Extensions.Localization;

namespace Makc2020.Mods.DummyTree.Base
{
    /// <summary>
    /// Мод "DummyTree". Основа. Внешнее.
    /// </summary>
    public class ModDummyTreeBaseExternals
    {
        #region Properties

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ядро. Основа. Данные. Поставщик.
        /// </summary>
        public ICoreBaseDataProvider CoreBaseDataProvider { get; set; }

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Данные. Entity Framework. База данных. Фабрика.
        /// </summary>
        public DataEntityDbFactory DataEntityDbFactory { get; set; }

        /// <summary>
        /// Локализатор ресурса ошибок.
        /// </summary>
        public IStringLocalizer<ModDummyTreeBaseResourceErrors> ResourceErrorsLocalizer { get; set; }

        /// <summary>
        /// Локализатор ресурса успехов.
        /// </summary>
        public IStringLocalizer<ModDummyTreeBaseResourceSuccesses> ResourceSuccessesLocalizer { get; set; }

        #endregion Properties
    }
}
