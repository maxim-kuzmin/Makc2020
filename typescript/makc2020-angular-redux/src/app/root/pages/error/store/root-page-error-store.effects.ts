// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppRootPageErrorStoreActions} from './root-page-error-store.actions';

/** Корень. Страницы. Ошибка. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageErrorStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppRootPageErrorStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppRootPageErrorStoreActions>
  ) {
  }
}
