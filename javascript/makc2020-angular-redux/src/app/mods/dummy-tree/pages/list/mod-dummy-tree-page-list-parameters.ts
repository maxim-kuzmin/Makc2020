// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModDummyTreeJobListGetInput} from '../../jobs/list/get/mod-dummy-tree-job-list-get-input';

/** Мод "DummyTree". Страницы. Список. Параметры. */
export class AppModDummyTreePageListParameters extends AppCoreCommonPageParameters {

  /**
   * Параметр "Строка идентификаторов".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramIdsString = new AppCoreCommonPageParameter<string>('ids', this.index);

  /**
   * Параметр "Признак того, что данные обновлены".
   * @type {boolean}
   */
  paramIsDataRefreshed = new AppCoreCommonPageParameter<boolean>('r', this.index);

  /**
   * Параметр "Имя".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramName = new AppCoreCommonPageParameter<string>('name', this.index);

  /**
   * Параметр "Номер страницы".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramPageNumber = new AppCoreCommonPageParameter<number>('pn', this.index);

  /**
   * Параметр "Размер страницы".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramPageSize = new AppCoreCommonPageParameter<number>('ps', this.index);

  /**
   * Параметр "Индекс выбранного элемента".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramSelectedItemId = new AppCoreCommonPageParameter<number>('sid', this.index);

  /**
   * Параметр "Строка идентификаторов выбранных элементов".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramSelectedItemIdsString = new AppCoreCommonPageParameter<string>('sids', this.index);

  /**
   * Параметр "Направление сортировки".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramSortDirection = new AppCoreCommonPageParameter<string>('sd', this.index);

  /**
   * Параметр "Поле сортировки".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramSortField = new AppCoreCommonPageParameter<string>('sf', this.index);

  /**
   * Конструктор.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {string} index Индекс.
   */
  constructor(appSettings: AppCoreSettings, index: string) {
    super(index);

    const {
      pageSize,
      sortDirection
    } = appSettings;

    this.paramIsDataRefreshed.value = false;
    this.paramPageNumber.value = 1;
    this.paramPageSize.value = pageSize;
    this.paramSelectedItemId.value = 0;
    this.paramSortDirection.value = sortDirection;
    this.paramSortField.value = 'id';
  }

  /**
   * Создать ввод для задания на получение списка.
   * @returns {AppModDummyTreeJobListGetInput} Ввод.
   */
  createJobListGetInput(): AppModDummyTreeJobListGetInput {
    return new AppModDummyTreeJobListGetInput(
      this.paramPageNumber.value,
      this.paramPageSize.value,
      this.paramSortDirection.value,
      this.paramSortField.value,
      this.paramIdsString.value,
      this.paramName.value
    );
  }
}
