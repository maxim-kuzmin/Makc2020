//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Data.Db;
using Makc2020.Data.Base.Loaders;
using Makc2020.Data.Base.Objects;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Data.Db.Loaders
{
    /// <summary>
    /// Данные. База данных. Загрузчики. Сущность "DummyOneToMany".
    /// </summary>
    public class DataDbLoaderDummyOneToMany : DataBaseLoaderDummyOneToMany, ICoreBaseDataDbLoader
    {
        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="data">Данные.</param>
        public DataDbLoaderDummyOneToMany(DataBaseObjectDummyOneToMany data = null)
            : base(data ?? new DataBaseObjectDummyOneToMany())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить данные из источника.
        /// </summary>
        /// <param name="source">Источник данных.</param>
        /// <param name="ordinal">Порядковый номер, начиная с которого нужно считывать данные.</param>
        /// <param name="props">Загружаемые свойства.</param>
        /// <returns>Задача с порядковым номером, начиная с которого нужно считывать следующие данные.</returns>
        public Task<int> LoadDataFrom(DbDataReader source, int ordinal, HashSet<string> props = null)
        {
            props = EnsureNotNullValue(props);

            if (props.Contains(nameof(Data.Id)))
            {
                Data.Id = source.GetInt64(ordinal++);
            }

            if (props.Contains(nameof(Data.Name)))
            {
                Data.Name = source.GetString(ordinal++);
            }

            return Task.FromResult(ordinal);
        }

        #endregion Public methods
    }
}