// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {
  AppModDummyMainJobItemGetInput
} from '../../jobs/item/get/mod-dummy-main-job-item-get-input';

/** Мод "DummyMain". Страницы. Список. Параметры. */
export class AppModDummyMainPageItemParameters extends AppCoreCommonPageParameters {

  /**
   * Параметр "Идентификатор".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramId = new AppCoreCommonPageParameter<number>('id', this.index);

  /**
   * Параметр "Имя".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramName = new AppCoreCommonPageParameter<string>('name', this.index);

  /**
   * Конструктор.
   * @param {number} index Индекс.
   */
  constructor(index: string) {
    super(index);
  }

  /**
   * Создать ввод для задания на получение элемента.
   * @returns {AppModDummyMainJobItemGetInput} Ввод.
   */
  createJobItemGetInput(): AppModDummyMainJobItemGetInput {
    return new AppModDummyMainJobItemGetInput(
      this.paramId.value,
      this.paramName.value
    );
  }
}
