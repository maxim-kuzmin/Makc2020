// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModAuthPageRedirectEnumActions} from '../../enums/mod-auth-page-redirect-enum-actions';

/** Мод "Auth". Страницы. Перенаправление. Хранилище состояния. Действия. Загрузка. */
export class AppModAuthPageRedirectStoreActionLoad implements Action {

  /** @inheritDoc */
  readonly type = AppModAuthPageRedirectEnumActions.Load;
}
