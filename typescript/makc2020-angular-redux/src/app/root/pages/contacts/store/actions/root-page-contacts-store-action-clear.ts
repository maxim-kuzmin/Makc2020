// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppRootPageContactsEnumActions } from '../../enums/root-page-contacts-enum-actions';

/** Корень. Страницы. Контакты. Хранилище состояния. Действия. Очистка. */
export class AppRootPageContactsStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageContactsEnumActions.Clear;
}
