// //Author Maxim Kuzmin//makc//

import {
  appModDummyMainPageItemConfigKey,
  appModDummyMainPageItemCreateConfigKey,
  appModDummyMainPageItemEditConfigKey,
  appModDummyMainPageItemViewConfigKey
} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-config';

/** Мод "DummyMain". Страницы. Элемент. Настройки. Ключи. */
export class AppModDummyMainPageItemSettingKeys {

  /**
   * Ключ страницы "Создание".
   * @type {string}
   */
  get keyCreate(): string {
    return appModDummyMainPageItemCreateConfigKey;
  }

  /**
   * Ключ страницы "Редактирование".
   * @type {string}
   */
  get keyEdit(): string {
   return appModDummyMainPageItemEditConfigKey;
  }

  /**
   * Ключ страницы "Просмотр".
   * @type {string}
   */
  get keyView(): string {
    return appModDummyMainPageItemViewConfigKey;
  }
}
