// //Author Maxim Kuzmin//makc//

import {AbstractControl, FormGroup} from '@angular/forms';
import {AppModDummyTreeJobItemGetOutput} from '../../jobs/item/get/mod-dummy-tree-job-item-get-output';
import {AppModDummyTreePageItemSettingErrors} from './settings/mod-dummy-tree-page-item-setting-errors';
import {AppModDummyTreePageItemSettingFields} from './settings/mod-dummy-tree-page-item-setting-fields';

/** Мод "DummyTree". Страницы. Элемент. Вид. */
export abstract class AppModDummyTreePageItemView {

  /**
   * Данные.
   * @type {AppModDummyTreeJobItemGetOutput}
   */
  data: AppModDummyTreeJobItemGetOutput;

  /**
   * Группа полей формы.
   * @type {FormGroup}
   */
  formGroup: FormGroup;

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
    return !this.formGroup.valid;
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
   * Конструктор.
   * @param {AppModDummyTreePageItemSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModDummyTreePageItemSettingFields} settingFields Настройка полей.
   */
  protected constructor(
    private settingErrors: AppModDummyTreePageItemSettingErrors,
    private settingFields: AppModDummyTreePageItemSettingFields
  ) {
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

  /** Сбросить форму. */
  abstract resetForm();

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();
}
