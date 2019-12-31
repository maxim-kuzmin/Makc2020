// //Author Maxim Kuzmin//makc//

// tslint:disable-next-line:max-line-length
import {appModAuthPageRedirectConfigFullPath, appModAuthPageRedirectConfigKey} from '@app/mods/auth/pages/redirect/mod-auth-page-redirect-config';

/** Мод "Auth". Страницы. Перенаправление. Настройки. */
export class AppModAuthPageRedirectSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Перенаправление';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModAuthPageRedirectConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModAuthPageRedirectConfigFullPath;
  }
}
