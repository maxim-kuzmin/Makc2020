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
    case AppModDummyMainPageListEnumActions.ItemDelete:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModDummyMainPageListEnumActions.ItemDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobItemDeleteResult: action.jobItemDeleteResult
      };
    case AppModDummyMainPageListEnumActions.FilteredDelete:
      return {
        ...state,
        action: action.type,
        jobListGetInput: action.jobListGetInput
      };
    case AppModDummyMainPageListEnumActions.FilteredDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobListDeleteResult: action.jobListDeleteResult
      };
    case AppModDummyMainPageListEnumActions.ListDelete:
      return {
        ...state,
        action: action.type,
        jobListDeleteInput: action.jobListDeleteInput
      };
    case AppModDummyMainPageListEnumActions.ListDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobListDeleteResult: action.jobListDeleteResult
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
        jobListGetResult: action.jobListGetResult,
        jobOptionsDummyOneToManyGetResult: action.jobOptionsDummyOneToManyGetResult
      };
    case AppModDummyMainPageListEnumActions.ParametersSet:
      return {
        ...state,
        action: action.type,
        parameters: action.parameters
      };
    default:
      return state;
  }
}
