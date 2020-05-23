// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';
import {AppCoreCommonEnumTreeListAxis} from '@app/core/common/enums/tree/list/core-common-enum-tree-list-axis';

/** Ядро. Общее. Модуль. Задания. Дерево. Список. Получить. Ввод. */
export class AppCoreCommonModJobTreeListGetInput extends AppCoreCommonModJobListGetInput {

  /**
   * Разрешить только один уровень.
   * @type {?boolean}
   */
  allowOneLevelOnly?: boolean;

  /**
   * Ось.
   * @type {?AppCoreCommonEnumTreeListAxis}
   */
  axis?: AppCoreCommonEnumTreeListAxis;

  /**
   * Строка идентификаторов раскрытых узлов.
   * @type {?string}
   */
  openIdsString?: string;

  /**
   * Идентификатор корневого узла дерева.
   * @type {?string}
   */
  rootId?: number;

  /**
   * Конструктор.
   * @param {?boolean} allowOneLevelOnly Разрешить только один уровень.
   * @param {?AppCoreCommonEnumTreeListAxis} axis Ось.
   * @param {?string} openIdsString Строка идентификаторов раскрытых узлов.
   * @param {?number} pageNumber Номер страницы.
   * @param {?number} pageSize Размер страницы.
   * @param {?number} rootId Идентификатор корневого узла дерева.
   * @param {?string} sortField Поле сортировки.
   * @param {?string} sortDirection Направление сортировки.
   */
  constructor(
    allowOneLevelOnly?: boolean,
    axis?: AppCoreCommonEnumTreeListAxis,
    openIdsString?: string,
    pageNumber?: number,
    pageSize?: number,
    rootId?: number,
    sortField?: string,
    sortDirection?: string
  ) {
    super(
      pageNumber,
      pageSize,
      sortField,
      sortDirection
    );

    if (allowOneLevelOnly) {
      this.allowOneLevelOnly = allowOneLevelOnly;
    }

    if (axis) {
      this.axis = axis;
    }

    if (openIdsString) {
      this.openIdsString = openIdsString;
    }

    if (rootId) {
      this.rootId = rootId;
    }
  }
}
