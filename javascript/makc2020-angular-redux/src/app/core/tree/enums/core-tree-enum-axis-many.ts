// //Author Maxim Kuzmin//makc//

/** Хост. Меню. Дерево. Перечисления. Оси для получения множества узлов. */
export enum AppCoreTreeEnumAxisMany {

  /**
   * Предки.
   * @type {number}
   */
  Ancestors,

  /**
   * Предки с корнем.
   * @type {number}
   */
  AncestorsWithRoot,
  /**
   * Потомки.
   * @type {number}
   */
  Descendants,

  /**
   * Дети одного родителя.
   * @type {number}
   */
  Siblings
}
