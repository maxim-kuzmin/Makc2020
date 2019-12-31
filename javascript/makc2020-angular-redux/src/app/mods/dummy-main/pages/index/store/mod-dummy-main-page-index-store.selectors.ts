// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyMainStoreSelector} from '@app/mods/dummy-main/store/mod-dummy-main-store.selectors';

export const appModDummyMainPageIndexStoreSelector = createSelector(
  appModDummyMainStoreSelector,
  state => state.pageIndex
);
