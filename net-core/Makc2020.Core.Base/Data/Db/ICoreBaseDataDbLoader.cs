//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Data.Db
{
    /// <summary>
    /// Ядро. Основа. Данные. База данных. Загрузчик. Интерфейс.
    /// </summary>
    public interface ICoreBaseDataDbLoader
    {
        #region Methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="ordinal">Порядковый номер, начиная с которого нужно считывать данные.</param>
        /// <param name="props">Загружаемые свойства данных.</param>
        /// <returns>Задача с порядковым номером, начиная с которого нужно считывать следующие данные.</returns>
        Task<int> LoadDataFrom(DbDataReader source, int ordinal, HashSet<string> props = null);

        #endregion Methods
    }
}
