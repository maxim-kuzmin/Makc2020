//Author Maxim Kuzmin//makc//

using Makc2020.Core.Data.Base;

namespace Makc2020.Data.Base
{
    /// <summary>
    /// Данные. Основа. Настройка.
    /// </summary>
    public class DataBaseSetting : CoreDataBaseSetting<DataBaseDefaults>
    {
        #region Constructors

        /// <inheritdoc/>
        public DataBaseSetting(DataBaseDefaults defaults, string dbTable, string dbSchema = null)
            : base(defaults, dbTable, dbSchema)
        {
        }

        #endregion Constructors
    }
}
