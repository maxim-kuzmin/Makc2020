// //Author Maxim Kuzmin//makc//

import {ActionReducerMap} from '@ngrx/store';
import {AppHostStoreStates} from './host-store.states';
import {appHostLayoutFooterStoreReducer} from '../layout/footer/store/host-layout-footer-store.reducer';
import {appHostLayoutMenuStoreReducer} from '../layout/menu/store/host-layout-menu-store.reducer';

/** Хост. Хранилище состояния. Редьюсеры. */
export const appHostStoreReducers: ActionReducerMap<AppHostStoreStates, any> = {

  /** Разметка. Подвал. */
  layoutFooter: appHostLayoutFooterStoreReducer,

  /** Разметка. Меню. */
  layoutMenu: appHostLayoutMenuStoreReducer
};
