// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModDummyMainPageIndexEnumActions } from '../../enums/mod-dummy-main-page-index-enum-actions';

/** Мод "DummyMain". Страницы. Начало. Хранилище состояния. Действия. Очистка. */
export class AppModDummyMainPageIndexStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageIndexEnumActions.Clear;
}
