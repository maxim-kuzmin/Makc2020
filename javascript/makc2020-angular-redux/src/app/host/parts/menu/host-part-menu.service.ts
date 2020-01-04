// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppHostPartMenuOption} from './host-part-menu-option';
import {AppHostPartMenuStore} from './host-part-menu-store';

/** Хост. Часть "Menu". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppHostPartMenuService {

  /**
   * Конструктор.
   * @param {AppHostPartMenuStore} appStore Хранилище состояния.
   */
  constructor(
    private appStore: AppHostPartMenuStore
  ) {
  }

  /**
   * Выполнить действие "Установка".
   * @param {string} menuNodeKey Ключ узла меню.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  executeActionSet(
    menuNodeKey: string,
    lookupOptionByMenuNodeKey: {[key: string]: AppHostPartMenuOption} = null
  ) {
    this.appStore.runActionSet(
      menuNodeKey,
      lookupOptionByMenuNodeKey
      );
  }
}
