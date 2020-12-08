// //Author Maxim Kuzmin//makc//

/** Данные. Объекты. Сущность "DummyTree". */
export interface AppDataObjectDummyTree {

  /**
   * Идентификатор.
   * @type {number}
   */
  id: number;

  /**
   * Имя.
   * @type {string}
   */
  name: string;

  /**
   * Идентификатор родителя.
   * @type {?number}
   */
  parentId?: number;

  /**
   * Число детей узла дерева.
   * @type {number}
   */
  treeChildCount: number;

  /**
   * Число потомков узла дерева.
   * @type {number}
   */
  treeDescendantCount: number;

  /**
   * Уровень узла в дереве.
   * @type {number}
   */
  treeLevel: number;

  /**
   * Путь узла в дереве.
   * @type {string}
   */
  treePath: string;

  /**
   * Позиция узла в дереве.
   * @type {number}
   */
  treePosition: number;

  /**
   * Сортировка узла в дереве.
   * @type {string}
   */
  treeSort: string;
}

/** Данные. Объекты. Сущность "DummyTree". Создать. */
export function appDataObjectDummyTreeCreate(): AppDataObjectDummyTree {
  return {} as AppDataObjectDummyTree;
}
