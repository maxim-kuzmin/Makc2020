// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageListEnumActions} from '../enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListState} from '../mod-dummy-tree-page-list-state';
import {AppModDummyTreePageListStoreActions} from './mod-dummy-tree-page-list-store.actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Редьюсер. */
export function appModDummyTreePageListStoreReducer(
  state = new AppModDummyTreePageListState(),
  action: AppModDummyTreePageListStoreActions
): AppModDummyTreePageListState {
  switch (action.type) {
    case AppModDummyTreePageListEnumActions.Clear:
      return undefined;
    case AppModDummyTreePageListEnumActions.ItemDelete:
      return {
        ...state,
        action: action.type,
        jobItemDeleteInput: action.jobItemDeleteInput
      };
    case AppModDummyTreePageListEnumActions.ItemDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobItemDeleteResult: action.jobItemDeleteResult
      };
    case AppModDummyTreePageListEnumActions.FilteredDelete:
      return {
        ...state,
        action: action.type,
        jobListGetInput: action.jobListGetInput
      };
    case AppModDummyTreePageListEnumActions.FilteredDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobListDeleteResult: action.jobListDeleteResult
      };
    case AppModDummyTreePageListEnumActions.ListDelete:
      return {
        ...state,
        action: action.type,
        jobListDeleteInput: action.jobListDeleteInput
      };
    case AppModDummyTreePageListEnumActions.ListDeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobListDeleteResult: action.jobListDeleteResult
      };
    case AppModDummyTreePageListEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobListGetInput: action.jobListGetInput
      };
    case AppModDummyTreePageListEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobListGetResult: action.jobListGetResult
      };
    case AppModDummyTreePageListEnumActions.ParametersSet:
      return {
        ...state,
        action: action.type,
        parameters: action.parameters
      };
    default:
      return state;
  }
}
