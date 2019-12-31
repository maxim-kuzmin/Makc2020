// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageItemStoreActionClear} from './actions/mod-dummy-main-page-item-store-action-clear';
import {AppModDummyMainPageItemStoreActionLoad} from './actions/mod-dummy-main-page-item-store-action-load';
import {AppModDummyMainPageItemStoreActionLoadSuccess} from './actions/mod-dummy-main-page-item-store-action-load-success';
import {AppModDummyMainPageItemStoreActionSave} from './actions/mod-dummy-main-page-item-store-action-save';
import {AppModDummyMainPageItemStoreActionSaveSuccess} from './actions/mod-dummy-main-page-item-store-action-save-success';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. */
export type AppModDummyMainPageItemStoreActions =
  | AppModDummyMainPageItemStoreActionClear
  | AppModDummyMainPageItemStoreActionLoad
  | AppModDummyMainPageItemStoreActionLoadSuccess
  | AppModDummyMainPageItemStoreActionSave
  | AppModDummyMainPageItemStoreActionSaveSuccess;
