//Author Maxim Kuzmin//makc//

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. XML.
    /// </summary>
    public static class CoreBaseExtXml
	{
        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. XML. Глубоко клонировать.
        /// </summary>
        /// <typeparam name="T">Тип клонируемого значения.</typeparam>
        /// <param name="value">Клонируемое значение.</param>
        /// <returns>Клон.</returns>
        public static T CoreBaseExtXmlDeepClone<T>(this T value)
        {
            return value.CoreBaseExtXmlSerialize().CoreBaseExtXmlDeserialize<T>();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Десериализовать. Из XML.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="xml">Строка в формате XML.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T CoreBaseExtXmlDeserialize<T>(this string xml)
		{
			T result = default;

			using (var r = new StringReader(xml))
			{
				result = (T)new XmlSerializer(typeof(T)).Deserialize(r);
			}

			return result;
		}

        /// <summary>
        /// Ядро. Основа. Расширение. Десериализовать. Попробовать из XML.
        /// </summary>
        /// <param name="xml">XML.</param>
        /// <param name="value">Строка в формате XML.</param>
        /// <param name="defaultValue">Значение по умолчанию.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtXmlTryDeserialize<T>(
			this string xml,
			out T value,
			T defaultValue = default
			)
		{
			var result = true;

			value = defaultValue;

			if (!string.IsNullOrEmpty(xml))
			{
				try
				{
					value = CoreBaseExtXmlDeserialize<T>(xml);
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
        /// Ядро. Основа. Расширение. Сериализовать. В XML.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <returns>Строка в формате XML.</returns>
        public static string CoreBaseExtXmlSerialize(this object obj)
        {
            var buffer = new StringBuilder();

            using (TextWriter writer = new StringWriter(buffer))
            {
                new XmlSerializer(obj.GetType()).Serialize(writer, obj);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Сериализовать. В XML.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="namespaces">Пространства имён.</param>
        /// <param name="encoding">Кодировка.</param>
        /// <returns>Строка в формате XML.</returns>
        public static string CoreBaseExtXmlSerialize(
            this object obj,
            XmlSerializerNamespaces namespaces,
            Encoding encoding
            )
        {
            byte[] bytes;

            using (var s = new MemoryStream())
            {
                var settings = new XmlWriterSettings { Encoding = encoding };

                using (var w = XmlWriter.Create(s, settings))
                {
                    var sr = new XmlSerializer(obj.GetType(), string.Empty);

                    if (namespaces != null)
                    {
                        sr.Serialize(w, obj, namespaces);
                    }
                    else
                    {
                        sr.Serialize(w, obj);
                    }
                }

                bytes = s.ToArray();
            }

            return encoding.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Сериализовать. В XML в кодировке UTF-8.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="namespaces">Пространства имён.</param>
        /// <returns>Строка в формате XML.</returns>
        public static string CoreBaseExtXmlSerialize(this object obj, XmlSerializerNamespaces namespaces)
        {
            return CoreBaseExtXmlSerialize(obj, namespaces, Encoding.UTF8);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. Сериализовать. Попробовать в XML.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Строка в формате XML.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtXmlTrySerialize(this object obj, out string value)
        {
            bool result = true;

            value = null;

            if (obj != null)
            {
                try
                {
                    value = CoreBaseExtXmlSerialize(obj);
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
        /// Ядро. Основа. Расширение. Сериализовать. Попробовать в XML.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Строка в формате XML.</param>
        /// <param name="namespaces">Пространства имён.</param>
        /// <param name="encoding">Кодировка.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtXmlTrySerialize(
            this object obj,
            out string value,
            XmlSerializerNamespaces namespaces,
            Encoding encoding
            )
        {
            bool result = true;

            value = null;

            if (obj != null)
            {
                try
                {
                    value = CoreBaseExtXmlSerialize(obj, namespaces, encoding);
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
        /// Ядро. Основа. Расширение. Сериализовать. Попробовать в XML.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Строка в формате XML.</param>
        /// <param name="namespaces">Пространства имён.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtXmlTrySerialize(
            this object obj,
            out string value,
            XmlSerializerNamespaces namespaces
            )
        {
            return CoreBaseExtXmlTrySerialize(obj, out value, namespaces);
        }

        #endregion Public methods
    }
}