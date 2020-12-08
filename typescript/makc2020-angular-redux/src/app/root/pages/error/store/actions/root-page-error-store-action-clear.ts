// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppRootPageErrorEnumActions } from '../../enums/root-page-error-enum-actions';

/** Корень. Страницы. Ошибка. Хранилище состояния. Действия. Очистка. */
export class AppRootPageErrorStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppRootPageErrorEnumActions.Clear;
}
