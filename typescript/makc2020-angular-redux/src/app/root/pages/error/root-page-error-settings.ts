// //Author Maxim Kuzmin//makc//

import {appRootPageErrorConfigFullPath, appRootPageErrorConfigKey} from './root-page-error-config';

/** Корень. Страницы. Ошибка. Настройки. */
export class AppRootPageErrorSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Ошибка';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appRootPageErrorConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appRootPageErrorConfigFullPath;
  }
}
