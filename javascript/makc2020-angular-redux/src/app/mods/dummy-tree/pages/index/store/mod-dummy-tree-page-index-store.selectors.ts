// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyTreeStoreSelector} from '@app/mods/dummy-tree/store/mod-dummy-tree-store.selectors';

export const appModDummyTreePageIndexStoreSelector = createSelector(
  appModDummyTreeStoreSelector,
  state => state.pageIndex
);
