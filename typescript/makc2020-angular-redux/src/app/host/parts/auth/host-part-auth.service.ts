// //Author Maxim Kuzmin//makc//

import {Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {switchMap} from 'rxjs/operators';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtService} from '@app/core/auth/types/jwt/core-auth-type-jwt.service';
import {AppCoreAuthTypeOidcJobLoginInput} from '@app/core/auth/types/oidc/jobs/login/core-auth-type-oidc-job-login-input';
import {AppCoreAuthTypeOidcJobLoginService} from '@app/core/auth/types/oidc/jobs/login/core-auth-type-oidc-job-login.service';
import {AppCoreAuthTypeOidcJobLogoutService} from '@app/core/auth/types/oidc/jobs/logout/core-auth-type-oidc-job-logout.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartAuthCommonJobLoginInput} from './common/jobs/login/host-part-auth-common-job-login-input';
import {AppHostPartAuthCommonJobLoginJwtOutput} from './common/jobs/login/jwt/host-part-auth-common-job-login-jwt-output';
import {AppHostPartAuthCommonJobRegisterInput} from './common/jobs/register/host-part-auth-common-job-register-input';
import {AppHostPartAuthCommonJobRegisterResult} from './common/jobs/register/host-part-auth-common-job-register-result';
import {AppHostPartAuthStore} from './host-part-auth-store';

/** Хост. Часть "Auth". Сервис. */
export abstract class AppHostPartAuthService {

  private removeCurrentUserAndTokensViaOidcUnsubscribe$ = new Subject<boolean>();

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwt Аутентификация типа JWT.
   * @param {AppCoreAuthTypeOidcJobLoginService} appAuthTypeOidcJobLogin Задание на вход в систему для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobLogoutService} appAuthTypeOidcJobLogout Задание на выход из системы для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {Router} extRouter Маршрутизатор.
   */
  protected constructor(
    protected appAuthTypeJwt: AppCoreAuthTypeJwtService,
    private appAuthTypeOidcJobLogin: AppCoreAuthTypeOidcJobLoginService,
    private appAuthTypeOidcJobLogout: AppCoreAuthTypeOidcJobLogoutService,
    protected appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    protected appAuthStore: AppHostPartAuthStore,
    protected appSettings: AppCoreSettings,
    private extRouter: Router
  ) {
    this.onRemoveCurrentUserAndTokensViaOidcGetState = this.onRemoveCurrentUserAndTokensViaOidcGetState.bind(this);
  }

  /**
   * Загрузить текущего пользователя.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppCoreExecutionResult>}
   * Поток с результатом выполнения.
   */
  abstract loadCurrentUser$(
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult>;

  /**
   * Войти в систему.
   * @param {AppHostPartAuthCommonJobLoginInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppCoreExecutionResult>}
   * Поток с результатом выполнения.
   */
  abstract login$(
    input: AppHostPartAuthCommonJobLoginInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult>;

  /**
   * Выйти из системы.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   */
  logout(
    handler: AppCoreExecutionHandler
  ) {
    const {
      isLoggedIn
    } = this.appAuthStore.getState();

    if (isLoggedIn) {
      this.removeCurrentUserAndTokens(handler);
    }
  }

  /**
   * Зарегистрировать.
   * @param {AppHostPartAuthCommonJobRegisterInput} input Ввод.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {Observable<AppHostPartAuthCommonJobRegisterResult>} Результирующий поток.
   */
  abstract register$(
    input: AppHostPartAuthCommonJobRegisterInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppHostPartAuthCommonJobRegisterResult>;

  /**
   * Попробовать войти в систему и вернуться.
   * @param returnUrl URL возврата.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   * @returns {boolean} Признак успешного входа.
   */
  abstract tryLoginAndReturn$(
    returnUrl: string,
    handler: AppCoreExecutionHandler
  ): Observable<boolean>;

  /**
   * Загрузить вывод от задания на вход в систему.
   * @param {AppHostPartAuthCommonJobLoginJwtOutput} output Данные.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   */
  protected loadLoginOutput(
    output: AppHostPartAuthCommonJobLoginJwtOutput,
    handler: AppCoreExecutionHandler
  ) {
    if (output) {
      this.appAuthStore.runActionCurrentUserSet(output.currentUser);

      if (output.accessToken) {
        this.appAuthTypeJwt.setAccessToken(output.accessToken);
      }

      if (output.refreshToken) {
        this.appAuthTypeJwt.setRefreshToken(output.refreshToken);
      }
    } else {
      this.removeCurrentUserAndTokens(handler);
    }
  }

  /**
   * Попробовать войти в систему.
   * @param {string} returnUrl URL возврата.
   * @param {AppCoreExecutionHandler} handler Обработчик.
   */
  protected tryLogin(
    returnUrl: string,
    handler: AppCoreExecutionHandler
  ) {
    const {
      authType
    } = this.appSettings;

    switch (authType) {
      case AppCoreAuthEnumTypes.Jwt: {
        const {
          logonUrl
        } = this.appAuthStore.getState();

        if (logonUrl) {
          this.extRouter.navigate([logonUrl]).catch();
        }
      }
        break;
      case AppCoreAuthEnumTypes.Oidc: {
        const input = new AppCoreAuthTypeOidcJobLoginInput(returnUrl);

        this.appAuthTypeOidcJobLogin.execute(input, handler);
      }
        break;
    }
  }

  /** @param {AppCoreExecutionHandler} handler */
  private removeCurrentUserAndTokens(
    handler: AppCoreExecutionHandler
  ) {
    this.appAuthStore.runActionCurrentUserSet();

    const {
      authType
    } = this.appSettings;

    switch (authType) {
      case AppCoreAuthEnumTypes.Jwt:
        this.removeCurrentUserAndTokensViaJwt();
        break;
      case AppCoreAuthEnumTypes.Oidc:
        this.removeCurrentUserAndTokensViaOidc(handler);
        break;
    }
  }

  private removeCurrentUserAndTokensViaJwt() {
    this.appAuthTypeJwt.removeAccessToken();
    this.appAuthTypeJwt.removeRefreshToken();

    const {
      logonUrl
    } = this.appAuthStore.getState();

    this.extRouter.navigate([logonUrl]).catch();
  }

  /** @param {AppCoreExecutionHandler} handler */
  private removeCurrentUserAndTokensViaOidc(
    handler: AppCoreExecutionHandler
  ) {
    this.appAuthTypeOidcStore.getState$(
      this.removeCurrentUserAndTokensViaOidcUnsubscribe$
    ).pipe(
      switchMap(state => of({
        handler,
        state
      }))
    ).subscribe(
      this.onRemoveCurrentUserAndTokensViaOidcGetState
    );
  }

  /** @param {
      handler: AppCoreExecutionHandler,
      state: AppCoreAuthTypeOidcState
    } input */
  private onRemoveCurrentUserAndTokensViaOidcGetState(
    input: {
      handler: AppCoreExecutionHandler,
      state: AppCoreAuthTypeOidcState
    }
  ) {
    const {
      state
    } = input;

    const {
      isInitialized
    } = state;

    if (isInitialized) {
      this.removeCurrentUserAndTokensViaOidcUnsubscribe$.next(true);
      this.removeCurrentUserAndTokensViaOidcUnsubscribe$.complete();

      const {
        handler
      } = input;

      this.appAuthTypeOidcJobLogout.execute(handler);
    }
  }
}
