// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageItemConfigKey,
  appModDummyTreePageItemCreateConfigKey,
  appModDummyTreePageItemEditConfigKey,
  appModDummyTreePageItemViewConfigKey
} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-config';

/** Мод "DummyTree". Страницы. Элемент. Настройки. Ключи. */
export class AppModDummyTreePageItemSettingKeys {

  /**
   * Ключ страницы "Создание".
   * @type {string}
   */
  get keyCreate(): string {
    return appModDummyTreePageItemCreateConfigKey;
  }

  /**
   * Ключ страницы "Редактирование".
   * @type {string}
   */
  get keyEdit(): string {
   return appModDummyTreePageItemEditConfigKey;
  }

  /**
   * Ключ страницы "Просмотр".
   * @type {string}
   */
  get keyView(): string {
    return appModDummyTreePageItemViewConfigKey;
  }
}
