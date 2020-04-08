//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Enums
{
    /// <summary>
    /// Ядро. Основа. Общее. Перечисления. Оси выборки узлов дерева.
    /// </summary>
    public enum CoreBaseCommonEnumTreeAxis
    {
        /// <summary>
        /// Все.
        /// </summary>
        All = 0,
        /// <summary>
        /// Потомок.
        /// </summary>
        Descendant = 1,
        /// <summary>
        /// Потомок или корневой узел.
        /// </summary>
        DescendantOrSelf = 2,
        /// <summary>
        /// Предок.
        /// </summary>
        Ancestor = 3,
        /// <summary>
        /// Предок или корневой узел.
        /// </summary>
        AncestorOrSelf = 4,
        /// <summary>
        /// Ребёнок.
        /// </summary>
        Child = 5,
        /// <summary>
        /// Ребёнок или корневой узел.
        /// </summary>
        ChildOrSelf = 6,
        /// <summary>
        /// Родитель.
        /// </summary>
        Parent = 7,
        /// <summary>
        /// Родитель или корневой узел.
        /// </summary>
        ParentOrSelf = 8,
        /// <summary>
        /// Корневой узел.
        /// </summary>
        Self = 9
    }
}
