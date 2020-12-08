// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appRootStoreSelector} from '../../../store/root-store.selectors';

export const appRootPageAdministrationStoreSelector = createSelector(
  appRootStoreSelector,
  state => state.pageAdministration
);
