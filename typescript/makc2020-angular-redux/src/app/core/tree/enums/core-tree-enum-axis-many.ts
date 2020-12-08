// //Author Maxim Kuzmin//makc//

/** Ядро. Дерево. Перечисления. Оси для получения множества узлов. */
export enum AppCoreTreeEnumAxisMany {

  /**
   * Предки.
   * @type {number}
   */
  Ancestors = 0,

  /**
   * Предки с корнем.
   * @type {number}
   */
  AncestorsWithRoot = 1,
  /**
   * Потомки.
   * @type {number}
   */
  Descendants = 2,

  /**
   * Дети одного родителя.
   * @type {number}
   */
  Siblings = 3
}
