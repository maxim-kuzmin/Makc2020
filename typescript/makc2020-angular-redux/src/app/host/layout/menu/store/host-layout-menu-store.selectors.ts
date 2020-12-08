// //Author Maxim Kuzmin//makc//

import {createSelector} from '@ngrx/store';
import {appHostStoreSelector} from '@app/host/store/host-store.selectors';

/** Хост. Разметка. Меню. Хранилище состояния. Селектор. */
export const appHostLayoutMenuStoreSelector = createSelector(
  appHostStoreSelector,
  (state, props) => state.layoutMenu.lookupStateByMenuLevel[props.menuLevel]
);
