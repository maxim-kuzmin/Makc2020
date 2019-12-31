// //Author Maxim Kuzmin//makc//

import {ActionReducerMap} from '@ngrx/store';
import {appModAuthPageIndexStoreReducer} from '../pages/index/store/mod-auth-page-index-store.reducer';
import {appModAuthPageLogonStoreReducer} from '../pages/logon/store/mod-auth-page-logon-store.reducer';
import {appModAuthPageRedirectStoreReducer} from '../pages/redirect/store/mod-auth-page-redirect-store.reducer';
import {appModAuthPageRegisterStoreReducer} from '../pages/register/store/mod-auth-page-register-store.reducer';
import {AppModAuthStoreStates} from './mod-auth-store.states';

/** Мод "Auth". Хранилище состояния. Редьюсеры. */
export const appModAuthStoreReducers: ActionReducerMap<AppModAuthStoreStates, any> = {
  pageIndex: appModAuthPageIndexStoreReducer,
  pageLogon: appModAuthPageLogonStoreReducer,
  pageRedirect: appModAuthPageRedirectStoreReducer,
  pageRegister: appModAuthPageRegisterStoreReducer
};
