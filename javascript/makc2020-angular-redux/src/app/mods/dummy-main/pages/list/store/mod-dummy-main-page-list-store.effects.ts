// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {forkJoin, Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyMainJobFilteredDeleteService} from '../../../jobs/filtered/delete/mod-dummy-main-job-filtered-delete.service';
import {AppModDummyMainJobItemDeleteService} from '../../../jobs/item/delete/mod-dummy-main-job-item-delete.service';
import {AppModDummyMainJobListDeleteService} from '../../../jobs/list/delete/mod-dummy-main-job-list-delete.service';
import {AppModDummyMainJobListGetResult} from '../../../jobs/list/get/mod-dummy-main-job-list-get-result';
import {AppModDummyMainJobListGetService} from '../../../jobs/list/get/mod-dummy-main-job-list-get.service';
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';
import {AppModDummyMainJobOptionsDummyOneToManyGetService} from '../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get.service';
import {AppModDummyMainPageListEnumActions} from '../enums/mod-dummy-main-page-list-enum-actions';
import {AppModDummyMainPageListStoreActionFilteredDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-filtered-delete-success';
import {AppModDummyMainPageListStoreActionItemDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-item-delete-success';
import {AppModDummyMainPageListStoreActionListDeleteSuccess} from './actions/mod-dummy-main-page-list-store-action-list-delete-success';
import {AppModDummyMainPageListStoreActionLoadSuccess} from './actions/mod-dummy-main-page-list-store-action-load-success';
import {AppModDummyMainPageListStoreActions} from './mod-dummy-main-page-list-store.actions';

/** Мод "DummyMain". Страницы. Список. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyMainPageListStoreEffects {

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
    ofType(AppModDummyMainPageListEnumActions.ItemDelete),
    switchMap(
      action =>
        this.appJobItemDelete.execute$(
          action.jobItemDeleteInput,
          this.executionHandlerOnDelete
        ).pipe(
          map(
            result =>
              new AppModDummyMainPageListStoreActionItemDeleteSuccess(result)
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
    ofType(AppModDummyMainPageListEnumActions.FilteredDelete),
    switchMap(
      action =>
        this.appJobFilteredDelete.execute$(
          action.jobListGetInput,
          this.executionHandlerOnDeleteFiltered
        ).pipe(
          map(
            result =>
              new AppModDummyMainPageListStoreActionFilteredDeleteSuccess(result)
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
    ofType(AppModDummyMainPageListEnumActions.ListDelete),
    switchMap(
      action =>
        this.appJobListDelete.execute$(
          action.jobListDeleteInput,
          this.executionHandlerOnDeleteList
        ).pipe(
          map(
            result =>
              new AppModDummyMainPageListStoreActionListDeleteSuccess(result)
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
      action => {
        const results$: Observable<any>[] = [
          this.appJobOptionsDummyOneToManyGet.execute$(this.executionHandlerOnLoad)
        ];

        const {
          jobListGetInput: input
        } = action;

        if (input) {
          results$.push(this.appJobListGet.execute$(input, this.executionHandlerOnLoad));
        }

        return forkJoin(results$).pipe(
          map(
            results => {
              let jobListGetResult: AppModDummyMainJobListGetResult;

              if (results.length > 1) {
                jobListGetResult = results[results.length - 1] as AppModDummyMainJobListGetResult;
              }

              return new AppModDummyMainPageListStoreActionLoadSuccess(
                jobListGetResult,
                results[0] as AppModDummyMainJobOptionsDummyOneToManyGetResult
              );
            }
          )
        );
      }
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyMainJobFilteredDeleteService} appJobFilteredDelete Задание на удаление отфильтрованного.
   * @param {AppModDummyMainJobItemDeleteService} appJobItemDelete Задание на удаление элемента.
   * @param {AppModDummyMainJobListGetService} appJobListGet Задание на получение списка.
   * @param {AppModDummyMainJobListDeleteService} appJobListDelete Задание на удаление списка.
   * @param {AppModDummyMainJobOptionsDummyOneToManyGetService} appJobOptionsDummyOneToManyGet
   * Задание на получение вариантов выбора сущности "DummyOneToMany".
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyMainPageListStoreActions>} extActions$ Поток действий.
   */
  constructor(
    protected appJobFilteredDelete: AppModDummyMainJobFilteredDeleteService,
    protected appJobItemDelete: AppModDummyMainJobItemDeleteService,
    protected appJobListGet: AppModDummyMainJobListGetService,
    protected appJobListDelete: AppModDummyMainJobListDeleteService,
    private appJobOptionsDummyOneToManyGet: AppModDummyMainJobOptionsDummyOneToManyGetService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyMainPageListStoreActions>
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
