// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModAuthStoreSelector} from '@app/mods/auth/store/mod-auth-store.selectors';

export const appModAuthPageRedirectStoreSelector = createSelector(
  appModAuthStoreSelector,
  state => state.pageRedirect
);
