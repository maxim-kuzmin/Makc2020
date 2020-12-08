// //Author Maxim Kuzmin//makc//

import {ActionReducerMap} from '@ngrx/store';
import {appModDummyTreePageIndexStoreReducer} from '../pages/index/store/mod-dummy-tree-page-index-store.reducer';
import {appModDummyTreePageItemStoreReducer} from '../pages/item/store/mod-dummy-tree-page-item-store.reducer';
import {appModDummyTreePageListStoreReducer} from '../pages/list/store/mod-dummy-tree-page-list-store.reducer';
import {AppModDummyTreeStoreStates} from './mod-dummy-tree-store.states';

/** Мод "DummyTree". Хранилище состояния. Редьюсеры. */
export const appModDummyTreeStoreReducers: ActionReducerMap<AppModDummyTreeStoreStates, any> = {
  pageIndex: appModDummyTreePageIndexStoreReducer,
  pageItem: appModDummyTreePageItemStoreReducer,
  pageList: appModDummyTreePageListStoreReducer
};
