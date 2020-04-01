// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageItemConfigKey
} from './mod-dummy-tree-page-item-config';
import {AppModDummyTreePageItemSettingActions} from './settings/mod-dummy-tree-page-item-setting-actions';
import {AppModDummyTreePageItemSettingButtons} from './settings/mod-dummy-tree-page-item-setting-buttons';
import {AppModDummyTreePageItemSettingErrors} from './settings/mod-dummy-tree-page-item-setting-errors';
import {AppModDummyTreePageItemSettingFields} from './settings/mod-dummy-tree-page-item-setting-fields';
import {AppModDummyTreePageItemSettingPaths} from '@app/mods/dummy-tree/pages/item/settings/mod-dummy-tree-page-item-setting-paths';
import {AppModDummyTreePageItemSettingKeys} from '@app/mods/dummy-tree/pages/item/settings/mod-dummy-tree-page-item-setting-keys';

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
   * Ключ.
   * @type {string}
   */
  get key(): string {
    return appModDummyTreePageItemConfigKey;
  }

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
  titleResourceKey = 'Элемент';

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
}
