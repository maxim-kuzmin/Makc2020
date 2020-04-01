// //Author Maxim Kuzmin//makc//

import {
  appModDummyTreePageItemCreateConfigFullPath,
  appModDummyTreePageItemEditConfigFullPath,
  appModDummyTreePageItemViewConfigFullPath
} from '@app/mods/dummy-tree/pages/item/mod-dummy-tree-page-item-config';

/** Мод "DummyTree". Страницы. Элемент. Настройки. Пути. */
export class AppModDummyTreePageItemSettingPaths {

  /**
   * Путь страницы "Создание".
   * @type {string}
   */
  get pathCreate(): string {
    return appModDummyTreePageItemCreateConfigFullPath;
  }

  /**
   * Путь страницы "Редактирование".
   * @type {string}
   */
  get pathEdit(): string {
   return appModDummyTreePageItemEditConfigFullPath;
  }

  /**
   * Путь страницы "Просмотр".
   * @type {string}
   */
  get pathView(): string {
    return appModDummyTreePageItemViewConfigFullPath;
  }
}
