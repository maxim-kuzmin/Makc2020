//Author Maxim Kuzmin//makc//

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. Бинарно.
    /// </summary>
    public static class CoreBaseExtBinary
	{
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Глубоко клонировать.
        /// </summary>
        /// <typeparam name="T">Тип клонируемого значения.</typeparam>
        /// <param name="value">Клонируемое значение.</param>
        /// <returns>Клон.</returns>
        public static T CoreBaseExtBinaryDeepClone<T>(this T value)
        {
            return value.CoreBaseExtBinarySerialize().CoreBaseExtBinaryDeserialize<T>();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Десериализовать.
        /// </summary>
        /// <typeparam name="T">Тип, в который нужно десериализовать байтовый массив.</typeparam>
        /// <param name="bytes">Байтовый массив.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T CoreBaseExtBinaryDeserialize<T>(this byte[] bytes)
        {
            T result = default;

            using (var s = new MemoryStream(bytes))
            {
                result = (T)new BinaryFormatter().Deserialize(s);
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Попробовать десериализовать.
        /// </summary>
        /// <param name="bytes">Десериализуемый массив байтов бинарной сериализации.</param>
        /// <param name="value">Десериализованное значение указанного типа.</param>
        /// <param name="defaultValue">Значение по умолчанию.</param>
        /// <returns>Признак успешности десериализации.</returns>
        public static bool CoreBaseExtBinaryTryDeserialize<T>(
            this byte[] bytes,
            out T value,
            T defaultValue = default
            )
        {
            var result = true;

            value = defaultValue;

            if (bytes != null && bytes.Length > 0)
            {
                try
                {
                    value = CoreBaseExtBinaryDeserialize<T>(bytes);
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Десериализовать из строки Base64.
        /// </summary>
        /// <param name="value">Строка Base64.</param>
        /// <returns>Значение указанного типа.</returns>
		public static T CoreBaseExtBinaryDeserializeFromBase64String<T>(this string value)
        {
            return Convert.FromBase64String(value).CoreBaseExtBinaryDeserialize<T>();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Сериализовать.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Байтовый массив бинарной сериализации.</returns>
        public static byte[] CoreBaseExtBinarySerialize(this object value)
        {
            byte[] result;

            using (var s = new MemoryStream())
            {
                new BinaryFormatter().Serialize(s, value);

                result = s.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Попробовать сериализовать.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Сериализованное значение (байтовый массив бинарной сериализации).</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtBinaryTrySerialize(this object obj, out byte[] value)
        {
            bool result = true;

            value = null;

            if (obj != null)
            {
                try
                {
                    value = CoreBaseExtBinarySerialize(obj);
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Бинарно. Сериализовать в строку Base64.
        /// </summary>
        /// <param name="value">Сериализуемое значение.</param>
        /// <returns>Строка Base64.</returns>
        public static string CoreBaseExtBinarySerializeToBase64String(this object value)
        {
            return Convert.ToBase64String(CoreBaseExtBinarySerialize(value));
        }

        #endregion Public methods
    }
}