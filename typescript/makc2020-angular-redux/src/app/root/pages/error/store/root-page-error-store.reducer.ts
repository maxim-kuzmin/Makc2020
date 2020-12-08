// //Author Maxim Kuzmin//makc//

import {AppRootPageErrorEnumActions} from '../enums/root-page-error-enum-actions';
import {AppRootPageErrorState} from '../root-page-error-state';
import {AppRootPageErrorStoreActions} from './root-page-error-store.actions';

/** Корень. Страницы. Ошибка. Хранилище состояния. Редьюсер. */
export function appRootPageErrorStoreReducer(
  state = new AppRootPageErrorState(),
  action: AppRootPageErrorStoreActions
): AppRootPageErrorState {
  switch (action.type) {
    case AppRootPageErrorEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
