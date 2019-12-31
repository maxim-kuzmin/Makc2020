// //Author Maxim Kuzmin//makc//

import {AppCoreTreeEnumAxisOne} from '@app/core/tree/enums/core-tree-enum-axis-one';
import {AppHostMenuOption} from '@app/host/menu/host-menu-option';

/** Хост. Меню. Задания. Узел. Поиск. Ввод. */
export class AppHostMenuJobNodeFindInput {

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
    public lookupOptionByMenuNodeKey: { [key: string]: AppHostMenuOption }
  ) {
  }
}
