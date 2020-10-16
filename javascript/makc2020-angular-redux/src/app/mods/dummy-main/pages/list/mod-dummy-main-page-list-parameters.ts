// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';
import {AppCoreCommonPageParameters} from '@app/core/common/page/core-common-page-parameters';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppModDummyMainJobListGetInput} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-input';

/** Мод "DummyMain". Страницы. Список. Параметры. */
export class AppModDummyMainPageListParameters extends AppCoreCommonPageParameters {

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
   * Параметр "Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {AppCoreCommonPageParameter<number>}
   */
  paramObjectDummyOneToManyId = new AppCoreCommonPageParameter<number>('obj-dummy-one-to-many-id', this.index);

  /**
   * Параметр "Строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramObjectDummyOneToManyIdsString = new AppCoreCommonPageParameter<string>('obj-dummy-one-to-many-ids', this.index);

  /**
   * Параметр "Имя объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {AppCoreCommonPageParameter<string>}
   */
  paramObjectDummyOneToManyName = new AppCoreCommonPageParameter<string>('obj-dummy-one-to-many-name', this.index);

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
    this.paramObjectDummyOneToManyId.value = 0;
  }

  /**
   * Создать ввод для задания на получение списка.
   * @returns {AppModDummyMainJobListGetInput} Ввод.
   */
  createJobListGetInput(): AppModDummyMainJobListGetInput {
    return new AppModDummyMainJobListGetInput(
      this.paramPageNumber.value,
      this.paramPageSize.value,
      this.paramSortDirection.value,
      this.paramSortField.value,
      this.paramIdsString.value,
      this.paramName.value,
      this.paramObjectDummyOneToManyId.value,
      this.paramObjectDummyOneToManyIdsString.value,
      this.paramObjectDummyOneToManyName.value
    );
  }
}
