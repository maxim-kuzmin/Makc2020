// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appModAuthStoreSelector} from '../../../store/mod-auth-store.selectors';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Селектор. */
export const appModAuthPageLogonStoreSelector = createSelector(
  appModAuthStoreSelector,
  state => state.pageLogon
);
