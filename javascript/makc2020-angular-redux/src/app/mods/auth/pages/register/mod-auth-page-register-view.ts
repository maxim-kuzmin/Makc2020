// //Author Maxim Kuzmin//makc//

import {AbstractControl, FormGroup} from '@angular/forms';
import {AppModAuthPageRegisterSettingErrors} from '../register/settings/mod-auth-page-register-setting-errors';
import {AppModAuthPageRegisterSettingFields} from '../register/settings/mod-auth-page-register-setting-fields';

/** Мод "Auth". Страницы. Регистрация. Вид. */
export abstract class AppModAuthPageRegisterView {

  /**
   * Группа полей формы.
   * @type {FormGroup}
   */
  formGroup: FormGroup;

  /**
   * Признак того, что пароль скрыт.
   * @type {boolean}
   */
  isPasswordHidden = true;

  /**
   * Признак того, что подтверждение пароля скрыто.
   * @type {boolean}
   */
  isPasswordConfirmHidden = true;

  /**
   * Сообщения об ошибках запроса.
   * @type {string[]}
   */
  requestErrorMessages: string[] = [];

  /**
   * Сообщения об ошибках запроса.
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
   * Поле ввода e-mail.
   * @type {AbstractControl}
   */
  get fieldEmail(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldEmail.name);
  }

  /**
   * Признак того, что ошибка валидации правильности ввода e-mail видима.
   * @type {boolean}
   */
  get fieldEmailErrorEmailVisible() {
    const control = this.fieldEmail;

    return control.dirty && control.hasError(this.settingErrors.errorEmail.code);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода e-mail видима.
   * @type {boolean}
   */
  get fieldEmailErrorRequiredVisible() {
    const control = this.fieldEmail;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Поле ввода Ф.И.О.
   * @type {AbstractControl}
   */
  get fieldFullName(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldFullName.name);
  }

  /**
   * Поле ввода пароля.
   * @type {AbstractControl}
   */
  get fieldPassword(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldPassword.name);
  }

  /**
   * Иконка поля ввода пароля.
   * @type {string}
   */
  get fieldPasswordIcon() {
    const {visibility} = this.settingFields.fieldPassword;

    return this.isPasswordHidden ? visibility.off.icon : visibility.on.icon;
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода пароля видима.
   * @type {boolean}
   */
  get fieldPasswordErrorRequiredVisible() {
    const control = this.fieldPassword;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Тип поля ввода пароля.
   * @type {string}
   */
  get fieldPasswordType() {
    const {visibility} = this.settingFields.fieldPassword;

    return this.isPasswordHidden ? visibility.off.type : visibility.on.type;
  }

  /**
   * Поле ввода подтверждения пароля.
   * @type {AbstractControl}
   */
  get fieldPasswordConfirm(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldPasswordConfirm.name);
  }

  /**
   * Иконка поля ввода подтверждения пароля.
   * @type {string}
   */
  get fieldPasswordConfirmIcon() {
    const {visibility} = this.settingFields.fieldPasswordConfirm;

    return this.isPasswordConfirmHidden ? visibility.off.icon : visibility.on.icon;
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода подтверждения пароля видима.
   * @type {boolean}
   */
  get fieldPasswordConfirmErrorRequiredVisible() {
    const control = this.fieldPasswordConfirm;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Тип поля ввода подтверждения пароля.
   * @type {string}
   */
  get fieldPasswordConfirmType() {
    const {visibility} = this.settingFields.fieldPasswordConfirm;

    return this.isPasswordConfirmHidden ? visibility.off.type : visibility.on.type;
  }

  /**
   * Поле ввода имени пользователя.
   * @type {AbstractControl}
   */
  get fieldUserName(): AbstractControl {
    return this.formGroup.get(this.settingFields.fieldUserName.name);
  }

  /**
   * Признак того, что ошибка валидации обязательности ввода имени пользователя видима.
   * @type {boolean}
   */
  get fieldUserNameErrorRequiredVisible() {
    const control = this.fieldUserName;

    return control.dirty && control.hasError(this.settingErrors.errorRequired.code);
  }

  /**
   * Конструктор.
   * @param {AppModAuthPageRegisterSettingErrors} settingErrors Ресурсы.
   * @param {AppModAuthPageRegisterSettingFields} settingFields Настройки.
   */
  protected constructor(
    private settingErrors: AppModAuthPageRegisterSettingErrors,
    private settingFields: AppModAuthPageRegisterSettingFields,
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

  /** Обработчик события нажатия на иконку поля ввода пароля. */
  fieldPasswordIconOnClick() {
    this.isPasswordHidden = !this.isPasswordHidden;
  }

  /** Обработчик события нажатия на иконку поля ввода подтверждения пароля. */
  fieldPasswordConfirmIconOnClick() {
    this.isPasswordConfirmHidden = !this.isPasswordConfirmHidden;
  }

  /** Спрятать спиннер обновления. */
  abstract hideRefreshSpinner();

  /** Инициализировать спиннер обновления. */
  abstract initRefreshSpinner();

  /** Сбросить форму. */
  abstract resetForm();

  /** Показать спиннер обновления. */
  abstract showRefreshSpinner();
}
