// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyTreeStoreSelector} from '../../../store/mod-dummy-tree-store.selectors';

export const appModDummyTreePageListStoreSelector = createSelector(
  appModDummyTreeStoreSelector,
  state => state.pageList
);
