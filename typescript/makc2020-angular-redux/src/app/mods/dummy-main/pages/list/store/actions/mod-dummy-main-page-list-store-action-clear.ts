// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModDummyMainPageListEnumActions } from '../../enums/mod-dummy-main-page-list-enum-actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Очистка. */
export class AppModDummyMainPageListStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.Clear;
}
