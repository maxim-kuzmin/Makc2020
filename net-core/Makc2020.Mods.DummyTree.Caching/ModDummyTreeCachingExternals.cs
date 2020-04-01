//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Core.Caching;
using Makc2020.Core.Caching.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Mods.DummyTree.Base;
using Makc2020.Mods.DummyTree.Base.Resources.Errors;
using Makc2020.Mods.DummyTree.Base.Resources.Successes;

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Внешнее.
    /// </summary>
    public class ModDummyTreeCachingExternals
    {
        #region Properties

        /// <summary>
        /// Кэш.
        /// </summary>
        public ICoreCachingCache Cache { get; set; }

        /// <summary>
        /// Ядро. Основа. Ресурсы. Ошибки.
        /// </summary>
        public CoreBaseResourceErrors CoreBaseResourceErrors { get; set; }

        /// <summary>
        /// Ядро. Кэширование. Ресурсы. Ошибки.
        /// </summary>
        public CoreCachingResourceErrors CoreCachingResourceErrors { get; set; }

        /// <summary>
        /// Данные. Основа. Настройки.
        /// </summary>
        public DataBaseSettings DataBaseSettings { get; set; }

        /// <summary>
        /// Ресурс ошибок.
        /// </summary>
        public ModDummyTreeBaseResourceErrors ResourceErrors { get; set; }

        /// <summary>
        /// Ресурс успехов.
        /// </summary>
        public ModDummyTreeBaseResourceSuccesses ResourceSuccesses { get; set; }

        /// <summary>
        /// Сервис.
        /// </summary>
        public ModDummyTreeBaseService Service { get; set; }

        #endregion Properties
    }
}
