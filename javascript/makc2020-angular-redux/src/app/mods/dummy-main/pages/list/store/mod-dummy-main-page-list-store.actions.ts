// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageListStoreActionClear} from './actions/mod-dummy-main-page-list-store-action-clear';
import {AppModDummyMainPageListStoreActionDelete} from './actions/mod-dummy-main-page-list-store-action-delete';
import {AppModDummyMainPageListStoreActionDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-delete-success';
import {AppModDummyMainPageListStoreActionLoad} from './actions/mod-dummy-main-page-list-store-action-load';
import {AppModDummyMainPageListStoreActionLoadSuccess} from './actions/mod-dummy-main-page-list-store-action-load-success';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. */
export type AppModDummyMainPageListStoreActions =
  | AppModDummyMainPageListStoreActionClear
  | AppModDummyMainPageListStoreActionDelete
  | AppModDummyMainPageListStoreActionDeleteSuccess
  | AppModDummyMainPageListStoreActionLoad
  | AppModDummyMainPageListStoreActionLoadSuccess;
