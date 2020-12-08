// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppRootPageSiteEnumActions } from '../../enums/root-page-site-enum-actions';

/** Корень. Страницы. Сайт. Хранилище состояния. Действия. Очистка. */
export class AppRootPageSiteStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageSiteEnumActions.Clear;
}
