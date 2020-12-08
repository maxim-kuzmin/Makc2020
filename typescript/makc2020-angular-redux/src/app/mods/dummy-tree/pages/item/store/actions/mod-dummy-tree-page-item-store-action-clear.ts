// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreePageItemEnumActions} from '../../enums/mod-dummy-tree-page-item-enum-actions';

/** Мод "DummyTree". Страницы. Элемент. Хранилище состояния. Действия. Очистка. */
export class AppModDummyTreePageItemStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageItemEnumActions.Clear;
}
