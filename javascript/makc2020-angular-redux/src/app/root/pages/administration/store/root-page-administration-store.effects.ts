// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppRootPageAdministrationStoreActions} from './root-page-administration-store.actions';

/** Корень. Страницы. Администрирование. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageAdministrationStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppRootPageAdministrationStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppRootPageAdministrationStoreActions>
  ) {
  }
}
