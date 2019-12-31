// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppHostMenuOption} from './host-menu-option';
import {AppHostMenuStore} from './host-menu-store';

/** Хост. Меню. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostMenuService {

  /**
   * Конструктор.
   * @param {AppHostMenuStore} appStore Хранилище состояния.
   */
  constructor(
    private appStore: AppHostMenuStore
  ) {
  }

  /**
   * Выполнить действие "Установка".
   * @param {string} menuNodeKey Ключ узла меню.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  executeActionSet(
    menuNodeKey: string,
    lookupOptionByMenuNodeKey: {[key: string]: AppHostMenuOption} = null
  ) {
    this.appStore.runActionSet(
      menuNodeKey,
      lookupOptionByMenuNodeKey
      );
  }
}
