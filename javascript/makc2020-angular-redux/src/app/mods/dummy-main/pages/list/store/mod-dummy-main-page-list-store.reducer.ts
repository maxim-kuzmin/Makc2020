// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageListEnumActions} from '../enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListState} from '../mod-dummy-main-page-list-state';
import {AppModDummyMainPageListStoreActions} from './mod-dummy-main-page-list-store.actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Редьюсер. */
export function appModDummyMainPageListStoreReducer(
  state = new AppModDummyMainPageListState(),
  action: AppModDummyMainPageListStoreActions
): AppModDummyMainPageListState {
  switch (action.type) {
    case AppModDummyMainPageListEnumActions.Clear:
      return undefined;
    case AppModDummyMainPageListEnumActions.Delete:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModDummyMainPageListEnumActions.DeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobItemDeleteResult: action.jobItemDeleteResult
      };
    case AppModDummyMainPageListEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobListGetInput: action.jobListGetInput
      };
    case AppModDummyMainPageListEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobListGetResult: action.jobListGetResult
      };
    default:
      return state;
  }
}
