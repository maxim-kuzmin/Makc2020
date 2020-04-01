// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {AppModDummyTreeJobItemGetInput} from '@app/mods/dummy-tree/jobs/item/get/mod-dummy-tree-job-item-get-input';

/** Мод "DummyTree". Страницы. Список. Параметры. */
export class AppModDummyTreePageItemParameters extends AppCoreCommonPageParameters {

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
   * @returns {AppModDummyTreeJobItemGetInput} Ввод.
   */
  createJobItemGetInput(): AppModDummyTreeJobItemGetInput {
    return new AppModDummyTreeJobItemGetInput(
      this.paramId.value,
      this.paramName.value
    );
  }
}
