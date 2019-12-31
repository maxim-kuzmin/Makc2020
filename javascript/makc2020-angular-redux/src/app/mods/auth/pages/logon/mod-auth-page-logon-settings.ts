// //Author Maxim Kuzmin//makc//

import {appModAuthPageLogonConfigFullPath, appModAuthPageLogonConfigKey} from './mod-auth-page-logon-config';
import {AppModAuthPageLogonSettingButtons} from './settings/mod-auth-page-logon-setting-buttons';
import {AppModAuthPageLogonSettingErrors} from './settings/mod-auth-page-logon-setting-errors';
import {AppModAuthPageLogonSettingFields} from './settings/mod-auth-page-logon-setting-fields';

/** Мод "Auth". Страницы. Вход в систему. Настройки. */
export class AppModAuthPageLogonSettings {

  /**
   * Кнопки.
   * @type {AppModAuthPageLogonSettingButtons}
   */
  buttons = new AppModAuthPageLogonSettingButtons();

  /**
   * Ошибки.
   * @type {AppModAuthPageLogonSettingErrors}
   */
  errors = new AppModAuthPageLogonSettingErrors();

  /**
   * Поля.
   * @type {AppModAuthPageLogonSettingFields}
   */
  fields = new AppModAuthPageLogonSettingFields();

  /** Сообщения. */
  messages = {
    loggedInResourceKey: 'Вход в систему произведён под учётной записью',
    passwordInfoResourceKey: 'Пароль должен содержать не менее 12 символов, среди которых должно быть не менее 2-х цифр и не менее одного символа, не являющегося цифрой или буквой'
  };

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Вход в систему';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModAuthPageLogonConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModAuthPageLogonConfigFullPath;
  }
}
