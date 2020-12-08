// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions} from '@ngrx/effects';
import {AppRootPageSiteStoreActions} from './root-page-site-store.actions';

/** Корень. Страницы. Сайт. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageSiteStoreEffects {

  /**
   * Конструктор.
   * @param {Actions<AppRootPageSiteStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private extActions$: Actions<AppRootPageSiteStoreActions>
  ) {
  }
}
