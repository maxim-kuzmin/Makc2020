// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyTreeJobListGetService} from '../../../jobs/list/get/mod-dummy-tree-job-list-get.service';
import {AppModDummyTreePageListEnumActions} from '../enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-list-store-action-load-success';
import {AppModDummyTreePageListStoreActions} from './mod-dummy-tree-page-list-store.actions';
import {AppModDummyTreePageListStoreActionDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-delete-success';
import {AppModDummyTreeJobItemDeleteService} from '../../../jobs/item/delete/mod-dummy-tree-job-item-delete.service';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyTreePageListStoreEffects {

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
    ofType(AppModDummyTreePageListEnumActions.Delete),
    switchMap(
      action =>
        this.appJobItemDelete.execute$(
          action.jobItemGetInput,
          this.executionHandlerOnDelete
        ).pipe(
          map(
            result =>
              new AppModDummyTreePageListStoreActionDeleteSuccess(result)
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
    ofType(AppModDummyTreePageListEnumActions.Load),
    switchMap(
      action =>
        this.appJobListGet.execute$(
          action.jobListGetInput,
          this.executionHandlerOnLoad
        ).pipe(
          map(
            result =>
              new AppModDummyTreePageListStoreActionLoadSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemDeleteService} appJobItemDelete Задание на удаление элемента.
   * @param {AppModDummyTreeJobListGetService} appJobListGet Задание на получение списка.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyTreePageListStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobItemDelete: AppModDummyTreeJobItemDeleteService,
    protected appJobListGet: AppModDummyTreeJobListGetService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyTreePageListStoreActions>
  ) {
    this.executionHandlerOnDelete.logger = appLogger;
    this.executionHandlerOnDelete.notification = appNotification;
    this.executionHandlerOnDelete.enableNotificationOnAll();

    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
