// //Author Maxim Kuzmin//makc//

import {AppCoreCommonEnumTreeItemAxis} from '@app/core/common/enums/tree/item/core-common-enum-tree-item-axis';
import {AppCoreCommonModJobTreeItemGetInput} from '@app/core/common/mod/jobs/tree/item/get/core-common-mod-job-tree-item-get-input';
import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';

/** Мод "DummyTree". Страницы. Список. Параметры. */
export class AppModDummyTreePageItemParameters extends AppCoreCommonPageParameters {

  /**
   * Параметр "Ось".
   * @type {AppCoreCommonPageParameter<AppCoreCommonEnumTreeItemAxis>}
   */
  paramAxis = new AppCoreCommonPageParameter<AppCoreCommonEnumTreeItemAxis>('axis', this.index);

  /**
   * Параметр "Идентификатор корневого узла дерева".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramRootId = new AppCoreCommonPageParameter<number>('root-id', this.index);

  /**
   * Конструктор.
   * @param {number} index Индекс.
   */
  constructor(index: string) {
    super(index);
  }

  /**
   * Создать ввод для задания на получение элемента.
   * @returns {AppCoreCommonModJobTreeItemGetInput} Ввод.
   */
  createJobItemGetInput(): AppCoreCommonModJobTreeItemGetInput {
    return new AppCoreCommonModJobTreeItemGetInput(
      this.paramAxis.value,
      this.paramRootId.value
    );
  }
}
