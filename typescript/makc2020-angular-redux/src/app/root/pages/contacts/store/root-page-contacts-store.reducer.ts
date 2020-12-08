// //Author Maxim Kuzmin//makc//

import {AppRootPageContactsEnumActions} from '../enums/root-page-contacts-enum-actions';
import {AppRootPageContactsState} from '../root-page-contacts-state';
import {AppRootPageContactsStoreActions} from './root-page-contacts-store.actions';

/** Корень. Страницы. Контакты. Хранилище состояния. Редьюсер. */
export function appRootPageContactsStoreReducer(
  state = new AppRootPageContactsState(),
  action: AppRootPageContactsStoreActions
): AppRootPageContactsState {
  switch (action.type) {
    case AppRootPageContactsEnumActions.Clear:
      return undefined;
    case AppRootPageContactsEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobContentLoadInput: action.jobContentLoadInput
      };
    case AppRootPageContactsEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobContentLoadResult: action.jobContentLoadResult
      };
    default:
      return state;
  }
}
