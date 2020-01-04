// //Author Maxim Kuzmin//makc//

import {Router} from '@angular/router';
import {Observable, of, Subject} from 'rxjs';
import {switchMap} from 'rxjs/operators';
import {AppCoreAuthService} from '@app/core/auth/core-auth.service';
import {AppCoreAuthTypeJwtService} from '@app/core/auth/types/jwt/core-auth-type-jwt.service';
import {AppCoreAuthTypeOidcJobLoginService} from '@app/core/auth/types/oidc/jobs/login/core-auth-type-oidc-job-login.service';
import {AppCoreAuthTypeOidcJobLogoutService} from '@app/core/auth/types/oidc/jobs/logout/core-auth-type-oidc-job-logout.service';
import {AppCoreAuthTypeOidcState} from '@app/core/auth/types/oidc/core-auth-type-oidc-state';
import {AppCoreAuthTypeOidcStore} from '@app/core/auth/types/oidc/core-auth-type-oidc-store';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';
import {AppCoreExecutionResult} from '@app/core/execution/core-execution-result';
import {AppCoreLoggingService} from '@app/core/logging/core-logging.service';
import {AppHostPartAuthCommonJobLoginInput} from './common/jobs/login/host-part-auth-common-job-login-input';
import {AppHostPartAuthCommonJobLoginJwtOutput} from './common/jobs/login/jwt/host-part-auth-common-job-login-jwt-output';
import {AppHostAuthCommonJobRegisterInput} from './common/jobs/register/host-auth-common-job-register-input';
import {AppHostAuthCommonJobRegisterResult} from './common/jobs/register/host-auth-common-job-register-result';
import {AppHostPartAuthStore} from './host-part-auth-store';

/** Хост. Часть "Auth". Сервис. */
export abstract class AppHostPartAuthService extends AppCoreAuthService {

  private removeCurrentUserAndTokensViaOidcUnsubscribe$ = new Subject<boolean>();

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtService} appAuthTypeJwt Аутентификация типа JWT.
   * @param {AppCoreAuthTypeOidcJobLoginService} appAuthTypeOidcJobLogin Задание на вход в систему для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcJobLogoutService} appAuthTypeOidcJobLogout Задание на выход из системы для аутентификации типа OIDC.
   * @param {AppCoreAuthTypeOidcStore} appAuthTypeOidcStore Хранилище состояния аутентификации
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {Router} extRouter Маршрутизатор.
   */
  protected constructor(
    protected appAuthTypeJwt: AppCoreAuthTypeJwtService,
    private appAuthTypeOidcJobLogin: AppCoreAuthTypeOidcJobLoginService,
    private appAuthTypeOidcJobLogout: AppCoreAuthTypeOidcJobLogoutService,
    protected appAuthTypeOidcStore: AppCoreAuthTypeOidcStore,
    protected appAuthStore: AppHostPartAuthStore,
    private extRouter: Router
  ) {
    super();

    this.onRemoveCurrentUserAndTokensViaOidcGetState = this.onRemoveCurrentUserAndTokensViaOidcGetState.bind(this);
  }

  /**
   * Загрузить текущего пользователя.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @returns {Observable<AppCoreExecutionResult>}
   * Поток с результатом выполнения.
   */
  abstract loadCurrentUser$(
    logger: AppCoreLoggingService,
  ): Observable<AppCoreExecutionResult>;

  /**
   * Войти в систему.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostPartAuthCommonJobLoginInput} input Ввод.
   * @returns {Observable<AppCoreExecutionResult>}
   * Поток с результатом выполнения.
   */
  abstract login$(
    logger: AppCoreLoggingService,
    input: AppHostPartAuthCommonJobLoginInput
  ): Observable<AppCoreExecutionResult>;

  /**
   * Выйти из системы.
   * @param {AppCoreLoggingService} logger Регистратор.
   */
  logout(
    logger: AppCoreLoggingService
  ) {
    const {
      isLoggedIn
    } = this.appAuthStore.getState();

    if (isLoggedIn) {
      this.removeCurrentUserAndTokens(logger);
    }
  }

  /**
   * Зарегистрировать.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostAuthCommonJobRegisterInput} input Ввод.
   * @returns {Observable<AppHostAuthCommonJobRegisterResult>} Результирующий поток.
   */
  abstract register$(
    logger: AppCoreLoggingService,
    input: AppHostAuthCommonJobRegisterInput
  ): Observable<AppHostAuthCommonJobRegisterResult>;

  /**
   * Попробовать войти в систему и вернуться.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param url URL страницы, на которую нужно вернуться после удачной попытки входа.
   * @returns {boolean} Признак успешного входа.
   */
  abstract tryLoginAndReturn$(
    logger: AppCoreLoggingService,
    url: string
  ): Observable<boolean>;

  /**
   * Загрузить вывод от задания на вход в систему.
   * @param {AppCoreLoggingService} logger Регистратор.
   * @param {AppHostPartAuthCommonJobLoginJwtOutput} output Данные.
   */
  protected loadLoginOutput(
    logger: AppCoreLoggingService,
    output: AppHostPartAuthCommonJobLoginJwtOutput
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
      this.removeCurrentUserAndTokens(logger);
    }
  }

  /**
   * Попробовать войти в систему.
   * @param {AppCoreLoggingService} logger Регистратор.
   */
  protected tryLogin(
    logger: AppCoreLoggingService
  ) {
    switch (this.authType) {
      case AppCoreAuthEnumTypes.Jwt: {
        const {
          logonUrl
        } = this.appAuthStore.getState();

        if (logonUrl) {
          this.extRouter.navigate([logonUrl]).catch();
        }
      }
        break;
      case AppCoreAuthEnumTypes.Oidc:
        this.appAuthTypeOidcJobLogin.execute(logger);
        break;
    }
  }

  /** @param {AppCoreLoggingService} logger Регистратор. */
  private removeCurrentUserAndTokens(
    logger: AppCoreLoggingService
  ) {
    this.appAuthStore.runActionCurrentUserSet();

    switch (this.authType) {
      case AppCoreAuthEnumTypes.Jwt:
        this.removeCurrentUserAndTokensViaJwt();
        break;
      case AppCoreAuthEnumTypes.Oidc:
        this.removeCurrentUserAndTokensViaOidc(logger);
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

  /** @param {AppCoreLoggingService} logger Регистратор. */
  private removeCurrentUserAndTokensViaOidc(logger: AppCoreLoggingService) {
    this.appAuthTypeOidcStore.getState$(
      this.removeCurrentUserAndTokensViaOidcUnsubscribe$
    ).pipe(
      switchMap(state => of({
        logger,
        state
      }))
    ).subscribe(
      this.onRemoveCurrentUserAndTokensViaOidcGetState
    );
  }

  /** @param {
      logger: AppCoreLoggingService,
      state: AppCoreAuthTypeOidcState
    } input */
  private onRemoveCurrentUserAndTokensViaOidcGetState(
    input: {
      logger: AppCoreLoggingService,
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
        logger
      } = input;

      this.appAuthTypeOidcJobLogout.execute(logger);
    }
  }
}
