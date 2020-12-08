// //Author Maxim Kuzmin//makc//

import {
  appModDummyMainPageItemCreateConfigFullPath,
  appModDummyMainPageItemEditConfigFullPath,
  appModDummyMainPageItemViewConfigFullPath
} from '@app/mods/dummy-main/pages/item/mod-dummy-main-page-item-config';

/** Мод "DummyMain". Страницы. Элемент. Настройки. Пути. */
export class AppModDummyMainPageItemSettingPaths {

  /**
   * Путь страницы "Создание".
   * @type {string}
   */
  get pathCreate(): string {
    return appModDummyMainPageItemCreateConfigFullPath;
  }

  /**
   * Путь страницы "Редактирование".
   * @type {string}
   */
  get pathEdit(): string {
   return appModDummyMainPageItemEditConfigFullPath;
  }

  /**
   * Путь страницы "Просмотр".
   * @type {string}
   */
  get pathView(): string {
    return appModDummyMainPageItemViewConfigFullPath;
  }
}
