// //Author Maxim Kuzmin//makc//

/** Данные. Объекты. Сущность "DummyTree". */
export interface AppDataObjectDummyTree {

  /**
   * Число детей.
   * @type {number}
   */
  childCount: number;

  /**
   * Число потомков.
   * @type {number}
   */
  descendantCount: number;

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
   * Уровень.
   * @type {number}
   */
  level: number;

  /**
   * Идентификатор родителя.
   * @type {?number}
   */
  parentId?: number;
}

/** Данные. Объекты. Сущность "DummyTree". Создать. */
export function appDataObjectDummyTreeCreate(): AppDataObjectDummyTree {
  return {} as AppDataObjectDummyTree;
}
