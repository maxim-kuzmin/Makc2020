// //Author Maxim Kuzmin//makc//

import {AbstractControl, FormGroup} from '@angular/forms';
import {AppModDummyMainJobItemGetOutput} from '../../jobs/item/get/mod-dummy-main-job-item-get-output';
import {
  AppModDummyMainCommonJobOptionsGetOutputList,
  appModDummyMainCommonJobOptionsGetOutputListCreate
} from '../../common/jobs/options/get/output/mod-dummy-main-common-job-options-get-output-list';
import {AppModDummyMainPageItemSettingErrors} from './settings/mod-dummy-main-page-item-setting-errors';
import {AppModDummyMainPageItemSettingFields} from './settings/mod-dummy-main-page-item-setting-fields';

/** Мод "DummyMain". Страницы. Элемент. Вид. */
export abstract class AppModDummyMainPageItemView {

  /**
   * Данные.
   * @type {AppModDummyMainJobItemGetOutput}
   */
  data: AppModDummyMainJobItemGetOutput;

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
   * Признак того, что изменение данных разрешено.
   * @type {boolean}
   */
  isDataChangeAllowed = false;

  /**
   * Варианты выбора сущности "DummyManyToMany".
   * @type {AppModDummyMainCommonJobOptionsGetOutputList}
   */
  optionsDummyManyToMany: AppModDummyMainCommonJobOptionsGetOutputList;

  /**
   * Варианты выбора сущности "DummyOneToMany".
   * @type {AppModDummyMainCommonJobOptionsGetOutputList}
   */
  optionsDummyOneToMany: AppModDummyMainCommonJobOptionsGetOutputList;

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
   * Значение свойства "disabled" кнопки отправки.
   * @type {boolean}
   */
  get buttonSubmitDisabled(): boolean {
    return !this.formGroup.valid || this.isActionStarted;
  }

  /**
   * Поле ввода идентификатора.
   * @type {AbstractControl}
   */
  get fieldId(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldId.name);
  }

  /**
   * Поле ввода имени.
   * @type {AbstractControl}
   */
  get fieldName(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldName.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода имени видима.
   * @type {boolean}
   */
  get fieldNameErrorRequiredVisible() {
    const control = this.fieldName;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Поле ввода объекта сущности "DummyOneToMany".
   * @type {AbstractControl}
   */
  get fieldObjectDummyOneToMany(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldObjectDummyOneToMany.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода объекта сущности "DummyOneToMany" видима.
   * @type {boolean}
   */
  get fieldObjectDummyOneToManyErrorRequiredVisible() {
    const control = this.fieldObjectDummyOneToMany;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Конструктор.
   * @param {AppModDummyMainPageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModDummyMainPageItemSettingFields} settingFields Настройка полей.
   */
  protected constructor(
    private settingErrors: AppModDummyMainPageItemSettingErrors,
    private settingFields: AppModDummyMainPageItemSettingFields
  ) {
    this.loadOptionsDummyManyToMany();
    this.loadOptionsDummyOneToMany();
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
   * Загрузить сообщения об ошибках отклика.
   * @param {string[]} messages Сообщения.
   */
  loadResponseErrorMessages(messages: string[]) {
    if (messages && messages.length > 0) {
      if (!this.responseErrorMessages) {
        this.responseErrorMessages = [];
      }

      this.responseErrorMessages = this.responseErrorMessages.concat(messages);
    } else {
      this.responseErrorMessages = messages;
    }
  }

  /**
   * Загрузить сообщения об успехах отклика.
   * @param {string[]} messages Сообщения.
   */
  loadResponseSuccessMessages(messages: string[]) {
    if (messages && messages.length > 0) {
      if (!this.responseSuccessMessages) {
        this.responseSuccessMessages = [];
      }

      this.responseSuccessMessages = this.responseSuccessMessages.concat(messages);
    } else {
      this.responseSuccessMessages = messages;
    }
  }

  /**
   * Загрузить варианты выбора сущности "DummyManyToMany".
   * @param {AppModDummyMainCommonJobOptionsGetOutputList} data Данные.
   */
  loadOptionsDummyManyToMany(data?: AppModDummyMainCommonJobOptionsGetOutputList) {
    this.optionsDummyManyToMany = data
      ? data
      : appModDummyMainCommonJobOptionsGetOutputListCreate();
  }

  /**
   * Загрузить варианты выбора сущности "DummyOneToMany".
   * @param {AppModDummyMainCommonJobOptionsGetOutputList} data Данные.
   */
  loadOptionsDummyOneToMany(data?: AppModDummyMainCommonJobOptionsGetOutputList) {
    this.optionsDummyOneToMany = data
      ? data
      : appModDummyMainCommonJobOptionsGetOutputListCreate();
  }

  /** Сбросить форму. */
  abstract resetForm();

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();
}
