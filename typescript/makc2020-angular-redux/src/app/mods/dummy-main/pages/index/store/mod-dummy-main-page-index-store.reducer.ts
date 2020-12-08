// //Author Maxim Kuzmin//makc//

import {AppModDummyMainPageIndexEnumActions} from '../enums/mod-dummy-main-page-index-enum-actions';
import {AppModDummyMainPageIndexState} from '../mod-dummy-main-page-index-state';
import {AppModDummyMainPageIndexStoreActions} from './mod-dummy-main-page-index-store.actions';

/** Мод "DummyMain". Страницы. Начало. Хранилище состояния. Редьюсер. */
export function appModDummyMainPageIndexStoreReducer(
  state = new AppModDummyMainPageIndexState(),
  action: AppModDummyMainPageIndexStoreActions
): AppModDummyMainPageIndexState {
  switch (action.type) {
    case AppModDummyMainPageIndexEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
