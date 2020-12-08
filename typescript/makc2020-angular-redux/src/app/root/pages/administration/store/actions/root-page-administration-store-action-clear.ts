// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppRootPageAdministrationEnumActions } from '../../enums/root-page-administration-enum-actions';

/** Корень. Страницы. Администрирование. Хранилище состояния. Действия. Очистка. */
export class AppRootPageAdministrationStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageAdministrationEnumActions.Clear;
}
