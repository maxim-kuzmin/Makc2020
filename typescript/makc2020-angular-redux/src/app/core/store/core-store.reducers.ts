// //Author Maxim Kuzmin//makc//

import {routerReducer} from '@ngrx/router-store';
import {ActionReducerMap} from '@ngrx/store';
import {AppCoreStoreState} from './core-store.state';

/** Ядро. Хранилище состояния. Редьюсеры. */
export const appCoreStoreReducers: ActionReducerMap<AppCoreStoreState, any> = {
  router: routerReducer
};
