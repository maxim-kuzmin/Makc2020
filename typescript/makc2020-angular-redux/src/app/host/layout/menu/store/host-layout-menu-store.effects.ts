// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppHostLayoutMenuActions} from '../host-layout-menu-actions';
import {AppHostLayoutMenuStoreActionLoadSuccess} from './actions/host-layout-menu-store-action-load-success';
import {AppHostLayoutMenuStoreActions} from './host-layout-menu-store.actions';
import {AppHostPartMenuJobNodesFindService} from '@app/host/parts/menu/jobs/nodes/find/host-part-menu-job-nodes-find.service';

/** Хост. Разметка. Меню. Хранилище состояния. Эффекты. */
@Injectable()
export class AppHostLayoutMenuStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppHostLayoutMenuActions.Load),
    switchMap(
      action =>
        this.appJobNodesFind.execute$(
          action.jobNodesFindInput,
          this.executionHandlerOnLoad
        ).pipe(
          map(
            result =>
              new AppHostLayoutMenuStoreActionLoadSuccess(result, action.menuLevel)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostPartMenuJobNodesFindService} appJobNodesFind Задание на поиск узлов.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppHostLayoutMenuStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobNodesFind: AppHostPartMenuJobNodesFindService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppHostLayoutMenuStoreActions>
  ) {
    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
