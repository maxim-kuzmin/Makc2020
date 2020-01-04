// //Author Maxim Kuzmin//makc//

import {AppCoreTreeEnumAxisOne} from '@app/core/tree/enums/core-tree-enum-axis-one';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';

/** Хост. Часть "Menu". Задания. Узел. Поиск. Ввод. */
export class AppHostPartMenuJobNodeFindInput {

  /**
   * Конструктор.
   * @param {string} dataKey Ключ данных.
   * @param {AppCoreTreeEnumAxisOne} axis Ось.
   * @param {number} trimDepth Глубина обрезания.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  constructor(
    public dataKey: string,
    public axis: AppCoreTreeEnumAxisOne,
    public trimDepth: number,
    public lookupOptionByMenuNodeKey: { [key: string]: AppHostPartMenuOption }
  ) {
  }
}
