//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Enums
{
    /// <summary>
    /// Ядро. Основа. Общее. Перечисления. Оси дерева.
    /// </summary>
    public enum CoreBaseCommonEnumTreeAxis
    {
        /// <summary>
        /// Потомок.
        /// </summary>
        Descendant = 0,
        /// <summary>
        /// Потомок или корневой узел.
        /// </summary>
        DescendantOrSelf = 1,
        /// <summary>
        /// Предок.
        /// </summary>
        Ancestor = 2,
        /// <summary>
        /// Предок или корневой узел.
        /// </summary>
        AncestorOrSelf = 3,
        /// <summary>
        /// Ребёнок.
        /// </summary>
        Child = 4,
        /// <summary>
        /// Сам.
        /// </summary>
        Self = 5
    }
}
