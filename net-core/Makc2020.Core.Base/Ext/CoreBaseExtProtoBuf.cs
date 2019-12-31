//Author Maxim Kuzmin//makc//

using System;
using System.IO;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. ProtoBuf.
    /// </summary>
    public static class CoreBaseExtProtoBuf
	{
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. ProtoBuf. Глубоко клонировать.
        /// </summary>
        /// <typeparam name="T">Тип клонируемого значения.</typeparam>
        /// <param name="value">Клонируемое значение.</param>
        /// <returns>Клон.</returns>
        public static T CoreBaseExtProtoBufDeepClone<T>(this T value)
        {
            return value.CoreBaseExtProtoBufSerialize().CoreBaseExtProtoBufDeserialize<T>();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. ProtoBuf. Десериализовать.
        /// </summary>
        /// <typeparam name="T">Тип, в который нужно десериализовать байтовый массив ProtoBuf.</typeparam>
        /// <param name="bytes">Байтовый массив ProtoBuf.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T CoreBaseExtProtoBufDeserialize<T>(this byte[] bytes)
        {
            T result = default;

            using (var s = new MemoryStream(bytes))
            {
                result = ProtoBuf.Serializer.Deserialize<T>(s);
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. ProtoBuf. Десериализовать из строки Base64.
        /// </summary>
        /// <typeparam name="T">Тип, в который нужно десериализовать строку.</typeparam>
        /// <param name="str">Строка Base64.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T CoreBaseExtProtoBufDeserializeFromBase64String<T>(this string str)
        {
            return Convert.FromBase64String(str).CoreBaseExtProtoBufDeserialize<T>();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. ProtoBuf. Сериализовать.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Байтовый массив ProtoBuf.</returns>
        public static byte[] CoreBaseExtProtoBufSerialize(this object value)
        {
            byte[] result;

            using (var s = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(s, value);

                result = s.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Ядро. Основа. Расширение. ProtoBuf. Сериализовать в строку Base64.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Строка Base64.</returns>
        public static string CoreBaseExtProtoBufSerializeToBase64String(this object value)
        {
            return Convert.ToBase64String(value.CoreBaseExtProtoBufSerialize());
        }

        #endregion Public methods
    }
}