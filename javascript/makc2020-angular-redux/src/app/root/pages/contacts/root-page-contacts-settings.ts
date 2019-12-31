// //Author Maxim Kuzmin//makc//

import {appRootPageContactsConfigFullPath, appRootPageContactsConfigKey} from './root-page-contacts-config';

/** Корень. Страницы. Контакты. Настройки. */
export class AppRootPageContactsSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Контакты';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appRootPageContactsConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appRootPageContactsConfigFullPath;
  }
}
