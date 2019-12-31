// //Author Maxim Kuzmin//makc//

import {ActionReducerMap} from '@ngrx/store';
import {appModDummyMainPageIndexStoreReducer} from '../pages/index/store/mod-dummy-main-page-index-store.reducer';
import {appModDummyMainPageItemStoreReducer} from '../pages/item/store/mod-dummy-main-page-item-store.reducer';
import {appModDummyMainPageListStoreReducer} from '../pages/list/store/mod-dummy-main-page-list-store.reducer';
import {AppModDummyMainStoreStates} from './mod-dummy-main-store.states';

/** Мод "DummyMain". Хранилище состояния. Редьюсеры. */
export const appModDummyMainStoreReducers: ActionReducerMap<AppModDummyMainStoreStates, any> = {
  pageIndex: appModDummyMainPageIndexStoreReducer,
  pageItem: appModDummyMainPageItemStoreReducer,
  pageList: appModDummyMainPageListStoreReducer
};
