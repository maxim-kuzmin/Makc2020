// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageListStoreActionClear} from './actions/mod-dummy-tree-page-list-store-action-clear';
import {AppModDummyTreePageListStoreActionFilteredDelete} from './actions/mod-dummy-tree-page-list-store-action-filtered-delete';
import {AppModDummyTreePageListStoreActionFilteredDeleteSuccess} from '@app/mods/dummy-tree/pages/list/store/actions/mod-dummy-tree-page-list-store-action-filtered-delete-success';
import {AppModDummyTreePageListStoreActionItemDelete} from './actions/mod-dummy-tree-page-list-store-action-item-delete';
import {AppModDummyTreePageListStoreActionItemDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-item-delete-success';
import {AppModDummyTreePageListStoreActionLoad} from './actions/mod-dummy-tree-page-list-store-action-load';
import {AppModDummyTreePageListStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-list-store-action-load-success';
import {AppModDummyTreePageListStoreActionListDelete} from './actions/mod-dummy-tree-page-list-store-action-list-delete';
import {AppModDummyTreePageListStoreActionListDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-list-delete-success';
import {AppModDummyTreePageListStoreActionParametersSet} from './actions/mod-dummy-tree-page-list-store-action-parameters-set';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. */
export type AppModDummyTreePageListStoreActions =
  | AppModDummyTreePageListStoreActionClear
  | AppModDummyTreePageListStoreActionFilteredDelete
  | AppModDummyTreePageListStoreActionFilteredDeleteSuccess
  | AppModDummyTreePageListStoreActionItemDelete
  | AppModDummyTreePageListStoreActionItemDeleteSuccess
  | AppModDummyTreePageListStoreActionListDelete
  | AppModDummyTreePageListStoreActionListDeleteSuccess
  | AppModDummyTreePageListStoreActionLoad
  | AppModDummyTreePageListStoreActionLoadSuccess
  | AppModDummyTreePageListStoreActionParametersSet;
