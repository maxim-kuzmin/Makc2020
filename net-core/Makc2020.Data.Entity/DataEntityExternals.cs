﻿//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data;
using Makc2020.Core.Base.Resources.Errors;
using Makc2020.Data.Base;
using Makc2020.Data.Entity.Db;

namespace Makc2020.Data.Entity
{
    /// <summary>
    /// Данные. Entity Framework. Внешнее.
    /// </summary>
    public class DataEntityExternals
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

        #endregion Properties
    }
}
