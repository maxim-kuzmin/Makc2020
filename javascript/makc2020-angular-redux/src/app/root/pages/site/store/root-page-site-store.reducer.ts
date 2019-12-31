// //Author Maxim Kuzmin//makc//

import {AppRootPageSiteEnumActions} from '../enums/root-page-site-enum-actions';
import {AppRootPageSiteState} from '../root-page-site-state';
import {AppRootPageSiteStoreActions} from './root-page-site-store.actions';

/** Корень. Страницы. Сайт. Хранилище состояния. Редьюсер. */
export function appRootPageSiteStoreReducer(
  state = new AppRootPageSiteState(),
  action: AppRootPageSiteStoreActions
): AppRootPageSiteState {
  switch (action.type) {
    case AppRootPageSiteEnumActions.Clear:
      return undefined;
    default:
      return state;
  }
}
