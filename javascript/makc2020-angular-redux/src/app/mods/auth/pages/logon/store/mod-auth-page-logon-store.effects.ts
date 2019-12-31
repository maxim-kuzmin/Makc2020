// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Actions, Effect, ofType} from '@ngrx/effects';
import {Action} from '@ngrx/store';
import {Observable} from 'rxjs';
import {map, switchMap} from 'rxjs/operators';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostAuthService} from '@app/host/auth/host-auth.service';
import {AppHostAuthStore} from '@app/host/auth/host-auth-store';
import {AppModAuthPageLogonEnumActions} from '../enums/mod-auth-page-logon-enum-actions';
import {AppModAuthPageLogonStoreActionLoginSuccess} from './actions/mod-auth-page-logon-store-action-login-success';
import {AppModAuthPageLogonStoreActions} from './mod-auth-page-logon-store.actions';

/** Мод "Auth". Страницы. Вход в систему. Хранилище состояния. Эффекты. */
@Injectable()
export class AppModAuthPageLogonStoreEffects {

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
          this.appLogger,
          action.jobLoginInput
        ).pipe(
          map(
            result => {
              const {
                currentUser,
                isLoggedIn,
                redirectUrl
              } = this.appAuthStore.getState();

              return new AppModAuthPageLogonStoreActionLoginSuccess(
                currentUser,
                isLoggedIn,
                result,
                redirectUrl
              );
            }
          )
        )
    )
  );

  /**
   * Конструктор.
   * @param {AppHostAuthService} appAuth Аутентификация.
   * @param {AppHostAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Actions<AppModAuthPageLogonStoreActions>} extActions$ Поток действий.
   */
  constructor(
    private appAuth: AppHostAuthService,
    private appAuthStore: AppHostAuthStore,
    private appLogger: AppCoreLoggingService,
    private extActions$: Actions<AppModAuthPageLogonStoreActions>
  ) {
  }
}
