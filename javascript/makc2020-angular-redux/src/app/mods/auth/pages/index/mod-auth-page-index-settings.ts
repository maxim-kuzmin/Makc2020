// //Author Maxim Kuzmin//makc//

import {appModAuthPageIndexConfigFullPath, appModAuthPageIndexConfigKey} from '@app/mods/auth/pages/index/mod-auth-page-index-config';
import {appModAuthPageLogonConfigTitleResourceKey} from '@app/mods/auth/pages/logon/mod-auth-page-logon-config';
import {appModAuthPageRegisterConfigTitleResourceKey} from '@app/mods/auth/pages/register/mod-auth-page-register-config';

/** Мод "Auth". Страницы. Начало. Настройки. */
export class AppModAuthPageIndexSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Начало';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModAuthPageIndexConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModAuthPageIndexConfigFullPath;
  }

  /**
   * Заголовок страницы "ModAuthPageLogon".
   * @type {string}
   */
  get titleOfModAuthPageLogonResourceKey(): string {
    return appModAuthPageLogonConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModAuthPageRegister".
   * @type {string}
   */
  get titleOfModAuthPageRegisterResourceKey(): string {
    return appModAuthPageRegisterConfigTitleResourceKey;
  }
}
