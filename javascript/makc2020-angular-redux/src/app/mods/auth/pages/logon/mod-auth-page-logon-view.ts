// //Author Maxim Kuzmin//makc//

import {AbstractControl, FormGroup} from '@angular/forms';
import {AppModAuthPageLogonSettingErrors} from './settings/mod-auth-page-logon-setting-errors';
import {AppModAuthPageLogonSettingFields} from './settings/mod-auth-page-logon-setting-fields';
import {AppModAuthPageLogonResourceButtons} from './resources/mod-auth-page-logon-resource-buttons';

/** Мод "Auth". Страницы. Вход в систему. Вид. */
export abstract class AppModAuthPageLogonView {

  /** @type {AppModAuthPageLogonResourceButtons} */
  private resourceButtons: AppModAuthPageLogonResourceButtons;

  /**
   * Группа полей формы.
   * @type {FormGroup}
   */
  formGroup: FormGroup;

  /**
   * Признак того, что вход в систему выполнен.
   * @type {boolean}
   */
  isLoggedIn = false;

  /**
   * Признак того, что пароль скрыт.
   * @type {boolean}
   */
  isPasswordHidden = true;

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
   * Имя пользователя.
   * @type {string}
   */
  userName: string;

  /**
   * Значение свойства "disabled" кнопки отправки.
   * @type {boolean}
   */
  get buttonSubmitDisabled(): boolean {
    return !this.isLoggedIn && !this.formGroup.valid;
  }

  /**
   * Заголовок кнопки отправки.
   * @type {string}
   */
  get buttonSubmitTitle(): string {
    return this.isLoggedIn ? this.resourceButtons.buttonLogout.title : this.resourceButtons.buttonLogin.title;
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
    const {
      visibility
    } = this.settingFields.fieldPassword;

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
    const {
      visibility
    } = this.settingFields.fieldPassword;

    return this.isPasswordHidden ? visibility.off.type : visibility.on.type;
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
   * @param {AppModAuthPageLogonSettingErrors} settingErrors Настройка ошибок.
   * @param {AppModAuthPageLogonSettingFields} settingFields Настройка полей.
   */
  protected constructor(
    private settingErrors: AppModAuthPageLogonSettingErrors,
    private settingFields: AppModAuthPageLogonSettingFields
  ) {
  }

  /**
   * Построить.
   * @param {FormGroup} formGroup Группа полей формы.
   * @param {AppModAuthPageLogonResourceButtons} resourceButtons Ресурс кнопок.
   */
  build(
    formGroup: FormGroup,
    resourceButtons: AppModAuthPageLogonResourceButtons
  ) {
    this.resourceButtons = resourceButtons;
    this.formGroup = formGroup;
  }

  /** Обработчик события нажатия на иконку поля ввода пароля. */
  fieldPasswordIconOnClick() {
    this.isPasswordHidden = !this.isPasswordHidden;
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
