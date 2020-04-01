// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModDummyTreePageListEnumActions } from '../../enums/mod-dummy-tree-page-list-enum-actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Очистка. */
export class AppModDummyTreePageListStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.Clear;
}
