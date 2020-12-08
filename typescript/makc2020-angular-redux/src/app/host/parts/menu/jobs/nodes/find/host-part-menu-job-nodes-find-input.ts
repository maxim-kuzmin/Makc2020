// //Author Maxim Kuzmin//makc//

import {AppCoreTreeEnumAxisMany} from '@app/core/tree/enums/core-tree-enum-axis-many';
import {AppHostPartMenuOption} from '@app/host/parts/menu/host-part-menu-option';

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Ввод. */
export class AppHostPartMenuJobNodesFindInput {

  /**
   * Конструктор.
   * @param {string} dataKey Ключ данных.
   * @param {AppCoreTreeEnumAxisMany} axis Ось.
   * @param {number} trimDepth Глубина обрезания.
   * @param {[key: string]: AppHostMenuOption} lookupOptionByMenuNodeKey Поиск варианта по ключу узла меню.
   */
  constructor(
    public dataKey: string,
    public axis: AppCoreTreeEnumAxisMany,
    public trimDepth: number,
    public lookupOptionByMenuNodeKey: { [key: string]: AppHostPartMenuOption }
  ) {
  }
}
