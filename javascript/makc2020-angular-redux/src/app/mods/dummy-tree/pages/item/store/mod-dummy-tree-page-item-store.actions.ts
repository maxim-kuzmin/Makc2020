// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageItemStoreActionClear} from './actions/mod-dummy-tree-page-item-store-action-clear';
import {AppModDummyTreePageItemStoreActionLoad} from './actions/mod-dummy-tree-page-item-store-action-load';
import {AppModDummyTreePageItemStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-item-store-action-load-success';
import {AppModDummyTreePageItemStoreActionSave} from './actions/mod-dummy-tree-page-item-store-action-save';
import {AppModDummyTreePageItemStoreActionSaveSuccess} from './actions/mod-dummy-tree-page-item-store-action-save-success';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. */
export type AppModDummyTreePageItemStoreActions =
  | AppModDummyTreePageItemStoreActionClear
  | AppModDummyTreePageItemStoreActionLoad
  | AppModDummyTreePageItemStoreActionLoadSuccess
  | AppModDummyTreePageItemStoreActionSave
  | AppModDummyTreePageItemStoreActionSaveSuccess;
