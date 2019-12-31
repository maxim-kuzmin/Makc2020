//Author Maxim Kuzmin//makc//

using System.Collections.Generic;
using System.Data;

namespace Makc2020.Data.Db.Ext
{
    /// <summary>
    /// Данные. База данных. Расширение. Преобразовать.
    /// </summary>
    public static class DataDbExtConvert
    {
        #region Public methods

        /// <summary>
        /// Данные. База данных. Расширение. Преобразовать. В табличный тип списка идентификаторов
        /// [core].[TableType_IdList].
        /// </summary>
        /// <param name="ids">Идентификаторы.</param>
        /// <returns>Табличный тип списка идентификаторов.</returns>
        public static DataTable DataCommonExtConvertToCoreTableTypeIdList(this IEnumerable<long> ids)
        {
            var result = new DataTable("[core].[TableType_IdList]");

            result.Columns.Add("Val", typeof(long));

            foreach (var value in ids)
            {
                var row = result.NewRow();

                row[result.Columns[0].ColumnName] = value;

                result.Rows.Add(row);
            }

            return result;
        }

        #endregion Public methods
    }
}
