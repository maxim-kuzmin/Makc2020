// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModAuthPageIndexEnumActions } from '../../enums/mod-auth-page-index-enum-actions';

/** Мод "Auth". Страницы. Начало. Хранилище состояния. Действия. Очистка. */
export class AppModAuthPageIndexStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageIndexEnumActions.Clear;
}
