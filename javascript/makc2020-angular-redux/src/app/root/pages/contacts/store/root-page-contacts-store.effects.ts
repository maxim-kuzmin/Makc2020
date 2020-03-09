// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Observable} from 'rxjs';
import {Action} from '@ngrx/store';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppRootPageContactsEnumActions} from '../enums/root-page-contacts-enum-actions';
import {AppRootPageContactsStoreActionLoadSuccess} from './actions/host-layout-footer-store-action-load-success';
import {AppRootPageContactsStoreActions} from './root-page-contacts-store.actions';
import {AppRootPageContactsJobContentLoadService} from '../jobs/content/load/host-layout-footer-job-content-load.service';

/** Корень. Страницы. Контакты. Хранилище состояния. Эффекты. */
@Injectable()
export class AppRootPageContactsStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

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
          action.jobContentLoadInput,
          this.executionHandlerOnLoad
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
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppRootPageContactsStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobContentLoad: AppRootPageContactsJobContentLoadService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppRootPageContactsStoreActions>
  ) {
    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
