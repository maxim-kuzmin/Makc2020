// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppModDummyMainPageIndexStoreActions} from './mod-dummy-main-page-index-store.actions';

/** Мод "DummyMain". Страницы. Начало. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyMainPageIndexStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppModDummyMainPageIndexStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppModDummyMainPageIndexStoreActions>
  ) {
  }
}
