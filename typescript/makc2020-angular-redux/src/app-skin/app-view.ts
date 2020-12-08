// //Author Maxim Kuzmin//makc//

import {AppSkinHostLayoutMenuComponent} from '@app-skin/host/layout/menu/host-layout-menu.component';
import {AppView} from '@app/app-view';

/** Приложение. Вид. */
export class AppSkinView extends AppView {

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

  /**
   * @inheritDoc
   * @param {boolean} isAdminEnabled
   */
  setAdminMode(isAdminEnabled: boolean) {
    this.cssClass = {
      'skin--css--way--back': isAdminEnabled,
      'skin--css--way--front': !isAdminEnabled
    };
  }
}
