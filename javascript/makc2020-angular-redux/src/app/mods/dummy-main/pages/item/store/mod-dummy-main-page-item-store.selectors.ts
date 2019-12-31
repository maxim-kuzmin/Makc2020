// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModDummyMainStoreSelector} from '../../../store/mod-dummy-main-store.selectors';

/** Мод "DummyMain". Страницы. Вход в систему. Хранилище состояния. Селектор. */
export const appModDummyMainPageItemStoreSelector = createSelector(
  appModDummyMainStoreSelector,
  state => state.pageItem
);
