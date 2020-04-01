// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageListStoreActionClear} from './actions/mod-dummy-tree-page-list-store-action-clear';
import {AppModDummyTreePageListStoreActionDelete} from './actions/mod-dummy-tree-page-list-store-action-delete';
import {AppModDummyTreePageListStoreActionDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-delete-success';
import {AppModDummyTreePageListStoreActionLoad} from './actions/mod-dummy-tree-page-list-store-action-load';
import {AppModDummyTreePageListStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-list-store-action-load-success';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. */
export type AppModDummyTreePageListStoreActions =
  | AppModDummyTreePageListStoreActionClear
  | AppModDummyTreePageListStoreActionDelete
  | AppModDummyTreePageListStoreActionDeleteSuccess
  | AppModDummyTreePageListStoreActionLoad
  | AppModDummyTreePageListStoreActionLoadSuccess;
