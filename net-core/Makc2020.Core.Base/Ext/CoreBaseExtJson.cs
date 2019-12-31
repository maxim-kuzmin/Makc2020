//Author Maxim Kuzmin//makc//

using System.Text.Encodings.Web;
using System.Text.Json;

namespace Makc2020.Core.Base.Ext
{
    /// <summary>
    /// Ядро. Основа. Расширение. JSON.
    /// </summary>
    public static class CoreBaseExtJson
    {
        #region Properties

        /// <summary>
        /// Опции для конфигурации.
        /// </summary>
        public static JsonSerializerOptions OptionsForConfig { get; } = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreNullValues = true
        };

        /// <summary>
        /// Опции для JavaScript.
        /// </summary>
        public static JsonSerializerOptions OptionsForJavaScript { get; } = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            IgnoreNullValues = true
        };

        /// <summary>
        /// Опции для регистратора.
        /// </summary>
        public static JsonSerializerOptions OptionsForLogger { get; } = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            IgnoreNullValues = false
        };

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Ядро. Основа. Расширение. JSON. Глубоко клонировать.
        /// </summary>
        /// <typeparam name="T">Тип клонируемого значения.</typeparam>
        /// <param name="value">Клонируемое значение.</param>
        /// <returns>Клон.</returns>
        public static T CoreBaseExtJsonDeepClone<T>(this T value)
        {
            return value.CoreBaseExtJsonSerialize(null).CoreBaseExtJsonDeserialize<T>(null);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. JSON. Десериализовать.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="json">Строка в формате JSON.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T CoreBaseExtJsonDeserialize<T>(this string json, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. JSON. Попробовать десериализовать.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="json">Строка в формате JSON.</param>
        /// <param name="value">Значение указанного типа.</param>
        /// <param name="options">Опции.</param>
        /// <param name="defaultValue">Значение по-умолчанию.</param>
        /// <returns>Признак успешности десериализации.</returns>
        public static bool CoreBaseExtJsonTryDeserialize<T>(
            this string json,
            out T value,
            JsonSerializerOptions options,
            T defaultValue = default
            )
        {
            var result = true;

            value = defaultValue;

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    value = CoreBaseExtJsonDeserialize<T>(json, options);
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
        /// Ядро. Основа. Расширение. JSON. Сериализовать.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Строка в формате JSON.</returns>
        public static string CoreBaseExtJsonSerialize(this object obj, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(obj, options);
        }

        /// <summary>
        /// Ядро. Основа. Расширение. JSON. Попробовать сериализовать.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Строка в формате JSON.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool CoreBaseExtJsonTrySerialize(
            this object obj,
            out string value,
            JsonSerializerOptions options
            )
        {
            bool result = true;

            value = null;

            if (obj != null)
            {
                try
                {
                    value = CoreBaseExtJsonSerialize(obj, options);
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

        #endregion Public methods
    }
}