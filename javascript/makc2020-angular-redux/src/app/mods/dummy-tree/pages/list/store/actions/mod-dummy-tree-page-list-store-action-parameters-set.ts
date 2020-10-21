// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyTreePageListEnumActions} from '../../enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListStateParameters} from '../../state/mod-dummy-tree-page-list-state-parameters';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Действия. Параметры. Установить. */
export class AppModDummyTreePageListStoreActionParametersSet implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyTreePageListEnumActions.ParametersSet;

  /**
   * Конструктор.
   * @param {AppModDummyTreePageListStateParameters} parameters Параметры.
   */
  constructor(
    public parameters: AppModDummyTreePageListStateParameters
  ) {
  }
}
