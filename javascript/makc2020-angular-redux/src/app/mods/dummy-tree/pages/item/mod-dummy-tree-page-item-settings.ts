// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageItemConfigKey
} from './mod-dummy-tree-page-item-config';
import {AppModDummyTreePageItemSettingActions} from './settings/mod-dummy-tree-page-item-setting-actions';
import {AppModDummyTreePageItemSettingButtons} from './settings/mod-dummy-tree-page-item-setting-buttons';
import {AppModDummyTreePageItemSettingErrors} from './settings/mod-dummy-tree-page-item-setting-errors';
import {AppModDummyTreePageItemSettingFields} from './settings/mod-dummy-tree-page-item-setting-fields';
import {AppModDummyTreePageItemSettingKeys} from './settings/mod-dummy-tree-page-item-setting-keys';
import {AppModDummyTreePageItemSettingPaths} from './settings/mod-dummy-tree-page-item-setting-paths';
import {appModDummyMainPageItemConfigIndex} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-config';

/** Мод "DummyTree". Страницы. Элемент. Настройки. */
export class AppModDummyTreePageItemSettings {

  /**
   * Действия.
   * @type {AppModDummyTreePageItemSettingActions}
   */
  actions = new AppModDummyTreePageItemSettingActions();

  /**
   * Кнопки.
   * @type {AppModDummyTreePageItemSettingButtons}
   */
  buttons = new AppModDummyTreePageItemSettingButtons();

  /**
   * Ошибки.
   * @type {AppModDummyTreePageItemSettingErrors}
   */
  errors = new AppModDummyTreePageItemSettingErrors();

  /**
   * Поля.
   * @type {AppModDummyTreePageItemSettingFields}
   */
  fields = new AppModDummyTreePageItemSettingFields();

  /**
   * Ключи.
   * @type {AppModDummyTreePageItemSettingKeys}
   */
  keys = new AppModDummyTreePageItemSettingKeys();

  /**
   * Пути.
   * @type {AppModDummyTreePageItemSettingPaths}
   */
  paths = new AppModDummyTreePageItemSettingPaths();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Объект сущности DummyTree'; // 'Элемент';

  /**
   * Заголовок страницы "ModDummyTreePageItemCreate".
   * @type {string}
   */
  titleOfModDummyTreePageItemCreateResourceKey = 'Создать';

  /**
   * Заголовок страницы "ModDummyTreePageItemEdit".
   * @type {string}
   */
  titleOfModDummyTreePageItemEditResourceKey = 'Изменить';

  /**
   * Заголовок страницы "ModDummyTreePageItemView".
   * @type {string}
   */
  titleOfModDummyTreePageItemViewResourceKey = 'Просмотреть';

  /**
   * Индекс.
   * @type {string}
   */
  get index(): string {
    return appModDummyMainPageItemConfigIndex;
  }

  /**
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModDummyTreePageItemConfigKey;
  }
}
