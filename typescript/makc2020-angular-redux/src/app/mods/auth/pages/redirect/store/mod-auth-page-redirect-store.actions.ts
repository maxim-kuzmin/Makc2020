// //Author Maxim Kuzmin//makc//

import {AppModAuthPageRedirectStoreActionClear} from './actions/mod-auth-page-redirect-store-action-clear';
import {AppModAuthPageRedirectStoreActionLoad} from './actions/mod-auth-page-redirect-store-action-load';
import {AppModAuthPageRedirectStoreActionLoadSuccess} from './actions/mod-auth-page-redirect-store-action-load-success';

/** Мод "Auth". Страницы. Перенаправление. Хранилище состояния. Действия. */
export type AppModAuthPageRedirectStoreActions =
  | AppModAuthPageRedirectStoreActionClear
  | AppModAuthPageRedirectStoreActionLoad
  | AppModAuthPageRedirectStoreActionLoadSuccess;
