// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AuthConfig, JwksValidationHandler, OAuthService} from 'angular-oauth2-oidc';
import {filter, map} from 'rxjs/operators';
import {AppCoreSettings} from '@app/core/core-settings';
import {AppHostPartAuthStore} from '@app/host/parts/auth/host-part-auth-store';
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
    return this.appSettings.authType === AppCoreAuthEnumTypes.Oidc;
  }

  /**
   * Конструктор.
   * @param {AppHostPartAuthStore} appAuthStore Хранилище состояния аутентификации.
   * @param {AppCoreSettings} appSettings Настройки.
   * @param {OAuthService} extOauthService Авторизация OAuth 2.0.
   */
  constructor(
    private appAuthStore: AppHostPartAuthStore,
    private appSettings: AppCoreSettings,
    private extOauthService: OAuthService
  ) {
    this.onGetReturnUrl = this.onGetReturnUrl.bind(this);
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

  /**
   * Войти в систему.
   * @param {string} returnUrl URL возврата.
   */
  login(returnUrl: string) {
    this.extOauthService.initLoginFlow(returnUrl);
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
    this.extOauthService.oidc = true;

    return this.extOauthService.responseType === 'code'
      ? this.extOauthService.refreshToken()
      : this.extOauthService.silentRefresh();
  }

  /**
   * Запустить.
   * @param {string} redirectUrl URL перенаправления.
   * @returns {Promise<object>}
   */
  start(redirectUrl: string): Promise<boolean> {
    const authConfig = {

      // Url of the Identity Provider
      issuer: this.appSettings.authTypeOidcServerUrl,

      // URL of the SPA to redirect the user to after login
      redirectUri: redirectUrl || window.location.origin,

      // The SPA's id. The SPA is registered with this id at the auth-server
      // clientId: 'server.code',
      clientId: 'Makc2020WebClient',

      // Just needed if your auth server demands a secret. In general, this
      // is a sign that the auth server is not configured with SPAs in mind
      // and it might not enforce further best practices vital for security
      // such applications.
      // dummyClientSecret: 'secret',

      responseType: 'id_token token',

      // URL of the SPA to redirect the user after silent refresh
      silentRefreshRedirectUri: window.location.origin + '/silent-refresh.html',

      // set the scope for the permissions the client should request
      // The first four are defined by OIDC.
      // Important: Request offline_access to get a refresh token
      // The api scope is a use case specific one
      scope: 'offline_access openid Makc2020WebApi',

      showDebugInformation: true,

      // Not recommended:
      // disablePKCI: true,
    } as AuthConfig;

    if (authConfig.issuer.toLowerCase().indexOf('http://') === 0) {
      authConfig.requireHttps = false;
    }

    this.extOauthService.configure(authConfig);

    this.extOauthService.tokenValidationHandler = new JwksValidationHandler();

    this.extOauthService.events.pipe(
      filter(e => e.type === 'token_received'),
      map(_ => this.extOauthService.state)
    ).subscribe(
      this.onGetReturnUrl
    );

    return this.extOauthService.loadDiscoveryDocumentAndTryLogin();
  }

  private onGetReturnUrl(returnUrl: string) {
    this.appAuthStore.runActionReturnUrlSet(returnUrl);
  }
}
