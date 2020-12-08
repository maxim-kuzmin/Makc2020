// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppRootPageIndexStoreActions} from './root-page-index-store.actions';

/** Корень. Страницы. Начало. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageIndexStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppRootPageIndexStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppRootPageIndexStoreActions>
  ) {
  }
}
