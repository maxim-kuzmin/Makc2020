// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainPageItemEnumActions} from '../../enums/mod-dummy-main-page-item-enum-actions';

/** Мод "DummyMain". Страницы. Элемент. Хранилище состояния. Действия. Очистка. */
export class AppModDummyMainPageItemStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageItemEnumActions.Clear;
}
