// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyTreeStoreSelector} from '../../../store/mod-dummy-tree-store.selectors';

/** Мод "DummyTree". Страницы. Вход в систему. Хранилище состояния. Селектор. */
export const appModDummyTreePageItemStoreSelector = createSelector(
  appModDummyTreeStoreSelector,
  state => state.pageItem
);
