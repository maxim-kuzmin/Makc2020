// //Author Maxim Kuzmin//makc//

import {AppSkinHostLayoutMenuComponent} from '@app-skin/host/layout/menu/host-layout-menu.component';

/** Приложение. Вид. */
export class AppSkinView {

  /**
   * CSS-класс.
   * @type {any}
   */
  cssClass;

  /**
   * Получить CSS-стиль меню.
   * @param {AppSkinHostLayoutMenuComponent} ctrlMenu Меню.
   * @returns {boolean} CSS-стиль меню
   */
  getMenuCssStyle(ctrlMenu: AppSkinHostLayoutMenuComponent): any {
    return {
      'display': ctrlMenu.myView && ctrlMenu.myView.isVisible ? 'block' : 'none'
    };
  }
}
