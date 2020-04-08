//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Enums
{
    /// <summary>
    /// Ядро. Основа. Общее. Перечисления. Действия триггера SQL.
    /// </summary>
    public enum CoreBaseCommonEnumSqlTriggerActions
    {
        /// <summary>
        /// Отсутствует.
        /// </summary>
        None = 0,
        /// <summary>
        /// Удаление.
        /// </summary>
        Delete = 1,
        /// <summary>
        /// Вставка.
        /// </summary>
        Insert = 2,
        /// <summary>
        /// Обновление.
        /// </summary>
        Update = 3
    }
}
