// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyMainStoreSelector} from '../../../store/mod-dummy-main-store.selectors';

export const appModDummyMainPageListStoreSelector = createSelector(
  appModDummyMainStoreSelector,
  state => state.pageList
);
