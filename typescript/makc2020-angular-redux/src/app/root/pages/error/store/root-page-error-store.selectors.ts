// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appRootStoreSelector} from '../../../store/root-store.selectors';

export const appRootPageErrorStoreSelector = createSelector(
  appRootStoreSelector,
  state => state.pageError
);
