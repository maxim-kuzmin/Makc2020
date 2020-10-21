// //Author Maxim Kuzmin//makc//

import {appRootPageAdministrationConfigFullPath, appRootPageAdministrationConfigKey} from './root-page-administration-config';

/** Корень. Страницы. Администрирование. Настройки. */
export class AppRootPageAdministrationSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Администрирование';

  /**
   * Заголовок страницы "ModDummyMainPageIndex".
   * @type {string}
   */
  titleOfModDummyMainPageIndexResourceKey = 'Сущность DummyMain';

  /**
   * Заголовок страницы "ModDummyTreePageIndex".
   * @type {string}
   */
  titleOfModDummyTreePageIndexResourceKey = 'Сущность DummyTree';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appRootPageAdministrationConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appRootPageAdministrationConfigFullPath;
  }
}
