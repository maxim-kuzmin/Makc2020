// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModAuthPageLogonEnumActions} from '../../enums/mod-auth-page-logon-enum-actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Действия. Очистка. */
export class AppModAuthPageLogonStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageLogonEnumActions.Clear;
}
