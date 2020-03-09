// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyMainJobListGetService} from '../../../jobs/list/get/mod-dummy-main-job-list-get.service';
import {AppModDummyMainPageListEnumActions} from '../enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListStoreActionLoadSuccess} from './actions/mod-dummy-main-page-list-store-action-load-success';
import {AppModDummyMainPageListStoreActions} from './mod-dummy-main-page-list-store.actions';
import {AppModDummyMainPageListStoreActionDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-delete-success';
import {AppModDummyMainJobItemDeleteService} from '../../../jobs/item/delete/mod-dummy-main-job-item-delete.service';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyMainPageListStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnDelete = new AppCoreExecutionHandler();

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

  /**
   * Удаление.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  delete$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyMainPageListEnumActions.Delete),
    switchMap(
      action =>
        this.appJobItemDelete.execute$(
          action.jobItemGetInput,
          this.executionHandlerOnDelete
        ).pipe(
          map(
            result =>
              new AppModDummyMainPageListStoreActionDeleteSuccess(result)
          )
        )
    )
  );

  /**
   * Загрузка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyMainPageListEnumActions.Load),
    switchMap(
      action =>
        this.appJobListGet.execute$(
          action.jobListGetInput,
          this.executionHandlerOnLoad
        ).pipe(
          map(
            result =>
              new AppModDummyMainPageListStoreActionLoadSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemDeleteService} appJobItemDelete Задание на удаление элемента.
   * @param {AppModDummyMainJobListGetService} appJobListGet Задание на получение списка.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyMainPageListStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobItemDelete: AppModDummyMainJobItemDeleteService,
    protected appJobListGet: AppModDummyMainJobListGetService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyMainPageListStoreActions>
  ) {
    this.executionHandlerOnDelete.logger = appLogger;
    this.executionHandlerOnDelete.notification = appNotification;
    this.executionHandlerOnDelete.enableNotificationOnAll();

    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
