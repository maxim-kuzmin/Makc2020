// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';

/** Мод "DummyMain". Задания. Элемент. Получение. Ввод. */
export class AppModDummyMainJobItemGetInput extends AppCoreCommonModJobItemGetInput {

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Признак предназначенности обновления.
   * @type {boolean}
   */
  get isForUpdate(): boolean {
    return !!(this.dataId > 0 || this.dataName);
  }

  /**
   * Конструктор.
   * @param {?number} dataId Идентификатор данных.
   * @param {?string} dataName Имя данных.
   */
  constructor(dataId?: number, dataName?: string) {
    super(dataId);

    if (dataName) {
      this.dataName = dataName;
    }
  }

  /**
   * Равно другому.
   * @param {AppModDummyMainPageItemParameters} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModDummyMainJobItemGetInput): boolean {
    return other
      && this.dataId === other.dataId
      && this.dataName === other.dataName;
  }
}
