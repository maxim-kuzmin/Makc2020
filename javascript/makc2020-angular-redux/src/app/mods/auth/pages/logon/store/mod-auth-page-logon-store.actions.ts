// //Author Maxim Kuzmin//makc//

import {AppModAuthPageLogonStoreActionClear} from './actions/mod-auth-page-logon-store-action-clear';
import {AppModAuthPageLogonStoreActionLoad} from './actions/mod-auth-page-logon-store-action-load';
import {AppModAuthPageLogonStoreActionLogin} from './actions/mod-auth-page-logon-store-action-login';
import {AppModAuthPageLogonStoreActionLoginSuccess} from './actions/mod-auth-page-logon-store-action-login-success';
import {AppModAuthPageLogonStoreActionLogout} from './actions/mod-auth-page-logon-store-action-logout';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. */
export type AppModAuthPageLogonStoreActions =
  | AppModAuthPageLogonStoreActionClear
  | AppModAuthPageLogonStoreActionLoad
  | AppModAuthPageLogonStoreActionLogin
  | AppModAuthPageLogonStoreActionLoginSuccess
  | AppModAuthPageLogonStoreActionLogout;
