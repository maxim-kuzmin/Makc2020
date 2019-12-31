//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Resources.Converting;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Преобразовать.
    /// </summary>
    public static class CoreBaseExtConvert
    {
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из даты и времени в строку в формате ISO8601.
        /// </summary>
        /// <param name="value">Дата и время.</param>
        /// <returns>Строковое представление даты и времени в формате ISO8601.</returns>
        public static string CoreBaseExtConvertFromDateTimeToISO8601String(this DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss.FFF");
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из даты и времени в строку в формате двусторонней передачи.
        /// </summary>
        /// <param name="value">Дата и время.</param>
        /// <returns>Строковое представление даты и времени в формате двусторонней передачи.</returns>
        public static string CoreBaseExtConvertFromDateTimeToRoundTripString(this DateTime value)
        {
            return value.ToString("o");
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из даты и времени с часовым поясом в строку в формате двусторонней передачи.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Строковое представление даты и времени с часовым поясом в формате двусторонней передачи.</returns>
        public static string CoreBaseExtConvertFromDateTimeOffsetToRoundTripString(
            this DateTimeOffset value
            )
        {
            return value.ToString("o");
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из строки в формате двусторонней передачи в дату и время с часовым поясом.
        /// </summary>
        /// <param name="value">Строка в формате двусторонней передачи.</param>
        /// <returns>Дата и время с часовым поясом.</returns>
        public static DateTimeOffset CoreBaseExtConvertFromRoundTripStringToDateTimeOffset(
            this string value
            )
        {
            return DateTimeOffset.ParseExact(value, "o", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из даты в строку.
        /// </summary>
        /// <param name="value">Дата.</param>
        /// <param name="coreBaseResourceErrors">Ресурсы преобразования основы ядра.</param>
        /// <returns>Строковое представление даты.</returns>        
        public static string CoreBaseExtConvertFromDateToString(
            this DateTime value,
            CoreBaseResourceConverting coreBaseResourceConverting
            )
        {
            return value.ToString(
                coreBaseResourceConverting.GetStringDateFormat(),
                CultureInfo.InvariantCulture
                );
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из строки в дату.
        /// </summary>
        /// <param name="value">Строковое представление даты.</param>
        /// <param name="coreBaseResourceErrors">Ресурсы преобразования основы ядра.</param>
        /// <returns>Дата.</returns>
        public static DateTime CoreBaseExtConvertToDate(
            this string value,
            CoreBaseResourceConverting coreBaseResourceConverting
            )
        {
            return DateTime.ParseExact(
                value.Trim(),
                coreBaseResourceConverting.GetStringDateFormat(),
                CultureInfo.InvariantCulture
                );
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. Из даты или нуля в строку.
        /// </summary>
        /// <param name="value">Дата или нуль.</param>
        /// <param name="coreBaseResourceConverting">Ресурсы преобразования основы ядра.</param>
        /// <returns>Строковое представления даты или нуля.</returns>
        public static string CoreBaseExtConvertFromDateNullableToString(
            this DateTime? value,
            CoreBaseResourceConverting coreBaseResourceConverting
            )
        {
            return value.HasValue
                ? value.Value.CoreBaseExtConvertFromDateToString(coreBaseResourceConverting)
                : string.Empty;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В дату или нуль.
        /// </summary>
        /// <param name="value">Строковое представление даты или нуля.</param>
        /// <param name="coreBaseResourceConverting">Ресурсы преобразования основы ядра.</param>
        /// <returns>Дата или нуль.</returns>
        public static DateTime? CoreBaseExtConvertToDateNullable(
            this string value,
            CoreBaseResourceConverting coreBaseResourceConverting
            )
        {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : new DateTime?(value.CoreBaseExtConvertToDate(coreBaseResourceConverting)
                );
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В десятичную дробь.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Десятичная дробь.</returns>
        public static decimal CoreBaseExtConvertToNumericDecimal(this string value)
        {
            return decimal.Parse(
                value.Trim(),
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture
                );
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В десятичную дробь или нуль.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Десятичная дробь или нуль.</returns>
        public static decimal? CoreBaseExtConvertToNumericDecimalNullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? (decimal?)null
                : value.CoreBaseExtConvertToNumericDecimal();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В 32-х разрядное целое число.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число.</returns>
        public static int CoreBaseExtConvertToNumericInt32(this string value)
        {
            return int.Parse(value.Trim(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В 32-х разрядное целое число или NULL.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число или NULL.</returns>
        public static int? CoreBaseExtConvertToNumericInt32Nullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? (int?)null
                : value.CoreBaseExtConvertToNumericInt32();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В 64-х разрядное целое число.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число.</returns>
        public static long CoreBaseExtConvertToNumericInt64(this string value)
        {
            return long.Parse(value.Trim(), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В 64-х разрядное целое число или NULL.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Целое число или NULL.</returns>
        public static long? CoreBaseExtConvertToNumericInt64Nullable(this string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? (long?)null
                : value.CoreBaseExtConvertToNumericInt64();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Преобразовать. В массив 64-битных целых чисел.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Массив 64-битных целых чисел.</returns>
        public static long[] CoreBaseExtConvertToNumericInt64Array(this string value)
        {
            return value.CoreBaseExtConvertToNumericArray(x => long.Parse(x));
        }

        #endregion Public methods

        #region Private methods

        private static T[] CoreBaseExtConvertToNumericArray<T>(this string str, Func<string, T> funcParse)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new T[0];
            }
            else
            {
                return Regex.Replace(str, @"[^\d\+\-]", " ").Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => funcParse.Invoke(x))
                    .ToArray();
            }
        }

        #endregion Private methods
    }
}
