// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppModDummyTreePageIndexStoreActions} from './mod-dummy-tree-page-index-store.actions';

/** Мод "DummyTree". Страницы. Начало. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyTreePageIndexStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppModDummyTreePageIndexStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppModDummyTreePageIndexStoreActions>
  ) {
  }
}
