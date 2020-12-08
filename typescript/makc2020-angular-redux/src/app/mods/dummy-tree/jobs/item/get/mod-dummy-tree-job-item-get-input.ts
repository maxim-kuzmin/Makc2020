// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';
import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';

/** Мод "DummyMain". Задания. Элемент. Получение. Ввод. */
export class AppModDummyTreeJobItemGetInput extends AppCoreCommonModJobTreeItemGetInput {

  /**
   * Признак предназначенности для обновления.
   * @type {boolean}
   */
  get isForUpdate(): boolean {
    return this.rootId > 0;
  }

  /**
   * Равно другому.
   * @param {AppModDummyMainPageItemParameters} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModDummyTreeJobItemGetInput): boolean {
    return other
      && this.axis === other.axis
      && this.rootId === other.rootId;
  }
}
