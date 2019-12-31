//Author Maxim Kuzmin//makc//

using System;
using ProtoBuf;
using Makc2020.Core.Base.Ext;

namespace Makc2020.Core.Caching.ProtoBufs
{
    /// <summary>
    /// Ядро. Кэширование. Суррогаты "ProtoBuf". DateTimeOffset.
    /// </summary>
    [ProtoContract]
    public class CoreCachingProtoBufDateTimeOffset
    {
        #region Properties

        /// <summary>
        /// Данные.
        /// </summary>
        [ProtoMember(1)]
        public string Data { get; set; }

        #endregion Properties

        #region Operators

        /// <summary>
        /// Неявное преобразование значения типа DateTimeOffset к значению типа String.
        /// </summary>
        /// <param name="value">Преобразуемое значение.</param>
        public static implicit operator CoreCachingProtoBufDateTimeOffset(DateTimeOffset value)
        {
            return new CoreCachingProtoBufDateTimeOffset
            {
                Data = value.CoreBaseExtConvertFromDateTimeOffsetToRoundTripString()
            };
        }

        #endregion Operators

        #region Public methods

        /// <summary>
        /// Неявное преобразование значения типа CoreProtoBufSurrogateDateTimeOffset к значению типа DateTimeOffset.
        /// </summary>
        /// <param name="value">Преобразуемое значение.</param>
        public static implicit operator DateTimeOffset(CoreCachingProtoBufDateTimeOffset value)
        {
            return value.Data.CoreBaseExtConvertFromRoundTripStringToDateTimeOffset();
        }

        /// <summary>
        /// Зарегистрировать.
        /// </summary>
        /// <param name="model">Модель.</param>
        public static void Register(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            model.Add(typeof(DateTimeOffset), false).SetSurrogate(typeof(CoreCachingProtoBufDateTimeOffset));
        }

        #endregion Public methods
    }
}
