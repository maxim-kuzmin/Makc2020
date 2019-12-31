// //Author Maxim Kuzmin//makc//

import {appRootPageSiteConfigFullPath, appRootPageSiteConfigKey} from './root-page-site-config';

/** Корень. Страницы. Сайт. Настройки. */
export class AppRootPageSiteSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Сайт';

  /**
   * Заголовок страницы "ModAuthPageIndex".
   * @type {string}
   */
  titleOfModAuthPageIndexResourceKey = 'Аутентификация';

  /**
   * Заголовок страницы "RootPageContacts".
   * @type {string}
   */
  titleOfRootPageContactsResourceKey = 'Контакты';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appRootPageSiteConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appRootPageSiteConfigFullPath;
  }
}
