// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutFooterActions} from '../host-layout-footer-actions';
import {AppHostLayoutFooterStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';
import {AppHostLayoutFooterStoreActions} from './host-layout-footer-store.actions';
import {AppHostLayoutFooterJobContentLoadService} from '../jobs/content/load/host-layout-footer-job-content-load.service';

/** Хост. Разметка. Подвал. Хранилище состояния. Эффекты. */
@Injectable()
export class AppHostLayoutFooterStoreEffects {

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppHostLayoutFooterActions.Load),
    switchMap(
      action =>
        this.appJobContentLoad.execute$(
          this.appLogger,
          action.jobContentLoadInput
        ).pipe(
          map(
            result =>
              new AppHostLayoutFooterStoreActionLoadSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostLayoutFooterJobContentLoadService} appJobContentLoad Задание загрузку содержимого.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppHostLayoutFooterStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobContentLoad: AppHostLayoutFooterJobContentLoadService,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppHostLayoutFooterStoreActions>
  ) {
  }
}
