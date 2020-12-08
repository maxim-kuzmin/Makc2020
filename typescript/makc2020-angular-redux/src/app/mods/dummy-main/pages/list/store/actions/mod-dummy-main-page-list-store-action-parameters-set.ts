// //Author Maxim Kuzmin//makc//

import {Action} from '@ngrx/store';
import {AppModDummyMainPageListEnumActions} from '../../enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListStateParameters} from '../../state/mod-dummy-main-page-list-state-parameters';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Действия. Параметры. Установить. */
export class AppModDummyMainPageListStoreActionParametersSet implements Action {

  /** @inheritDoc */
  readonly type = AppModDummyMainPageListEnumActions.ParametersSet;

  /**
   * Конструктор.
   * @param {AppModDummyMainPageListStateParameters} parameters Параметры.
   */
  constructor(
    public parameters: AppModDummyMainPageListStateParameters
  ) {
  }
}
