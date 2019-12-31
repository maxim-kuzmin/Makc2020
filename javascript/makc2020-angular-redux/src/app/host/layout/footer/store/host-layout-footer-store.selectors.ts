// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appHostStoreSelector} from '@app/host/store/host-store.selectors';

/** Хост. Разметка. Подвал. Хранилище состояния. Селектор. */
export const appHostLayoutFooterStoreSelector = createSelector(
  appHostStoreSelector,
  state => state.layoutFooter
);
