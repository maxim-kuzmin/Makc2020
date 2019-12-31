// //Author Maxim Kuzmin//makc//

import {ActionReducerMap} from '@ngrx/store';
import {AppRootStoreStates} from './root-store.states';
import {appRootPageAdministrationStoreReducer} from '@app/root/pages/administration/store/root-page-administration-store.reducer';
import {appRootPageContactsStoreReducer} from '@app/root/pages/contacts/store/root-page-contacts-store.reducer';
import {appRootPageErrorStoreReducer} from '@app/root/pages/error/store/root-page-error-store.reducer';
import {appRootPageIndexStoreReducer} from '@app/root/pages/index/store/root-page-index-store.reducer';
import {appRootPageSiteStoreReducer} from '@app/root/pages/site/store/root-page-site-store.reducer';

/** Корень. Хранилище состояния. Редьюсеры. */
export const appRootStoreReducers: ActionReducerMap<AppRootStoreStates, any> = {
  pageAdministration: appRootPageAdministrationStoreReducer,
  pageContacts: appRootPageContactsStoreReducer,
  pageError: appRootPageErrorStoreReducer,
  pageIndex: appRootPageIndexStoreReducer,
  pageSite: appRootPageSiteStoreReducer
};
