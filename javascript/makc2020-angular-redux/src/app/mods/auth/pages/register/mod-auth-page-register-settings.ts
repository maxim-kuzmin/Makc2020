// //Author Maxim Kuzmin//makc//

import {appModAuthPageRegisterConfigFullPath, appModAuthPageRegisterConfigKey} from './mod-auth-page-register-config';
import {AppModAuthPageRegisterSettingButtons} from './settings/mod-auth-page-register-setting-buttons';
import {AppModAuthPageRegisterSettingErrors} from './settings/mod-auth-page-register-setting-errors';
import {AppModAuthPageRegisterSettingFields} from './settings/mod-auth-page-register-setting-fields';

/** Мод "Auth". Страницы. Регистрация. Настройки. */
export class AppModAuthPageRegisterSettings {

  /**
   * Кнопки.
   * @type {AppModAuthPageRegisterSettingButtons}
   */
  buttons = new AppModAuthPageRegisterSettingButtons();

  /**
   * Ошибки.
   * @type {AppModAuthPageRegisterSettingErrors}
   */
  errors = new AppModAuthPageRegisterSettingErrors();

  /**
   * Поля.
   * @type {AppModAuthPageRegisterSettingFields}
   */
  fields = new AppModAuthPageRegisterSettingFields();

  /** Сообщения. */
  messages = {
    // tslint:disable-next-line:max-line-length
    passwordInfoResourceKey: 'Пароль должен содержать не менее 12 символов, среди которых должно быть не менее 2-х цифр и не менее одного символа, не являющегося цифрой или буквой'
  };

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Регистрация';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModAuthPageRegisterConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModAuthPageRegisterConfigFullPath;
  }
}
