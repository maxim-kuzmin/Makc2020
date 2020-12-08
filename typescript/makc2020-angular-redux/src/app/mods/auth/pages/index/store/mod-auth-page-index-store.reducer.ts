// //Author Maxim Kuzmin//makc//

import {AppModAuthPageIndexEnumActions} from '../enums/mod-auth-page-index-enum-actions';
import {AppModAuthPageIndexState} from '../mod-auth-page-index-state';
import {AppModAuthPageIndexStoreActions} from './mod-auth-page-index-store.actions';

/** Мод "Auth". Страницы. Начало. Хранилище состояния. Редьюсер. */
export function appModAuthPageIndexStoreReducer(
  state = new AppModAuthPageIndexState(),
  action: AppModAuthPageIndexStoreActions
): AppModAuthPageIndexState {
  switch (action.type) {
    case AppModAuthPageIndexEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
