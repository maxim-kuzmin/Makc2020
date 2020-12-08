// //Author Maxim Kuzmin//makc//

import {AppHostLayoutMenuView} from '@app/host/layout/menu/host-layout-menu-view';

/** Хост. Разметка. Меню. Вид. */
export class AppSkinHostLayoutMenuView extends AppHostLayoutMenuView {

  /**
   * CSS класс.
   * @type {string}
   */
  get cssClass(): string {
    return 'skin--css--host--layout--menu' + this.menuLevel;
  }

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
    menuLevel: number
  ) {
    super(menuLevel);
  }
}
