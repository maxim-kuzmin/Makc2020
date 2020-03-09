// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {EMPTY, Observable, of, Subject} from 'rxjs';
import {switchMap, take} from 'rxjs/operators';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtService} from '@app/core/auth/types/jwt/core-auth-type-jwt.service';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreAuthTypeOidcJobLoginService} from '@app/core/auth/types/oidc/jobs/login/core-auth-type-oidc-job-login.service';
import {AppCoreAuthTypeOidcJobLogoutService} from '@app/core/auth/types/oidc/jobs/logout/core-auth-type-oidc-job-logout.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
// tslint:disable-next-line:max-line-length
import {AppCoreAuthTypeOidcJobRefreshTokenService} from '@app/core/auth/types/oidc/jobs/resresh-token/core-auth-type-oidc-job-refresh-token.service';
import {AppCoreExecutionHandler} from '@app/core/execution/core-execution-handler';
import {AppCoreExecutionResult, appCoreExecutionResultCopy} from '@app/core/execution/core-execution-result';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartAuthCommonJobLoginInput} from '@app/host/parts/auth/common/jobs/login/host-part-auth-common-job-login-input';
import {AppHostPartAuthCommonJobRegisterInput} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-input';
import {AppHostPartAuthCommonJobRegisterResult} from '@app/host/parts/auth/common/jobs/register/host-part-auth-common-job-register-result';
import {AppHostPartAuthService} from '@app/host/parts/auth/host-part-auth.service';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
import {AppModAuthPageLogonService} from '@app/mods/auth/pages/logon/mod-auth-page-logon.service';
import {AppModAuthPageRegisterService} from '@app/mods/auth/pages/register/mod-auth-page-register.service';
// tslint:disable-next-line:max-line-length
import {AppHostPartAuthJobCurrentUserGetService} from '@app/host/parts/auth/jobs/current-user/get/host-part-auth-job-current-user-get.service';
import {AppRootPartAuthJobLoginJwtService} from './jobs/login/jwt/root-part-auth-job-login-jwt.service';
import {AppRootPartAuthJobRefreshJwtInput} from './jobs/refresh/jwt/root-part-auth-job-refresh-jwt-input';
import {AppRootPartAuthJobRefreshJwtService} from './jobs/refresh/jwt/root-part-auth-job-refresh-jwt.service';
import {AppRootPartAuthJobRegisterService} from './jobs/register/root-part-auth-job-register.service';

/** Корень. Часть "Auth". Сервис. */
@Injectable()
export class AppRootPartAuthService extends AppHostPartAuthService {

  private refreshAccountViaOidcUnsubscribe$ = new Subject<boolean>();

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwt Аутентификация типа JWT.
   * @param {AppCoreAuthTypeOidcJobLoginService} appAuthTypeOidcJobLogin Задание на вход в систему для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobLogoutService} appAuthTypeOidcJobLogout Задание на выход из системы для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobRefreshTokenService} appAuthTypeOidcJobRefreshToken
   * Задание на освежение токена для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации типа OIDC.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppModAuthPageLogonService} appPageLogon Страница ввода в систему.
   * @param {AppModAuthPageLogonService} appPageRegister Страница регистрации.
   * @param {AppRootPartAuthJobLoginJwtService} appJobLogin Задание на вход в систему.
   * @param {AppRootPartAuthJobRefreshJwtService} appJobRefresh Задание на обновление.
   * @param {AppRootPartAuthJobRegisterService} appJobRegister Задание на регистрацию.
   * @param {AppHostPartAuthJobCurrentUserGetService} appJobCurrentUserGet Задание на получение текущего пользователя.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    appAuthTypeJwt: AppCoreAuthTypeJwtService,
    appAuthTypeOidcJobLogin: AppCoreAuthTypeOidcJobLoginService,
    appAuthTypeOidcJobLogout: AppCoreAuthTypeOidcJobLogoutService,
    private appAuthTypeOidcJobRefreshToken: AppCoreAuthTypeOidcJobRefreshTokenService,
    appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    appAuthStore: AppHostPartAuthStore,
    appPageLogon: AppModAuthPageLogonService,
    appPageRegister: AppModAuthPageRegisterService,
    private appJobLogin: AppRootPartAuthJobLoginJwtService,
    private appJobRefresh: AppRootPartAuthJobRefreshJwtService,
    private appJobRegister: AppRootPartAuthJobRegisterService,
    private appJobCurrentUserGet: AppHostPartAuthJobCurrentUserGetService,
    appSettings: AppCoreSettings,
    extRouter: Router
  ) {
    super(
      appAuthTypeJwt,
      appAuthTypeOidcJobLogin,
      appAuthTypeOidcJobLogout,
      appAuthTypeOidcStore,
      appAuthStore,
      appSettings,
      extRouter
    );

    this.onRefreshAccountViaOidcGetState = this.onRefreshAccountViaOidcGetState.bind(this);
    this.onRefreshToken = this.onRefreshToken.bind(this);

    this.appAuthStore.runActionInit(appPageLogon.url, appPageRegister.url);
  }

  /** @inheritDoc
   * @param {AppCoreExecutionHandler} handler
   * @returns {Observable<AppCoreExecutionResult>}
   */
  loadCurrentUser$(
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult> {
    return this.appJobCurrentUserGet.execute$(handler).pipe(
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
   * @param {AppHostPartAuthCommonJobLoginInput} input
   * @param {AppCoreExecutionHandler} handler
   * @returns {Observable<AppCoreExecutionResult>}
   */
  login$(
    input: AppHostPartAuthCommonJobLoginInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppCoreExecutionResult> {
    this.logout(handler);

    return this.appJobLogin.execute$(input, handler).pipe(
      switchMap(
        output => {
          this.loadLoginOutput(output.data, handler);

          const result = appCoreExecutionResultCopy(output);

          return of(result);
        }
      )
    );
  }

  /**
   * @inheritDoc
   * @param {AppHostPartAuthCommonJobRegisterInput} input
   * @param {AppCoreExecutionHandler} handler
   * @returns {Observable<AppHostPartAuthCommonJobRegisterResult>}
   */
  register$(
    input: AppHostPartAuthCommonJobRegisterInput,
    handler: AppCoreExecutionHandler
  ): Observable<AppHostPartAuthCommonJobRegisterResult> {
    return this.appJobRegister.execute$(input, handler);
  }

  /**
   * @inheritDoc
   * @param {string} returnUrl
   * @param {AppCoreExecutionHandler} handler
   * @returns {boolean}
   */
  tryLoginAndReturn$(
    returnUrl: string,
    handler: AppCoreExecutionHandler
  ): Observable<boolean> {
    return this.refreshAccount$(handler).pipe(
      take(1),
      () => {
        this.appAuthStore.runActionReturnUrlSet(returnUrl);

        const {
          isLoggedIn
        } = this.appAuthStore.getState();

        if (!isLoggedIn) {
          this.tryLogin(returnUrl, handler);
        }

        return of(isLoggedIn);
      }
    );
  }

  /** @param {AppCoreExecutionHandler} handler */
  private refreshAccount$(
    handler: AppCoreExecutionHandler
  ): Observable<never> {
    const {
      authType
    } = this.appSettings;

    switch (authType) {
      case AppCoreAuthEnumTypes.Jwt:
        return this.refreshAccountViaJwt(handler);
      case AppCoreAuthEnumTypes.Oidc:
        return this.refreshAccountViaOidc(handler);
      default:
        return EMPTY;
    }
  }

  /** @param {AppCoreExecutionHandler} handler */
  private refreshAccountViaJwt(
    handler: AppCoreExecutionHandler
  ): Observable<never> {
    const accessToken = this.appAuthTypeJwt.getAccessToken();

    if (accessToken) {
      if (this.appAuthTypeJwt.isTokenExpired(accessToken)) {
        const refreshToken = this.appAuthTypeJwt.getRefreshToken();

        if (refreshToken) {
          this.logout(handler);

          const input = new AppRootPartAuthJobRefreshJwtInput(refreshToken);

          return this.appJobRefresh.execute$(input, handler).pipe(
            switchMap(
              result => {
                this.loadLoginOutput(result.data, handler);
                return EMPTY;
              }
            )
          );
        }
      }

      return this.onRefreshToken(true, handler);
    }

    return EMPTY;
  }

  private onRefreshAccountViaOidcGetState(
    state: AppCoreAuthTypeOidcState,
    handler: AppCoreExecutionHandler
  ) {
    const {
      isInitialized
    } = state;

    if (isInitialized) {
      this.refreshAccountViaOidcUnsubscribe$.next(true);
      this.refreshAccountViaOidcUnsubscribe$.complete();

      this.refreshTokenViaOidc(handler);
    }
  }

  /**
   * @param {boolean} isTokenValid
   * @param {AppCoreExecutionHandler} handler
   * @returns {Observable<NEVER>}
   */
  private onRefreshToken(
    isTokenValid: boolean,
    handler: AppCoreExecutionHandler
  ): Observable<never> {
    if (isTokenValid) {
      const {
        isLoggedIn
      } = this.appAuthStore.getState();

      if (!isLoggedIn) {
        return this.loadCurrentUser$(handler).pipe(
          switchMap(() => EMPTY)
        );
      }
    }

    return EMPTY;
  }

  /** @param {AppCoreExecutionHandler} handler */
  private refreshAccountViaOidc(
    handler: AppCoreExecutionHandler
  ): Observable<never> {
    const {
      isInitialized
    } = this.appAuthTypeOidcStore.getState();

    if (isInitialized) {
      this.refreshTokenViaOidc(handler);
    } else {
      this.appAuthTypeOidcStore.getState$(
        this.refreshAccountViaOidcUnsubscribe$
      ).subscribe(
        state => this.onRefreshAccountViaOidcGetState(state, handler)
      );
    }

    return EMPTY;
  }

  /** @param {AppCoreExecutionHandler} handler */
  private refreshTokenViaOidc(
    handler: AppCoreExecutionHandler
  ) {
    this.appAuthTypeOidcJobRefreshToken.execute$(handler).pipe(
      switchMap(result => of(result.isOk))
    ).subscribe(
      isTokenValid => this.onRefreshToken(isTokenValid, handler)
    );
  }}
