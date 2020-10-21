// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageListConfigFullPath,
  appModDummyTreePageListConfigIndex,
  appModDummyTreePageListConfigKey
} from './mod-dummy-tree-page-list-config';
import {AppModDummyTreePageListSettingActions} from './settings/mod-dummy-tree-page-list-setting-actions';
import {AppModDummyTreePageListSettingColumns} from './settings/mod-dummy-tree-page-list-setting-columns';
import {AppModDummyTreePageListSettingFields} from './settings/mod-dummy-tree-page-list-setting-fields';

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
   * Поля.
   * @type {AppModDummyTreePageListSettingFields}
   */
  fields = new AppModDummyTreePageListSettingFields();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Объекты сущности DummyTree'; // 'Список';

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
