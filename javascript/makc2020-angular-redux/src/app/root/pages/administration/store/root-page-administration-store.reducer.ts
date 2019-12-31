// //Author Maxim Kuzmin//makc//

import {AppRootPageAdministrationEnumActions} from '../enums/root-page-administration-enum-actions';
import {AppRootPageAdministrationState} from '../root-page-administration-state';
import {AppRootPageAdministrationStoreActions} from './root-page-administration-store.actions';

/** Корень. Страницы. Администрирование. Хранилище состояния. Редьюсер. */
export function appRootPageAdministrationStoreReducer(
  state = new AppRootPageAdministrationState(),
  action: AppRootPageAdministrationStoreActions
): AppRootPageAdministrationState {
  switch (action.type) {
    case AppRootPageAdministrationEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
