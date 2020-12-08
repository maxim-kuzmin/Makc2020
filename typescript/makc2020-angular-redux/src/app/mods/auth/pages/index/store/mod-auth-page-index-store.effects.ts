// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppModAuthPageIndexStoreActions} from './mod-auth-page-index-store.actions';

/** Мод "Auth". Страницы. Начало. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModAuthPageIndexStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppModAuthPageIndexStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppModAuthPageIndexStoreActions>
  ) {
  }
}
