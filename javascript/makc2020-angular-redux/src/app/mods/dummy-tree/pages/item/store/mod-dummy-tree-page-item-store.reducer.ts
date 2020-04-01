// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageItemEnumActions} from '../enums/mod-dummy-tree-page-item-enum-actions';
import {AppModDummyTreePageItemState} from '../mod-dummy-tree-page-item-state';
import {AppModDummyTreePageItemStoreActions} from './mod-dummy-tree-page-item-store.actions';

/** Мод "DummyTree". Страницы. Вход в систему. Хранилище состояния. Редьюсер. */
export function appModDummyTreePageItemStoreReducer(
  state = new AppModDummyTreePageItemState(),
  action: AppModDummyTreePageItemStoreActions
): AppModDummyTreePageItemState {
  switch (action.type) {
    case AppModDummyTreePageItemEnumActions.Clear:
      return undefined;
    case AppModDummyTreePageItemEnumActions.Load:
      return {
        ...state,
        action: action.type,
        jobItemGetInput: action.jobItemGetInput
      };
    case AppModDummyTreePageItemEnumActions.LoadSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult
      };
    case AppModDummyTreePageItemEnumActions.Save:
      return {
        ...state,
        action: action.type,
        jobItemGetOutput: action.jobItemGetOutput
      };
    case AppModDummyTreePageItemEnumActions.SaveSuccess:
      return {
        ...state,
        action: action.type,
        jobItemGetResult: action.jobItemGetResult
      };
    default:
      return state;
  }
}
