// //Author Maxim Kuzmin//makc//

import {AppCoreCommonEnumTreeItemAxis} from '@app/core/common/enums/tree/item/core-common-enum-tree-item-axis';

/** Ядро. Общее. Модуль. Задания. Дерево. Элемент. Получить. Ввод. */
export class AppCoreCommonModJobTreeItemGetInput {

  /**
   * Ось.
   * @type {?AppCoreCommonEnumTreeItemAxis}
   */
  axis?: AppCoreCommonEnumTreeItemAxis;

  /**
   * Идентификатор корневого узла дерева.
   * @type {?number}
   */
  rootId?: number;

  /**
   * Признак предназначенности для обновления.
   * @type {boolean}
   */
  get isForUpdate(): boolean {
    return this.rootId > 0;
  }

  /**
   * Конструктор.
   * @param {?AppCoreCommonEnumTreeItemAxis} axis Ось.
   * @param {?number} rootId Идентификатор корневого узла дерева.
   */
  constructor(axis?: AppCoreCommonEnumTreeItemAxis, rootId?: number) {
    if (axis) {
      this.axis = axis;
    }

    if (rootId) {
      this.rootId = rootId;
    }
  }

  /**
   * Равно другому.
   * @param {AppCoreCommonModJobTreeItemGetInput} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals<T extends AppCoreCommonModJobTreeItemGetInput>(other: T): boolean {
    return other
      && this.axis === other.axis
      && this.rootId === other.rootId;
  }
}
