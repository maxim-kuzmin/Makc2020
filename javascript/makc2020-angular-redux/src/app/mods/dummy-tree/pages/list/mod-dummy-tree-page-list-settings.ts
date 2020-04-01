// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageListConfigFullPath,
  appModDummyTreePageListConfigIndex,
  appModDummyTreePageListConfigKey
} from './mod-dummy-tree-page-list-config';
import {AppModDummyTreePageListSettingActions} from './settings/mod-dummy-tree-page-list-setting-actions';
import {AppModDummyTreePageListSettingColumns} from './settings/mod-dummy-tree-page-list-setting-columns';

/** Мод "DummyTree". Страницы. Список. Настройки. */
export class AppModDummyTreePageListSettings {

  /**
   * Действия.
   * @type {AppModDummyTreePageListSettingActions}
   */
  actions = new AppModDummyTreePageListSettingActions();

  /**
   * Столбцы.
   * @type {AppModDummyTreePageListSettingColumns}
   */
  columns = new AppModDummyTreePageListSettingColumns();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Список';

  /**
   * Индекс.
   * @type {string}
   */
  get index(): string {
    return appModDummyTreePageListConfigIndex;
  }

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModDummyTreePageListConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModDummyTreePageListConfigFullPath;
  }
}
