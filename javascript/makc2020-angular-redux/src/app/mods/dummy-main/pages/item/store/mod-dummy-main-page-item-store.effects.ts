// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {forkJoin, Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyMainJobItemGetResult} from '../../../jobs/item/get/mod-dummy-main-job-item-get-result';
import {AppModDummyMainJobItemGetService} from '../../../jobs/item/get/mod-dummy-main-job-item-get.service';
import {AppModDummyMainJobItemInsertService} from '../../../jobs/item/insert/mod-dummy-main-job-item-insert.service';
import {AppModDummyMainJobItemUpdateService} from '../../../jobs/item/update/mod-dummy-main-job-item-update.service';
// tslint:disable-next-line:max-line-length
import {AppModDummyMainJobOptionsDummyManyToManyGetResult} from '../../../jobs/options/dummy-many-to-many/get/mod-dummy-main-job-options-dummy-many-to-many-get-result';
// tslint:disable-next-line:max-line-length
import {AppModDummyMainJobOptionsDummyManyToManyGetService} from '../../../jobs/options/dummy-many-to-many/get/mod-dummy-main-job-options-dummy-many-to-many-get.service';
// tslint:disable-next-line:max-line-length
import {AppModDummyMainJobOptionsDummyOneToManyGetResult} from '../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get-result';
// tslint:disable-next-line:max-line-length
import {AppModDummyMainJobOptionsDummyOneToManyGetService} from '../../../jobs/options/dummy-one-to-many/get/mod-dummy-main-job-options-dummy-one-to-many-get.service';
import {AppModDummyMainPageItemEnumActions} from '../enums/mod-dummy-main-page-item-enum-actions';
import {AppModDummyMainPageItemStoreActionLoadSuccess} from './actions/mod-dummy-main-page-item-store-action-load-success';
import {AppModDummyMainPageItemStoreActionSaveSuccess} from './actions/mod-dummy-main-page-item-store-action-save-success';
import {AppModDummyMainPageItemStoreActions} from './mod-dummy-main-page-item-store.actions';

/** Мод "DummyMain". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyMainPageItemStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLoad = new AppCoreExecutionHandler();

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnSave = new AppCoreExecutionHandler();

  /**
   * Получение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  load$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyMainPageItemEnumActions.Load),
    switchMap(
      action => {
        const results$: Observable<any>[] = [
          this.appJobOptionsDummyManyToManyGet.execute$(this.executionHandlerOnLoad),
          this.appJobOptionsDummyOneToManyGet.execute$(this.executionHandlerOnLoad)
        ];

        const {
          jobItemGetInput: input
        } = action;

        if (input && input.isForUpdate) {
          results$.push(this.appJobItemGet.execute$(input, this.executionHandlerOnLoad));
        }

        return forkJoin(results$).pipe(
          map(
            results => {
              let jobItemGetResult: AppModDummyMainJobItemGetResult;

              if (results.length > 2) {
                jobItemGetResult = results[2] as AppModDummyMainJobItemGetResult;
              }

              return new AppModDummyMainPageItemStoreActionLoadSuccess(
                jobItemGetResult,
                results[0] as AppModDummyMainJobOptionsDummyManyToManyGetResult,
                results[1] as AppModDummyMainJobOptionsDummyOneToManyGetResult
              );
            }
          )
        );
      }
    )
  );

  /**
   * Сохранение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  save$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyMainPageItemEnumActions.Save),
    switchMap(
      action => {
        const {
          jobItemGetOutput: input
        } = action;

        const {
          id
        } = input.objectDummyMain;

        const result$ = id > 0
          ? this.appJobItemUpdate.execute$(input, this.executionHandlerOnLoad)
          : this.appJobItemInsert.execute$(input, this.executionHandlerOnLoad);

        return result$.pipe(
          map(
            result =>
              new AppModDummyMainPageItemStoreActionSaveSuccess(result)
          )
        );
      }
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyMainJobItemGetService} appJobItemGet
   * Задание на получение элемента.
   * @param {AppModDummyMainJobItemInsertService} appJobItemInsert
   * Задание на вставку элемента.
   * @param {AppModDummyMainJobItemUpdateService} appJobItemUpdate
   * Задание на обновление элемента.
   * @param {AppModDummyMainJobOptionsDummyManyToManyGetService} appJobOptionsDummyManyToManyGet
   * Задание на получение вариантов выбора сущности "DummyManyToMany".
   * @param {AppModDummyMainJobOptionsDummyOneToManyGetService} appJobOptionsDummyOneToManyGet
   * Задание на получение вариантов выбора сущности "DummyOneToMany".
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyMainPageItemStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobItemGet: AppModDummyMainJobItemGetService,
    private appJobItemInsert: AppModDummyMainJobItemInsertService,
    private appJobItemUpdate: AppModDummyMainJobItemUpdateService,
    private appJobOptionsDummyManyToManyGet: AppModDummyMainJobOptionsDummyManyToManyGetService,
    private appJobOptionsDummyOneToManyGet: AppModDummyMainJobOptionsDummyOneToManyGetService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyMainPageItemStoreActions>
  ) {
    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;

    this.executionHandlerOnSave.logger = appLogger;
    this.executionHandlerOnSave.notification = appNotification;
    this.executionHandlerOnSave.enableNotificationOnAll();
  }
}
