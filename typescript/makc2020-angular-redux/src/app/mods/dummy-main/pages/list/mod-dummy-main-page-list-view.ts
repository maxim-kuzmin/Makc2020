// //Author Maxim Kuzmin//makc//

import {AbstractControl, FormControl, FormGroup} from '@angular/forms';
import {
  AppModDummyMainCommonJobOptionsGetOutputList,
  appModDummyMainCommonJobOptionsGetOutputListCreate
} from '../../common/jobs/options/get/output/mod-dummy-main-common-job-options-get-output-list';
import {AppModDummyMainPageListDataItem} from './data/mod-dummy-main-page-list-data-item';
import {AppModDummyMainPageListSettingFields} from './settings/mod-dummy-main-page-list-setting-fields';
import {AppModDummyMainPageListParameters} from './mod-dummy-main-page-list-parameters';

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
   * Поле ввода имени.
   * @type {AbstractControl}
   */
  get fieldName(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldName.name);
  }

  /**
   * Поле ввода объекта сущности "DummyOneToMany".
   * @type {AbstractControl}
   */
  get fieldObjectDummyOneToMany(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldObjectDummyOneToMany.name);
  }

  /**
   * Построить.
   * @param {FormGroup} formGroup Группа полей формы.
   */
  build(
    formGroup: FormGroup
  ) {
    this.formGroup = formGroup;
  }

  /**
   * Получить признак отключения кнопки удаления списка.
   * @returns {boolean} Признак отключения кнопки удаления списка.
   */
  getItemsDeleteButtonIsDisabled(): boolean {
    return this.isActionStarted;
  }

  /**
   * Получить признак отключения кнопки фильтрации.
   * @returns {boolean} Признак отключения кнопки фильтрации.
   */
  getFilterButtonIsDisabled(): boolean {
    return this.isActionStarted
      || (
        this.paramNameValue === this.fieldName.value
        && this.paramObjectDummyOneToManyIdValue === this.fieldObjectDummyOneToMany.value
      );
  }

  /**
   * Получить признак отключения кнопки отмены фильтрации.
   * @returns {boolean} Признак отключения кнопки отмены фильтрации.
   */
  getFilterCancelButtonIsDisabled(): boolean {
    return this.isActionStarted
      || (
        !this.fieldName.value
        && !this.fieldObjectDummyOneToMany.value
      );
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
   * Получить выбранный элемент.
   * @returns {AppModDummyMainPageListDataItem} Выбранный элемент.
   */
  abstract getSelectedItem(): AppModDummyMainPageListDataItem;

  /**
   * Получить выбранные элементы.
   * @returns {AppModDummyMainPageListDataItem[]} Выбранные элементы.
   */
  abstract getSelectedItems(): AppModDummyMainPageListDataItem[];

  /**
   * Получить признак отключения кнопки отмены сортировки.
   * @returns {boolean} Признак отключения кнопки отмены сортировки.
   */
  getSortCancelButtonIsDisabled(): boolean {
    return this.isActionStarted || !this.isSortApplied;
  }

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

  /**
   * Получить данные.
   * @return {AppModDummyMainPageListDataItem[]}
   */
  abstract getData(): AppModDummyMainPageListDataItem[];

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
   * Загрузить варианты выбора сущности "DummyOneToMany".
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

  /**
   * Установить идентификаторы выбранных элементов.
   * @param {number[]} value Значение.
   */
  abstract setSelectedItemIds(value: number[]);

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();

  /**
   * Подписаться на событие переключения флажка в заголовке.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnHeaderCheckboxToggle(callback: () => void);

  /**
   * Подписаться на событие выбора строки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnRowSelect(callback: () => void);

  /**
   * Подписаться на событие отмены выбора строки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract subscribeOnRowUnselect(callback: () => void);

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
