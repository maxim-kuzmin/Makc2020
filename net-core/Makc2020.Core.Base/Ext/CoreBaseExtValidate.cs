//Author Maxim Kuzmin//makc//

using System;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Валидировать.
    /// </summary>
    public static class CoreBaseExtValidate
    {
        #region Fields

        /// <summary>
        /// Минимальное значение даты в TSQL.
        /// </summary>
        private static readonly DateTime _tqslDateTimeMin = new DateTime(1753, 1, 1);

        #endregion Fields

        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Валидировать. Дату TSQL.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Признак соответствия дате TSQL.</returns>
        public static bool CoreBaseExtValidateTSQLDateTime(this DateTime value)
        {
            return value >= _tqslDateTimeMin;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Валидировать. Дату TSQL или нуль.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Признак соответствия дате TSQL или нулю.</returns>
        public static bool CoreBaseExtValidateTSQLDateTimeNullable(this DateTime? value)
        {
            return !value.HasValue || value.Value.CoreBaseExtValidateTSQLDateTime();
        }

        #endregion Public methods
    }
}
