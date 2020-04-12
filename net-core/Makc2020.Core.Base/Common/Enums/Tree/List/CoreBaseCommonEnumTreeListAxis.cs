//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Enums.Tree.List
{
    /// <summary>
    /// Ядро. Основа. Общее. Перечисления. Дерево. Список. Оси.
    /// </summary>
    public enum CoreBaseCommonEnumTreeListAxis
    {
        /// <summary>
        /// Все.
        /// </summary>
        All = 0,
        /// <summary>
        /// Предок.
        /// </summary>
        Ancestor = 1,
        /// <summary>
        /// Предок или корневой узел.
        /// </summary>
        AncestorOrSelf = 2,
        /// <summary>
        /// Ребёнок.
        /// </summary>
        Child = 3,
        /// <summary>
        /// Ребёнок или корневой узел.
        /// </summary>
        ChildOrSelf = 4,
        /// <summary>
        /// Потомок.
        /// </summary>
        Descendant = 5,
        /// <summary>
        /// Потомок или корневой узел.
        /// </summary>
        DescendantOrSelf = 6,
        /// <summary>
        /// Родитель или корневой узел.
        /// </summary>
        ParentOrSelf = 7
    }
}
