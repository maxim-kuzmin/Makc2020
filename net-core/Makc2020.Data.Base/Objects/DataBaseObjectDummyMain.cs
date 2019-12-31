//Author Maxim Kuzmin//makc//

using System;

namespace Makc2020.Data.Base.Objects
{
    /// <summary>
    /// Данные. Основа. Объекты. Сущность "DummyMain".
    /// </summary>
    public class DataBaseObjectDummyMain
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
        /// </summary>
        public long ObjectDummyOneToManyId { get; set; }

        /// <summary>
        /// Свойство, содержащее логическое значение.
        /// </summary>
        public bool PropBoolean { get; set; }

        /// <summary>
        /// Свойство, содержащее логическое значение или NULL.
        /// </summary>
        public bool? PropBooleanNullable { get; set; }

        /// <summary>
        /// Свойство, содержащее дату.
        /// </summary>
        public DateTime PropDate { get; set; }

        /// <summary>
        /// Свойство, содержащее дату или NULL.
        /// </summary>
        public DateTime? PropDateNullable { get; set; }

        /// <summary>
        /// Свойство, содержащее дату и время с часовым поясом.
        /// </summary>
        public DateTimeOffset PropDateTimeOffset { get; set; }

        /// <summary>
        /// Свойство, содержащее дату и время с часовым поясом или NULL.
        /// </summary>
        public DateTimeOffset? PropDateTimeOffsetNullable { get; set; }

        /// <summary>
        /// Свойство, содержащее десятичную дробь.
        /// </summary>
        public decimal PropDecimal { get; set; }

        /// <summary>
        /// Свойство, содержащее десятичную дробь или NULL.
        /// </summary>
        public decimal? PropDecimalNullable { get; set; }

        /// <summary>
        /// Свойство, содержащее целое 32-разрядное число.
        /// </summary>
        public int PropInt32 { get; set; }

        /// <summary>
        /// Свойство, содержащее целое 32-разрядное число или NULL.
        /// </summary>
        public int? PropInt32Nullable { get; set; }

        /// <summary>
        /// Свойство, содержащее целое 64-разрядное число.
        /// </summary>
        public long PropInt64 { get; set; }

        /// <summary>
        /// Свойство, содержащее целое 64-разрядное число или NULL.
        /// </summary>
        public long? PropInt64Nullable { get; set; }

        /// <summary>
        /// Свойство, содержащее строку.
        /// </summary>
        public string PropString { get; set; }

        /// <summary>
        /// Свойство, содержащее строку или NULL.
        /// </summary>
        public string PropStringNullable { get; set; }

        #endregion Properties
    }
}