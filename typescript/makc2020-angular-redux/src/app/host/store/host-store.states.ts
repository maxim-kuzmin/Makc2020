// //Author Maxim Kuzmin//makc//

import {AppHostLayoutFooterState} from '@app/host/layout/footer/host-layout-footer-state';
import {AppHostLayoutMenuStoreState} from '@app/host/layout/menu/store/host-layout-menu-store.state';

/** Хост. Хранилище состояния. Состояния. */
export interface AppHostStoreStates {

  /**
   * Разметка. Подвал.
   * @type {AppHostLayoutFooterState}
   */
  layoutFooter: AppHostLayoutFooterState;

  /**
   * Разметка. Меню.
   * @type {AppHostLayoutMenuStoreState}
   */
  layoutMenu: AppHostLayoutMenuStoreState;
}
