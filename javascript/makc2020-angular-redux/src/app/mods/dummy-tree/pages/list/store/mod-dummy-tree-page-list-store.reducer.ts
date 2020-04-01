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
    case AppModDummyTreePageListEnumActions.Delete:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModDummyTreePageListEnumActions.DeleteSuccess:
      return {
        ...state,
        action: action.type,
        jobItemDeleteResult: action.jobItemDeleteResult
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
    default:
      return state;
  }
}
