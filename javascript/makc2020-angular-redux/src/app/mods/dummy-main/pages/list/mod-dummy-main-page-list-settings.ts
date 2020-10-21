// //Author Maxim Kuzmin//makc//

import {
  appModDummyMainPageListConfigFullPath,
  appModDummyMainPageListConfigIndex,
  appModDummyMainPageListConfigKey
} from './mod-dummy-main-page-list-config';
import {AppModDummyMainPageListSettingActions} from './settings/mod-dummy-main-page-list-setting-actions';
import {AppModDummyMainPageListSettingColumns} from './settings/mod-dummy-main-page-list-setting-columns';
import {AppModDummyMainPageListSettingFields} from './settings/mod-dummy-main-page-list-setting-fields';

/** Мод "DummyMain". Страницы. Список. Настройки. */
export class AppModDummyMainPageListSettings {

  /**
   * Действия.
   * @type {AppModDummyMainPageListSettingActions}
   */
  actions = new AppModDummyMainPageListSettingActions();

  /**
   * Столбцы.
   * @type {AppModDummyMainPageListSettingColumns}
   */
  columns = new AppModDummyMainPageListSettingColumns();

  /**
   * Поля.
   * @type {AppModDummyMainPageListSettingFields}
   */
  fields = new AppModDummyMainPageListSettingFields();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Объекты сущности DummyMain'; // 'Список';

  /**
   * Индекс.
   * @type {string}
   */
  get index(): string {
    return appModDummyMainPageListConfigIndex;
  }

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModDummyMainPageListConfigKey;
  }

  /**
   * Путь.
   * @type {string}
   */
  get path(): string {
    return appModDummyMainPageListConfigFullPath;
  }
}
