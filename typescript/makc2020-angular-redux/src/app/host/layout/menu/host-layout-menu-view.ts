// //Author Maxim Kuzmin//makc//

import {AppHostLayoutMenuDataItem} from '@app/host/layout/menu/data/host-layout-menu-data-item';

/** Хост. Разметка. Меню. Вид. */
export class AppHostLayoutMenuView {

  /**
   * Данные.
   * @type {AppHostLayoutMenuDataItem[]}
   */
  data: AppHostLayoutMenuDataItem[];

  /**
   * Признак того, что данные загружены.
   * @type {boolean}
   */
  isDataLoaded = false;

  /**
   * Признак видимости.
   * @type {boolean}
   */
  get isVisible(): boolean {
    return this.isDataLoaded && this.data.length > 0;
  }

  /**
   * Конструктор.
   * @param {number} menuLevel Уровень меню.
   */
  constructor(
    public menuLevel: number
  ) {
  }
}

