// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {EMPTY, Observable, of, Subject} from 'rxjs';
import {switchMap, take} from 'rxjs/operators';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtService} from '@app/core/auth/types/jwt/core-auth-type-jwt.service';
import {AppCoreExecutionResult, appCoreExecutionResultCopy} from '@app/core/execution/core-execution-result';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostAuthCommonJobLoginInput} from '@app/host/auth/common/jobs/login/host-auth-common-job-login-input';
import {AppHostAuthCommonJobRegisterInput} from '@app/host/auth/common/jobs/register/host-auth-common-job-register-input';
import {AppHostAuthCommonJobRegisterResult} from '@app/host/auth/common/jobs/register/host-auth-common-job-register-result';
import {AppHostAuthService} from '@app/host/auth/host-auth.service';
import {AppHostAuthStore} from '@app/host/auth/host-auth-store';
import {AppModAuthPageLogonService} from '@app/mods/auth/pages/logon/mod-auth-page-logon.service';
import {AppModAuthPageRegisterService} from '@app/mods/auth/pages/register/mod-auth-page-register.service';
import {AppHostAuthJobCurrentUserGetService} from '@app/host/auth/jobs/current-user/get/host-auth-job-current-user-get.service';
import {AppRootAuthJobLoginJwtService} from './jobs/login/jwt/root-auth-job-login-jwt.service';
import {AppRootAuthJobRefreshJwtInput} from './jobs/refresh/jwt/root-auth-job-refresh-jwt-input';
import {AppRootAuthJobRefreshJwtService} from './jobs/refresh/jwt/root-auth-job-refresh-jwt.service';
import {AppRootAuthJobRegisterService} from './jobs/register/root-auth-job-register.service';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreAuthTypeOidcJobLoginService} from '@app/core/auth/types/oidc/jobs/login/core-auth-type-oidc-job-login.service';
import {AppCoreAuthTypeOidcJobLogoutService} from '@app/core/auth/types/oidc/jobs/logout/core-auth-type-oidc-job-logout.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
// tslint:disable-next-line:max-line-length
import {AppCoreAuthTypeOidcJobRefreshTokenService} from '@app/core/auth/types/oidc/jobs/resresh-token/core-auth-type-oidc-job-refresh-token.service';

/** Мод "Auth". Сервис. */
@Injectable()
export class AppRootAuthService extends AppHostAuthService {

  private refreshAccountViaOidcUnsubscribe$ = new Subject<boolean>();

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwt Аутентификация типа JWT.
   * @param {AppCoreAuthTypeOidcJobLoginService} appAuthTypeOidcJobLogin Задание на вход в систему для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobLogoutService} appAuthTypeOidcJobLogout Задание на выход из системы для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobRefreshTokenService} appAuthTypeOidcJobRefreshToken
   * Задание на освежение токена для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppHostAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppModAuthPageLogonService} appPageLogon Страница ввода в систему.
   * @param {AppModAuthPageLogonService} appPageRegister Страница регистрации.
   * @param {AppRootAuthJobLoginJwtService} appJobLogin Задание на вход в систему.
   * @param {AppRootAuthJobRefreshJwtService} appJobRefresh Задание на обновление.
   * @param {AppRootAuthJobRegisterService} appJobRegister Задание на регистрацию.
   * @param {AppHostAuthJobCurrentUserGetService} appJobCurrentUserGet Задание на получение текущего пользователя.
   * @param {AppCoreLoggingService} appLogger Регистратор.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    appAuthTypeJwt: AppCoreAuthTypeJwtService,
    appAuthTypeOidcJobLogin: AppCoreAuthTypeOidcJobLoginService,
    appAuthTypeOidcJobLogout: AppCoreAuthTypeOidcJobLogoutService,
    private appAuthTypeOidcJobRefreshToken: AppCoreAuthTypeOidcJobRefreshTokenService,
    appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    appAuthStore: AppHostAuthStore,
    appPageLogon: AppModAuthPageLogonService,
    appPageRegister: AppModAuthPageRegisterService,
    private appJobLogin: AppRootAuthJobLoginJwtService,
    private appJobRefresh: AppRootAuthJobRefreshJwtService,
    private appJobRegister: AppRootAuthJobRegisterService,
    private appJobCurrentUserGet: AppHostAuthJobCurrentUserGetService,
    private appLogger: AppCoreLoggingService,
    extRouter: Router
  ) {
    super(
      appAuthTypeJwt,
      appAuthTypeOidcJobLogin,
      appAuthTypeOidcJobLogout,
      appAuthTypeOidcStore,
      appAuthStore,
      extRouter
    );

    this.onRefreshAccountViaOidcGetState = this.onRefreshAccountViaOidcGetState.bind(this);
    this.onRefreshToken = this.onRefreshToken.bind(this);

    this.appAuthStore.runActionInit(appPageLogon.url, appPageRegister.url);
  }

  /**
   * @inheritDoc
   * @param {AppCoreLoggingService} logger
   * @returns {Observable<AppCoreExecutionResult>}
   */
  loadCurrentUser$(
    logger: AppCoreLoggingService
  ): Observable<AppCoreExecutionResult> {
    return this.appJobCurrentUserGet.execute$(this.appLogger).pipe(
      switchMap(
        output => {
          this.appAuthStore.runActionCurrentUserSet(output.data);

          const result = appCoreExecutionResultCopy(output);

          return of(result);
        }
      )
    );
  }

  /**
   * @inheritDoc
   * @param {AppCoreLoggingService} logger
   * @param {AppHostAuthCommonJobLoginInput} input
   * @returns {Observable<AppCoreExecutionResult>}
   */
  login$(
    logger: AppCoreLoggingService,
    input: AppHostAuthCommonJobLoginInput
  ): Observable<AppCoreExecutionResult> {
    this.logout(logger);

    return this.appJobLogin.execute$(logger, input).pipe(
      switchMap(
        output => {
          this.loadLoginOutput(logger, output.data);

          const result = appCoreExecutionResultCopy(output);

          return of(result);
        }
      )
    );
  }

  /**
   * @inheritDoc
   * @param {AppCoreLoggingService} logger
   * @param {AppHostAuthCommonJobRegisterInput} input
   * @returns {Observable<AppHostAuthCommonJobRegisterResult>}
   */
  register$(
    logger: AppCoreLoggingService,
    input: AppHostAuthCommonJobRegisterInput
  ): Observable<AppHostAuthCommonJobRegisterResult> {
    return this.appJobRegister.execute$(logger, input);
  }

  /**
   * @inheritDoc
   * @param {AppCoreLoggingService} logger
   * @param {string} url
   * @returns {boolean}
   */
  tryLoginAndReturn$(
    logger: AppCoreLoggingService,
    url: string
  ): Observable<boolean> {
    return this.refreshAccount$(logger).pipe(
      take(1),
      () => {
        this.appAuthStore.runActionRedirectUrlSet(url);

        const {
          isLoggedIn
        } = this.appAuthStore.getState();

        if (!isLoggedIn) {
          this.tryLogin(logger);
        }

        return of(isLoggedIn);
      }
    );
  }

  /** @param {AppCoreLoggingService} logger Регистратор. */
  private refreshAccount$(
    logger: AppCoreLoggingService
  ): Observable<never> {
    switch (this.authType) {
      case AppCoreAuthEnumTypes.Jwt:
        return this.refreshAccountViaJwt(logger);
      case AppCoreAuthEnumTypes.Oidc:
        return this.refreshAccountViaOidc();
      default:
        return EMPTY;
    }
  }

  /** @param {AppCoreLoggingService} logger Регистратор. */
  private refreshAccountViaJwt(
    logger: AppCoreLoggingService
  ): Observable<never> {
    const accessToken = this.appAuthTypeJwt.getAccessToken();

    if (accessToken) {
      if (this.appAuthTypeJwt.isTokenExpired(accessToken)) {
        const refreshToken = this.appAuthTypeJwt.getRefreshToken();

        if (refreshToken) {
          this.logout(logger);

          const input = new AppRootAuthJobRefreshJwtInput(refreshToken);

          return this.appJobRefresh.execute$(this.appLogger, input).pipe(
            switchMap(
              result => {
                this.loadLoginOutput(logger, result.data);
                return EMPTY;
              }
            )
          );
        }
      }

      return this.onRefreshToken(true);
    }

    return EMPTY;
  }

  private onRefreshAccountViaOidcGetState(state: AppCoreAuthTypeOidcState) {
    const {
      isInitialized
    } = state;

    if (isInitialized) {
      this.refreshAccountViaOidcUnsubscribe$.next(true);
      this.refreshAccountViaOidcUnsubscribe$.complete();

      this.refreshTokenViaOidc();
    }
  }

  /**
   * @param {boolean} isTokenValid
   * @returns {Observable<never>}
   */
  private onRefreshToken(isTokenValid: boolean): Observable<never> {
    if (isTokenValid) {
      const {
        isLoggedIn
      } = this.appAuthStore.getState();

      if (!isLoggedIn) {
        return this.loadCurrentUser$(this.appLogger).pipe(
          switchMap(() => EMPTY)
        );
      }
    }

    return EMPTY;
  }

  private refreshAccountViaOidc(): Observable<never> {
    const {
      isInitialized
    } = this.appAuthTypeOidcStore.getState();

    if (isInitialized) {
      this.refreshTokenViaOidc();
    } else {
      this.appAuthTypeOidcStore.getState$(
        this.refreshAccountViaOidcUnsubscribe$
      ).subscribe(
        this.onRefreshAccountViaOidcGetState
      );
    }

    return EMPTY;
  }

  private refreshTokenViaOidc() {
    this.appAuthTypeOidcJobRefreshToken.execute$(
      this.appLogger
    ).pipe(
      switchMap(result => of(result.isOk))
    ).subscribe(
      this.onRefreshToken
    );
  }}
