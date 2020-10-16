// //Author Maxim Kuzmin//makc//

import {FormControl, FormGroup} from '@angular/forms';
import {AppModDummyMainPageListDataItem} from './data/mod-dummy-main-page-list-data-item';
import {AppModDummyMainJobListGetInput} from '@app/mods/dummy-main/jobs/list/get/mod-dummy-main-job-list-get-input';
import {AppModDummyMainPageListParameters} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-parameters';
import {
  AppModDummyMainCommonJobOptionsGetOutputList,
  appModDummyMainCommonJobOptionsGetOutputListCreate
} from '@app/mods/dummy-main/common/jobs/options/get/output/mod-dummy-main-common-job-options-get-output-list';
import {AppModDummyMainPageListSettingFields} from '@app/mods/dummy-main/pages/list/settings/mod-dummy-main-page-list-setting-fields';

/** Мод "DummyMain". Страницы. Список. Вид. */
export abstract class AppModDummyMainPageListView {

  /**
   * Идентификатор текущего элемента.
   * @type {number}
   */
  currentItemId = 0;

  /**
   * Поле для выбора отфильтрованного.
   * @type {FormControl}
   */
  fieldFiltered = new FormControl();

  /**
   * Элемент управления для ввода имени.
   * @type {FormControl}
   */
  fieldName = new FormControl();

  /**
   * Группа полей формы.
   * @type {FormGroup}
   */
  formGroup: FormGroup;

  /**
   * Признак того, что действие началось.
   * @type {boolean}
   */
  isActionStarted = false;

  /**
   * Признак того, что данные загружены.
   * @type {boolean}
   */
  isDataLoaded = false;

  /**
   * Признак того, что данные обновлены.
   * @type {boolean}
   */
  isDataRefreshed = false;

  /**
   * Признак того, что удаление элемента началось.
   * @param {boolean}
   */
  isItemDeleteStarted = false;

  /**
   * Признак того, что удаление элементов началось.
   * @param {boolean}
   */
  isItemsDeleteStarted = false;

  /**
   * Признак того, что сортировка применена.
   * @type {boolean}
   */
  isSortApplied = false;

  /**
   * Варианты выбора сущности "DummyOneToMany".
   * @type {AppModDummyMainCommonJobOptionsGetOutputList}
   */
  optionsDummyOneToMany: AppModDummyMainCommonJobOptionsGetOutputList;

  /**
   * Размер страницы.
   * @type {number}
   */
  pageSize = 0;

  /**
   * Значение параметра "Имя".
   * @type {string}
   */
  paramNameValue: string;

  /**
   * Значение параметра "Идентификатор объекта сущности DummyOneToMany".
   * @type {string}
   */
  paramObjectDummyOneToManyIdValue: number;

  /**
   * Сообщения об ошибках отклика.
   * @type {string[]}
   */
  responseErrorMessages: string[] = [];

  /**
   * Сообщения об успехах отклика.
   * @type {string[]}
   */
  responseSuccessMessages: string[] = [];

  /**
   * Общее количество записей.
   * @type {number}
   */
  totalCount = 0;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListSettingFields} settingFields Настройка полей.
   */
  protected constructor(
    private settingFields: AppModDummyMainPageListSettingFields
  ) {
    this.loadOptionsDummyOneToMany();
  }

  /**
   * Получить номер страницы.
   * @return {number}
   */
  abstract getPageNumber(): number;

  /**
   * Получить размер страницы.
   * @return {number}
   */
  abstract getPageSize(): number;

  /**
   * Получить идентификатор выбранного элемента.
   * @returns {number} Идентификатор выбранного элемента.
   */
  abstract getSelectedItemId(): number;

  /**
   * Получить направление сортировки.
   * @return {string}
   */
  abstract getSortDirection(): string;

  /**
   * Получить поле сортировки.
   * @return {string}
   */
  abstract getSortField(): string;

  /** Спрятать спиннер загрузки. */
  abstract hideLoadingSpinner();

  /** Спрятать спиннер обновления. */
  abstract hideRefreshSpinner();

  /**
   * Инициализировать спиннер загрузки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract initLoadingSpinner(callback: () => void);

  /** Инициализировать спиннер обновления. */
  abstract initRefreshSpinner();

  /**
   * Загрузить данные.
   * @param {AppModDummyMainPageListDataItem[]} data Данные.
   * @param {AppModDummyMainPageListParameters} parameters Параметры.
   */
  abstract loadData(
    data: AppModDummyMainPageListDataItem[],
    parameters: AppModDummyMainPageListParameters
  );

  /**
   * Загрузить варианты выбора сущности "CalcElementState".
   * @param {?AppModDummyMainCommonJobOptionsGetOutputList} data Данные.
   */
  loadOptionsDummyOneToMany(data?: AppModDummyMainCommonJobOptionsGetOutputList) {
    this.optionsDummyOneToMany = data ?? appModDummyMainCommonJobOptionsGetOutputListCreate();
  }

  /**
   * Установить номер страницы.
   * @param {number} value Значение.
   */
  abstract setPageNumber(value: number);

  /**
   * Установить идентификатор выбранного элемента.
   * @param {number} value Значение.
   */
  abstract setSelectedItemId(value: number);

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();

  /**
   * Подписаться на событие выбора строки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnRowSelect(callback: () => void);

  /**
   * Подписаться на событие изменения сортировки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnSortChange(callback: () => void);

  /**
   * Подписаться на событие изменения сортировки или страницы.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnSortOrPageChange(callback: () => void);
}
