// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobItemGetInput} from '@app/core/common/mod/jobs/item/get/core-common-mod-job-item-get-input';

/** Мод "DummyMain". Задания. Элемент. Получение. Ввод. */
export class AppModDummyMainJobItemDeleteInput extends AppCoreCommonModJobItemGetInput {

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Конструктор.
   * @param {?number} dataId Данные: идентификатор.
   * @param {?string} dataName Данные: имя.
   */
  constructor(dataId?: number, dataName?: string) {
    super(dataId);

    if (dataName) {
      this.dataName = dataName;
    }
  }
}
