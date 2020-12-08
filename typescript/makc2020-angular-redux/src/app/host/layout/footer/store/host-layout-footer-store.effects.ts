// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostLayoutFooterActions} from '../host-layout-footer-actions';
import {AppHostLayoutFooterStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';
import {AppHostLayoutFooterStoreActions} from './host-layout-footer-store.actions';
import {AppHostLayoutFooterJobContentLoadService} from '../jobs/content/load/host-layout-footer-job-content-load.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';

/** Хост. Разметка. Подвал. Хранилище состояния. Эффекты. */
@Injectable()
export class AppHostLayoutFooterStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

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
          action.jobContentLoadInput,
          this.executionHandlerOnLoad
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
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppHostLayoutFooterStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobContentLoad: AppHostLayoutFooterJobContentLoadService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppHostLayoutFooterStoreActions>
  ) {
    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
