// //Author Maxim Kuzmin//makc//

import { Action } from '@ngrx/store';
import { AppModDummyTreePageIndexEnumActions } from '../../enums/mod-dummy-tree-page-index-enum-actions';

/** Мод "DummyTree". Страницы. Начало. Хранилище состояния. Действия. Очистка. */
export class AppModDummyTreePageIndexStoreActionClear implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageIndexEnumActions.Clear;
}
