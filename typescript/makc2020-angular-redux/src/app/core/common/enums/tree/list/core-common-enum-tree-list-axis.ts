// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Перечисления. Дерево. Список. Оси. */
export enum AppCoreCommonEnumTreeListAxis {

  /**
   * Отсутствует.
   * @type {number}
   */
  None = 0,

  /**
   * Все.
   * @type {number}
   */
  All = 1,

  /**
   * Предок.
   * @type {number}
   */
  Ancestor = 2,

  /**
   * Предок или корневой узел.
   * @type {number}
   */
  AncestorOrSelf = 3,

  /**
   * Ребёнок.
   * @type {number}
   */
  Child = 4,

  /**
   * Ребёнок или корневой узел.
   * @type {number}
   */
  ChildOrSelf = 5,

  /**
   * Потомок.
   * @type {number}
   */
  Descendant = 6,

  /**
   * Потомок или корневой узел.
   * @type {number}
   */
  DescendantOrSelf = 7,

  /**
   * Родитель или корневой узел.
   * @type {number}
   */
  ParentOrSelf = 8
}
