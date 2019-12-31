// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageItemEnumActions} from '../enums/mod-dummy-main-page-item-enum-actions';
import {AppModDummyMainPageItemState} from '../mod-dummy-main-page-item-state';
import {AppModDummyMainPageItemStoreActions} from './mod-dummy-main-page-item-store.actions';

/** Мод "DummyMain". Страницы. Вход в систему. Хранилище состояния. Редьюсер. */
export function appModDummyMainPageItemStoreReducer(
  state = new AppModDummyMainPageItemState(),
  action: AppModDummyMainPageItemStoreActions
): AppModDummyMainPageItemState {
  switch (action.type) {
    case AppModDummyMainPageItemEnumActions.Clear:
      return undefined;
    case AppModDummyMainPageItemEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModDummyMainPageItemEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult,
        jobOptionsDummyManyToManyGetResult: action.jobOptionsDummyManyToManyGetResult,
        jobOptionsDummyOneToManyGetResult: action.jobOptionsDummyOneToManyGetResult
      };
    case AppModDummyMainPageItemEnumActions.Save:
      return {
        ...state,
        action: action.type,
        jobItemGetOutput: action.jobItemGetOutput
      };
    case AppModDummyMainPageItemEnumActions.SaveSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult
      };
    default:
      return state;
  }
}
