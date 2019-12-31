// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AuthConfig, JwksValidationHandler, OAuthService} from 'angular-oauth2-oidc';
import {appCoreConfigAuthOidcServerUrl, appCoreConfigAuthType} from '@app/core/core-config';
import {AppCoreAuthEnumTypes} from '../../enums/core-auth-enum-types';

/** Ядро. Аутентификация. Типы. OIDC. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeOidcService {

  /**
   * Признак включённости.
   * @type {boolean}
   */
  get isEnabled(): boolean {
    return appCoreConfigAuthType === AppCoreAuthEnumTypes.Oidc;
  }

  /**
   * Конструктор.
   * @param {OAuthService} extOauthService Авторизация OAuth 2.0.
   */
  constructor(
    private extOauthService: OAuthService
  ) {
  }

  /**
   * Узнать, является ли токен доступа валидным.
   * @returns {boolean} Признак валидности токена доступа.
   */
  hasValidAccessToken(): boolean {
    return this.extOauthService.hasValidAccessToken();
  }

  /**
   * Загрузить профиль пользователя.
   * @returns {Promise<object>}
   */
  loadUserProfile(): Promise<object> {
    return this.extOauthService.loadUserProfile();
  }

  /** Войти в систему. */
  login() {
    this.extOauthService.initLoginFlow();
  }

  /** Выйти из системы. */
  logout() {
    this.extOauthService.logOut();
  }

  /**
   * Освежить токен.
   * @returns {Promise<object>}
   */
  refreshToken(): Promise<object> {
      return this.extOauthService.refreshToken();
  }

  /**
   * Запустить.
   * @param {string} redirectUrl URL перенаправления.
   * @returns {Promise<object>}
   */
  start(redirectUrl: string): Promise<boolean> {
    const authConfig = {

      // Url of the Identity Provider
      issuer: appCoreConfigAuthOidcServerUrl,

      // URL of the SPA to redirect the user to after login
      redirectUri: redirectUrl || window.location.origin,

      // The SPA's id. The SPA is registered with this id at the auth-server
      // clientId: 'server.code',
      clientId: 'SrtdbWebClient',

      // Just needed if your auth server demands a secret. In general, this
      // is a sign that the auth server is not configured with SPAs in mind
      // and it might not enforce further best practices vital for security
      // such applications.
      // dummyClientSecret: 'secret',

      responseType: 'code',

      // set the scope for the permissions the client should request
      // The first four are defined by OIDC.
      // Important: Request offline_access to get a refresh token
      // The api scope is a use case specific one
      scope: 'offline_access openid SrtdbWebApi',

      showDebugInformation: true,

      // Not recommended:
      // disablePKCI: true,
    } as AuthConfig;

    this.extOauthService.configure(authConfig);

    this.extOauthService.tokenValidationHandler = new JwksValidationHandler();

    return this.extOauthService.loadDiscoveryDocumentAndTryLogin();
  }
}
