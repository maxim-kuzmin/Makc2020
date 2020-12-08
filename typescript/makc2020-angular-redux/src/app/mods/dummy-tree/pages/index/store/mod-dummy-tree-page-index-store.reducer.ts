// //Author Maxim Kuzmin//makc//

import {AppModDummyTreePageIndexEnumActions} from '../enums/mod-dummy-tree-page-index-enum-actions';
import {AppModDummyTreePageIndexState} from '../mod-dummy-tree-page-index-state';
import {AppModDummyTreePageIndexStoreActions} from './mod-dummy-tree-page-index-store.actions';

/** Мод "DummyTree". Страницы. Начало. Хранилище состояния. Редьюсер. */
export function appModDummyTreePageIndexStoreReducer(
  state = new AppModDummyTreePageIndexState(),
  action: AppModDummyTreePageIndexStoreActions
): AppModDummyTreePageIndexState {
  switch (action.type) {
    case AppModDummyTreePageIndexEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
