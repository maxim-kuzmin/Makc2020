// //Author Maxim Kuzmin//makc//

import {AppModAuthPageLogonEnumActions} from '../enums/mod-auth-page-logon-enum-actions';
import {AppModAuthPageLogonState} from '../mod-auth-page-logon-state';
import {AppModAuthPageLogonStoreActions} from './mod-auth-page-logon-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Редьюсер. */
export function appModAuthPageLogonStoreReducer(
  state = new AppModAuthPageLogonState(),
  action: AppModAuthPageLogonStoreActions
): AppModAuthPageLogonState {
  switch (action.type) {
    case AppModAuthPageLogonEnumActions.Clear:
      return undefined;
    case AppModAuthPageLogonEnumActions.Login:
      return {
        ...state,
        action: action.type,
        jobLoginInput: action.jobLoginInput
      };
    case AppModAuthPageLogonEnumActions.LoginSuccess:
      return {
        ...state,
        action: action.type,
        currentUser: action.currentUser,
        isLoggedIn: action.isLoggedIn,
        jobLoginResult: action.jobLoginResult,
        redirectUrl: action.redirectUrl
      };
    case AppModAuthPageLogonEnumActions.Load:
    case AppModAuthPageLogonEnumActions.Logout:
      return {
        ...state,
        action: action.type,
        currentUser: action.currentUser,
        isLoggedIn: action.isLoggedIn
      };
    default:
      return state;
  }
}
