// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModAuthPageRegisterEnumActions} from '../../enums/mod-auth-page-register-enum-actions';

/** Мод "Auth". Страницы. Регистрация. Хранилище состояния. Действия. Очистка. */
export class AppModAuthPageRegisterStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageRegisterEnumActions.Clear;
}
