// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {forkJoin, Observable, of} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyTreeJobFilteredDeleteService} from '../../../jobs/filtered/delete/mod-dummy-tree-job-filtered-delete.service';
import {AppModDummyTreeJobItemDeleteService} from '../../../jobs/item/delete/mod-dummy-tree-job-item-delete.service';
import {AppModDummyTreeJobListDeleteService} from '../../../jobs/list/delete/mod-dummy-tree-job-list-delete.service';
import {AppModDummyTreeJobListGetResult} from '../../../jobs/list/get/mod-dummy-tree-job-list-get-result';
import {AppModDummyTreeJobListGetService} from '../../../jobs/list/get/mod-dummy-tree-job-list-get.service';
import {AppModDummyTreePageListEnumActions} from '../enums/mod-dummy-tree-page-list-enum-actions';
import {AppModDummyTreePageListStoreActionFilteredDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-filtered-delete-success';
import {AppModDummyTreePageListStoreActionItemDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-item-delete-success';
import {AppModDummyTreePageListStoreActionListDeleteSuccess} from './actions/mod-dummy-tree-page-list-store-action-list-delete-success';
import {AppModDummyTreePageListStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-list-store-action-load-success';
import {AppModDummyTreePageListStoreActions} from './mod-dummy-tree-page-list-store.actions';

/** Мод "DummyTree". Страницы. Список. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyTreePageListStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnDelete = new AppCoreExecutionHandler();

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnDeleteList = new AppCoreExecutionHandler();

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnDeleteFiltered = new AppCoreExecutionHandler();

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

  /**
   * Удаление.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  delete$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyTreePageListEnumActions.ItemDelete),
    switchMap(
      action =>
        this.appJobItemDelete.execute$(
          action.jobItemDeleteInput,
          this.executionHandlerOnDelete
        ).pipe(
          map(
            result =>
              new AppModDummyTreePageListStoreActionItemDeleteSuccess(result)
          )
        )
    )
  );

  /**
   * Удаление отфильтрованного.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  deleteFiltered$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyTreePageListEnumActions.FilteredDelete),
    switchMap(
      action =>
        this.appJobFilteredDelete.execute$(
          action.jobListGetInput,
          this.executionHandlerOnDeleteFiltered
        ).pipe(
          map(
            result =>
              new AppModDummyTreePageListStoreActionFilteredDeleteSuccess(result)
          )
        )
    )
  );

  /**
   * Удаление списка.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  deleteList$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyTreePageListEnumActions.ListDelete),
    switchMap(
      action =>
        this.appJobListDelete.execute$(
          action.jobListDeleteInput,
          this.executionHandlerOnDeleteList
        ).pipe(
          map(
            result =>
              new AppModDummyTreePageListStoreActionListDeleteSuccess(result)
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
      action => {
        const results$: Observable<any>[] = [];

        const {
          jobListGetInput: input
        } = action;

        if (input) {
          results$.push(this.appJobListGet.execute$(input, this.executionHandlerOnLoad));
        }

        if (results$.length > 0) {
          return forkJoin(results$).pipe(
            map(
              results => {
                let jobListGetResult: AppModDummyTreeJobListGetResult;

                if (results.length > 0) {
                  jobListGetResult = results[results.length - 1] as AppModDummyTreeJobListGetResult;
                }

                return new AppModDummyTreePageListStoreActionLoadSuccess(
                  jobListGetResult
                );
              }
            )
          );
        } else {
          return of(new AppModDummyTreePageListStoreActionLoadSuccess(null));
        }
      }
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobFilteredDeleteService} appJobFilteredDelete Задание на удаление отфильтрованного.
   * @param {AppModDummyTreeJobItemDeleteService} appJobItemDelete Задание на удаление элемента.
   * @param {AppModDummyTreeJobListGetService} appJobListGet Задание на получение списка.
   * @param {AppModDummyTreeJobListDeleteService} appJobListDelete Задание на удаление списка.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyTreePageListStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobFilteredDelete: AppModDummyTreeJobFilteredDeleteService,
    protected appJobItemDelete: AppModDummyTreeJobItemDeleteService,
    protected appJobListGet: AppModDummyTreeJobListGetService,
    protected appJobListDelete: AppModDummyTreeJobListDeleteService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyTreePageListStoreActions>
  ) {
    this.executionHandlerOnDelete.logger = appLogger;
    this.executionHandlerOnDelete.notification = appNotification;
    this.executionHandlerOnDelete.enableNotificationOnAll();

    this.executionHandlerOnDeleteFiltered.logger = appLogger;
    this.executionHandlerOnDeleteFiltered.notification = appNotification;
    this.executionHandlerOnDeleteFiltered.enableNotificationOnAll();

    this.executionHandlerOnDeleteList.logger = appLogger;
    this.executionHandlerOnDeleteList.notification = appNotification;
    this.executionHandlerOnDeleteList.enableNotificationOnAll();

    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;
  }
}
