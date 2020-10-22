// //Author Maxim Kuzmin//makc//

import {
  appModDummyMainPageIndexConfigFullPath,
  appModDummyMainPageIndexConfigKey
} from '@app/mods/dummy-main/pages/index/mod-dummy-main-page-index-config';
import {appModDummyMainPageItemCreateConfigTitleResourceKey} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-config';
import {appModDummyMainPageListConfigTitleResourceKey} from '@app/mods/dummy-main/pages/list/mod-dummy-main-page-list-config';

/** Мод "DummyMain". Страницы. Начало. Настройки. */
export class AppModDummyMainPageIndexSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = ''; // 'Начало';

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModDummyMainPageIndexConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModDummyMainPageIndexConfigFullPath;
  }

  /**
   * Заголовок страницы "ModDummyMainPageItemCreate".
   * @type {string}
   */
  get titleOfModDummyMainPageItemCreateResourceKey(): string {
    return appModDummyMainPageItemCreateConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModDummyMainPageList".
   * @type {string}
   */
  get titleOfModDummyMainPageListResourceKey(): string {
    return appModDummyMainPageListConfigTitleResourceKey;
  }
}
