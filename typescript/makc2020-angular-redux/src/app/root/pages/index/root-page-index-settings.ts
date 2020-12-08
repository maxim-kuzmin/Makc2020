// //Author Maxim Kuzmin//makc//

import {appRootPageIndexConfigFullPath, appRootPageIndexConfigKey} from './root-page-index-config';

/** Корень. Страницы. Начало. Настройки. */
export class AppRootPageIndexSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = ''; // 'Начало';

  /**
   * Заголовок страницы "RootPageAdministration".
   * @type {string}
   */
  titleOfRootPageAdministrationResourceKey = 'Администрирование';

  /**
   * Заголовок страницы "RootPageSite".
   * @type {string}
   */
  titleOfRootPageSiteResourceKey = 'Сайт';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appRootPageIndexConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appRootPageIndexConfigFullPath;
  }
}
