// //Author Maxim Kuzmin//makc//

import {AppCoreTreeEnumAxisMany} from '@app/core/tree/enums/core-tree-enum-axis-many';
import {AppHostMenuOption} from '@app/host/menu/host-menu-option';

/** Хост. Меню. Задания. Узлы. Поиск. Ввод. */
export class AppHostMenuJobNodesFindInput {

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
    public lookupOptionByMenuNodeKey: { [key: string]: AppHostMenuOption }
  ) {
  }
}
