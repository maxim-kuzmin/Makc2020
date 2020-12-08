// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageListStoreActionClear} from './actions/mod-dummy-main-page-list-store-action-clear';
import {AppModDummyMainPageListStoreActionFilteredDelete} from './actions/mod-dummy-main-page-list-store-action-filtered-delete';
import {AppModDummyMainPageListStoreActionFilteredDeleteSuccess} from '@app/mods/dummy-main/pages/list/store/actions/mod-dummy-main-page-list-store-action-filtered-delete-success';
import {AppModDummyMainPageListStoreActionItemDelete} from './actions/mod-dummy-main-page-list-store-action-item-delete';
import {AppModDummyMainPageListStoreActionItemDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-item-delete-success';
import {AppModDummyMainPageListStoreActionLoad} from './actions/mod-dummy-main-page-list-store-action-load';
import {AppModDummyMainPageListStoreActionLoadSuccess} from './actions/mod-dummy-main-page-list-store-action-load-success';
import {AppModDummyMainPageListStoreActionListDelete} from './actions/mod-dummy-main-page-list-store-action-list-delete';
import {AppModDummyMainPageListStoreActionListDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-list-delete-success';
import {AppModDummyMainPageListStoreActionParametersSet} from './actions/mod-dummy-main-page-list-store-action-parameters-set';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. */
export type AppModDummyMainPageListStoreActions =
  | AppModDummyMainPageListStoreActionClear
  | AppModDummyMainPageListStoreActionFilteredDelete
  | AppModDummyMainPageListStoreActionFilteredDeleteSuccess
  | AppModDummyMainPageListStoreActionItemDelete
  | AppModDummyMainPageListStoreActionItemDeleteSuccess
  | AppModDummyMainPageListStoreActionListDelete
  | AppModDummyMainPageListStoreActionListDeleteSuccess
  | AppModDummyMainPageListStoreActionLoad
  | AppModDummyMainPageListStoreActionLoadSuccess
  | AppModDummyMainPageListStoreActionParametersSet;
