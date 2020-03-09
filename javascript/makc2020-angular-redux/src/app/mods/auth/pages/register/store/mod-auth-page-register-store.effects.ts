// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppCoreNotificationService} from '@app/core/notification/core-notification.service';
import {AppHostPartAuthService} from '@app/host/parts/auth/host-part-auth.service';
import {AppModAuthPageRegisterEnumActions} from '../enums/mod-auth-page-register-enum-actions';
import {AppModAuthPageRegisterStoreActionSaveSuccess} from './actions/mod-auth-page-register-store-action-save-success';
import {AppModAuthPageRegisterStoreActions} from './mod-auth-page-register-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModAuthPageRegisterStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnSave = new AppCoreExecutionHandler();

  /**
   * Сохранение.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  save$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModAuthPageRegisterEnumActions.Save),
    switchMap(
      action =>
        this.appAuth.register$(
          action.jobRegisterInput,
          this.executionHandlerOnSave
        ).pipe(
          map(
            result =>
              new AppModAuthPageRegisterStoreActionSaveSuccess(result)
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostPartAuthService} appAuth Аутентификация.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModAuthPageRegisterStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appAuth: AppHostPartAuthService,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModAuthPageRegisterStoreActions>
  ) {
    this.executionHandlerOnSave.logger = appLogger;
    this.executionHandlerOnSave.notification = appNotification;
    this.executionHandlerOnSave.enableNotificationOnAll();
  }
}
