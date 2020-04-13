//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Base.Common.Enums.Tree.List
{
    /// <summary>
    /// Ядро. Основа. Общее. Перечисления. Дерево. Список. Оси.
    /// </summary>
    public enum CoreBaseCommonEnumTreeListAxis
    {
        /// <summary>
        /// Отсутствует.
        /// </summary>
        None = 0,
        /// <summary>
        /// Все.
        /// </summary>
        All = 1,
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
        /// Ребёнок или корневой узел.
        /// </summary>
        ChildOrSelf = 5,
        /// <summary>
        /// Потомок.
        /// </summary>
        Descendant = 6,
        /// <summary>
        /// Потомок или корневой узел.
        /// </summary>
        DescendantOrSelf = 7,
        /// <summary>
        /// Родитель или корневой узел.
        /// </summary>
        ParentOrSelf = 8
    }
}
