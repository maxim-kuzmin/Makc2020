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
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppModAuthPageLogonEnumActions} from '../enums/mod-auth-page-logon-enum-actions';
import {AppModAuthPageLogonStoreActionLoginSuccess} from './actions/mod-auth-page-logon-store-action-login-success';
import {AppModAuthPageLogonStoreActions} from './mod-auth-page-logon-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModAuthPageLogonStoreEffects {

  /** @type {AppCoreExecutionHandler} */
  private readonly executionHandlerOnLogin = new AppCoreExecutionHandler();

  /**
   * Ввод.
   * @returns {Observable<Action>} Поток действий.
   */
  @Effect()
  login$: Observable<Action> = this.extActions$.pipe(
    ofType(AppModAuthPageLogonEnumActions.Login),
    switchMap(
      action =>
        this.appAuth.login$(
          action.jobLoginInput,
          this.executionHandlerOnLogin
        ).pipe(
          map(
            result => {
              const {
                currentUser,
                isLoggedIn,
                returnUrl
              } = this.appAuthStore.getState();

              return new AppModAuthPageLogonStoreActionLoginSuccess(
                currentUser,
                isLoggedIn,
                result,
                returnUrl
              );
            }
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostPartAuthService} appAuth Аутентификация.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {AppCoreNotificationService} appNotification Извещение.
   * @param {Actions<AppModAuthPageLogonStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appAuth: AppHostPartAuthService,
    private appAuthStore: AppHostPartAuthStore,
    appLogger: AppCoreLoggingService,
    appNotification: AppCoreNotificationService,
    private extActions$: Actions<AppModAuthPageLogonStoreActions>
  ) {
    this.executionHandlerOnLogin.logger = appLogger;
    this.executionHandlerOnLogin.notification = appNotification;
  }
}
