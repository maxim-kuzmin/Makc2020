// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {EMPTY, forkJoin, Observable, of} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppModDummyTreeJobItemGetResult} from '../../../jobs/item/get/mod-dummy-tree-job-item-get-result';
import {AppModDummyTreeJobItemGetService} from '../../../jobs/item/get/mod-dummy-tree-job-item-get.service';
import {AppModDummyTreeJobItemInsertService} from '../../../jobs/item/insert/mod-dummy-tree-job-item-insert.service';
import {AppModDummyTreeJobItemUpdateService} from '../../../jobs/item/update/mod-dummy-tree-job-item-update.service';
// tslint:disable-next-line:max-line-length
import {AppModDummyTreePageItemEnumActions} from '../enums/mod-dummy-tree-page-item-enum-actions';
import {AppModDummyTreePageItemStoreActionLoadSuccess} from './actions/mod-dummy-tree-page-item-store-action-load-success';
import {AppModDummyTreePageItemStoreActionSaveSuccess} from './actions/mod-dummy-tree-page-item-store-action-save-success';
import {AppModDummyTreePageItemStoreActions} from './mod-dummy-tree-page-item-store.actions';

/** Мод "DummyTree". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModDummyTreePageItemStoreEffects {

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
    ofType(AppModDummyTreePageItemEnumActions.Load),
    switchMap(
      action => {
        const {
          jobItemGetInput: input
        } = action;

        if (input && input.isForUpdate) {
          return this.appJobItemGet.execute$(input, this.executionHandlerOnLoad).pipe(
            map(
              result => {
                return new AppModDummyTreePageItemStoreActionLoadSuccess(
                  result
                );
              }
            )
          );
        } else {
          const result = new AppModDummyTreePageItemStoreActionLoadSuccess(null);

          return of(result);
        }
      }
    )
  );

  /**
   * Сохранение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  save$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModDummyTreePageItemEnumActions.Save),
    switchMap(
      action => {
        const {
          jobItemGetOutput: input
        } = action;

        const {
          id
        } = input.objectDummyTree;

        const result$ = id > 0
          ? this.appJobItemUpdate.execute$(input, this.executionHandlerOnLoad)
          : this.appJobItemInsert.execute$(input, this.executionHandlerOnLoad);

        return result$.pipe(
          map(
            result =>
              new AppModDummyTreePageItemStoreActionSaveSuccess(result)
          )
        );
      }
    )
  );

  /**
   * Конструктор.
   * @param {AppModDummyTreeJobItemGetService} appJobItemGet
   * Задание на получение элемента.
   * @param {AppModDummyTreeJobItemInsertService} appJobItemInsert
   * Задание на вставку элемента.
   * @param {AppModDummyTreeJobItemUpdateService} appJobItemUpdate
   * Задание на обновление элемента.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModDummyTreePageItemStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appJobItemGet: AppModDummyTreeJobItemGetService,
    private appJobItemInsert: AppModDummyTreeJobItemInsertService,
    private appJobItemUpdate: AppModDummyTreeJobItemUpdateService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModDummyTreePageItemStoreActions>
  ) {
    this.executionHandlerOnLoad.logger = appLogger;
    this.executionHandlerOnLoad.notification = appNotification;

    this.executionHandlerOnSave.logger = appLogger;
    this.executionHandlerOnSave.notification = appNotification;
    this.executionHandlerOnSave.enableNotificationOnAll();
  }
}
