//Author Maxim Kuzmin//makc//

using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Данные из базы. Прочитать.
    /// </summary>
    public static class CoreBaseExtDbDataRead
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Логическое значение или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<bool?> CoreBaseExtDbDataReadBooleanNullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (bool?)null
                : await rdr.GetFieldValueAsync<bool>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Целое 32-битное число или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<int?> CoreBaseExtDbDataReadInt32NullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (int?)null
                : await rdr.GetFieldValueAsync<int>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Целое 64-битное число или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<long?> CoreBaseExtDbDataReadInt64NullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (long?)null
                : await rdr.GetFieldValueAsync<long>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Десятичную дробь или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<decimal?> CoreBaseExtDbDataReadDecimalNullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (decimal?)null
                : await rdr.GetFieldValueAsync<decimal>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Дату и время или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<DateTime?> CoreBaseExtDbDataReadDateTimeNullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (DateTime?)null
                : await rdr.GetFieldValueAsync<DateTime>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Дату и время с часовым поясом или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<DateTimeOffset?> CoreBaseExtDbDataReadDateTimeOffsetNullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? (DateTimeOffset?)null
                : await rdr.GetFieldValueAsync<DateTimeOffset>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Данные из базы. Прочитать. Строку или NULL. Асинхронно.
        /// </summary>
        /// <param name="rdr">Считыватель.</param>
        /// <param name="ordinal">Порядковый номер.</param>
        /// <returns>Задача с полученным значением.</returns>
        public static async Task<string> CoreBaseExtDbDataReadStringNullableAsync(
            this DbDataReader rdr,
            int ordinal
            )
        {
            return await rdr.IsDBNullAsync(ordinal).CoreBaseExtTaskWithCurrentCulture(false)
                ? null
                : await rdr.GetFieldValueAsync<string>(ordinal).CoreBaseExtTaskWithCurrentCulture(false);
        }

        #endregion Public methods
    }
}
