// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppRootPageIndexEnumActions } from '../../enums/root-page-index-enum-actions';

/** Корень. Страницы. Начало. Хранилище состояния. Действия. Очистка. */
export class AppRootPageIndexStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageIndexEnumActions.Clear;
}
