// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {AppRootPageContactsStoreActions} from './root-page-contacts-store.actions';
import {Observable} from 'rxjs';
import {Action} from '@ngrx/store';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppRootPageContactsEnumActions} from '../enums/root-page-contacts-enum-actions';
import {AppRootPageContactsStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';
import {AppRootPageContactsJobContentLoadService} from '../jobs/content/load/host-layout-footer-job-content-load.service';

/** Корень. Страницы. Контакты. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageContactsStoreEffects {

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppRootPageContactsEnumActions.Load),
    switchMap(
      action =>
        this.appJobContentLoad.execute$(
          this.appLogger,
          action.jobContentLoadInput
        ).pipe(
          map(
            result =>
              new AppRootPageContactsStoreActionLoadSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppRootPageContactsJobContentLoadService} appJobContentLoad Задание загрузку содержимого.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppRootPageContactsStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobContentLoad: AppRootPageContactsJobContentLoadService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppRootPageContactsStoreActions>
  ) {
  }
}
