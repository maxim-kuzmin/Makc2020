// //Author Maxim Kuzmin//makc//

import {AppRootPageContactsStoreActionClear} from './actions/root-page-contacts-store-action-clear';
import {AppRootPageContactsStoreActionLoad} from './actions/host-layout-footer-store-action-load';
import {AppRootPageContactsStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';

/** Корень. Страницы. Контакты. Хранилище состояния. Действия. */
export type AppRootPageContactsStoreActions =
  | AppRootPageContactsStoreActionClear
  | AppRootPageContactsStoreActionLoad
  | AppRootPageContactsStoreActionLoadSuccess;
