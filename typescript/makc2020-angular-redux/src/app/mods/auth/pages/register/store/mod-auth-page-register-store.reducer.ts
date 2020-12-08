// //Author Maxim Kuzmin//makc//

import {AppModAuthPageRegisterEnumActions} from '../enums/mod-auth-page-register-enum-actions';
import {AppModAuthPageRegisterState} from '../mod-auth-page-register-state';
import {AppModAuthPageRegisterStoreActions} from './mod-auth-page-register-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Редьюсер. */
export function appModAuthPageRegisterStoreReducer(
  state = new AppModAuthPageRegisterState(),
  action: AppModAuthPageRegisterStoreActions
): AppModAuthPageRegisterState {
  switch (action.type) {
    case AppModAuthPageRegisterEnumActions.Clear:
      return undefined;
    case AppModAuthPageRegisterEnumActions.Save:
      return {
        ...state,
        action: action.type,
        jobRegisterInput: action.jobRegisterInput
      };
    case AppModAuthPageRegisterEnumActions.SaveSuccess:
      return {
        ...state,
        action: action.type,
        jobRegisterResult: action.jobRegisterResult
      };
    default:
      return state;
  }
}
