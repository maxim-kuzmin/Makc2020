// //Author Maxim Kuzmin//makc//

import {AppRootPageIndexEnumActions} from '../enums/root-page-index-enum-actions';
import {AppRootPageIndexState} from '../root-page-index-state';
import {AppRootPageIndexStoreActions} from './root-page-index-store.actions';

/** Корень. Страницы. Начало. Хранилище состояния. Редьюсер. */
export function appRootPageIndexStoreReducer(
  state = new AppRootPageIndexState(),
  action: AppRootPageIndexStoreActions
): AppRootPageIndexState {
  switch (action.type) {
    case AppRootPageIndexEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
