// //Author Maxim Kuzmin//makc//

import {
  appModDummyMainPageItemConfigIndex,
  appModDummyMainPageItemConfigKey
} from './mod-dummy-main-page-item-config';
import {AppModDummyMainPageItemSettingActions} from './settings/mod-dummy-main-page-item-setting-actions';
import {AppModDummyMainPageItemSettingButtons} from './settings/mod-dummy-main-page-item-setting-buttons';
import {AppModDummyMainPageItemSettingErrors} from './settings/mod-dummy-main-page-item-setting-errors';
import {AppModDummyMainPageItemSettingFields} from './settings/mod-dummy-main-page-item-setting-fields';
import {AppModDummyMainPageItemSettingPaths} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-paths';
import {AppModDummyMainPageItemSettingKeys} from '@app/mods/dummy-main/pages/item/settings/mod-dummy-main-page-item-setting-keys';

/** Мод "DummyMain". Страницы. Элемент. Настройки. */
export class AppModDummyMainPageItemSettings {

  /**
   * Действия.
   * @type {AppModDummyMainPageItemSettingActions}
   */
  actions = new AppModDummyMainPageItemSettingActions();

  /**
   * Кнопки.
   * @type {AppModDummyMainPageItemSettingButtons}
   */
  buttons = new AppModDummyMainPageItemSettingButtons();

  /**
   * Ошибки.
   * @type {AppModDummyMainPageItemSettingErrors}
   */
  errors = new AppModDummyMainPageItemSettingErrors();

  /**
   * Поля.
   * @type {AppModDummyMainPageItemSettingFields}
   */
  fields = new AppModDummyMainPageItemSettingFields();

  /**
   * Ключи.
   * @type {AppModDummyMainPageItemSettingKeys}
   */
  keys = new AppModDummyMainPageItemSettingKeys();

  /**
   * Пути.
   * @type {AppModDummyMainPageItemSettingPaths}
   */
  paths = new AppModDummyMainPageItemSettingPaths();

  /**
   * Заголовок.
   * @type {string}
   */
  titleResourceKey = 'Объект сущности "DummyMain"'; // 'Элемент';

  /**
   * Заголовок страницы "ModDummyMainPageItemCreate".
   * @type {string}
   */
  titleOfModDummyMainPageItemCreateResourceKey = 'Создать';

  /**
   * Заголовок страницы "ModDummyMainPageItemEdit".
   * @type {string}
   */
  titleOfModDummyMainPageItemEditResourceKey = 'Изменить';

  /**
   * Заголовок страницы "ModDummyMainPageItemView".
   * @type {string}
   */
  titleOfModDummyMainPageItemViewResourceKey = 'Просмотреть';

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
    return appModDummyMainPageItemConfigKey;
  }
}
