// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageIndexConfigFullPath,
  appModDummyTreePageIndexConfigKey
} from '@app/mods/dummy-tree/pages/index/mod-dummy-tree-page-index-config';
import {
  appModDummyTreePageItemCreateConfigTitleResourceKey,
  appModDummyTreePageItemEditConfigTitleResourceKey,
  appModDummyTreePageItemViewConfigTitleResourceKey
} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-config';
import {appModDummyTreePageListConfigTitleResourceKey} from '@app/mods/dummy-tree/pages/list/mod-dummy-tree-page-list-config';

/** Мод "DummyTree". Страницы. Начало. Настройки. */
export class AppModDummyTreePageIndexSettings {

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
    return appModDummyTreePageIndexConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModDummyTreePageIndexConfigFullPath;
  }

  /**
   * Заголовок страницы "ModDummyTreePageItemCreate".
   * @type {string}
   */
  get titleOfModDummyTreePageItemCreateResourceKey(): string {
    return appModDummyTreePageItemCreateConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModDummyTreePageItemEdit".
   * @type {string}
   */
  get titleOfModDummyTreePageItemEditResourceKey(): string {
    return appModDummyTreePageItemEditConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModDummyTreePageItemView".
   * @type {string}
   */
  get titleOfModDummyTreePageItemViewResourceKey(): string {
    return appModDummyTreePageItemViewConfigTitleResourceKey;
  }

  /**
   * Заголовок страницы "ModDummyTreePageList".
   * @type {string}
   */
  get titleOfModDummyTreePageListResourceKey(): string {
    return appModDummyTreePageListConfigTitleResourceKey;
  }
}
