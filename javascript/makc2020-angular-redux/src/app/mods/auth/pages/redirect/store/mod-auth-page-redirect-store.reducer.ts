// //Author Maxim Kuzmin//makc//

import {AppModAuthPageRedirectEnumActions} from '../enums/mod-auth-page-redirect-enum-actions';
import {AppModAuthPageRedirectState} from '../mod-auth-page-redirect-state';
import {AppModAuthPageRedirectStoreActions} from './mod-auth-page-redirect-store.actions';

/** Мод "Auth". Страницы. Перенаправление. Хранилище состояния. Редьюсер. */
export function appModAuthPageRedirectStoreReducer(
  state = new AppModAuthPageRedirectState(),
  action: AppModAuthPageRedirectStoreActions
): AppModAuthPageRedirectState {
  switch (action.type) {
    case AppModAuthPageRedirectEnumActions.Clear:
      return undefined;
    case AppModAuthPageRedirectEnumActions.Load:
      return {
        ...state,
        action: action.type
      };
    case AppModAuthPageRedirectEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        currentUser: action.currentUser,
        isLoggedIn: action.isLoggedIn,
        jobCurrentUserGetResult: action.jobCurrentUserGetResult,
        redirectUrl: action.redirectUrl
      };
    default:
      return state;
  }
}
