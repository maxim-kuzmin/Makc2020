// //Author Maxim Kuzmin//makc//

import {OAuthModuleConfig} from 'angular-oauth2-oidc';
import {environment} from '../../environments/environment';

/**
 * Ядро. Конфигурация. API. URL.
 * @type {string}
 */
export const appCoreConfigApiUrl = `${environment.apiServerUrl}/api/`;

/**
 * Ядро. Конфигурация. Аутентификация. Тип "OIDC". Модуль.
 * @type {OAuthModuleConfig}
 */
export const appCoreConfigAuthTypeOidcModule: OAuthModuleConfig = environment.authTypeOidcIsEnabled
  ? {
    resourceServer: {
      allowedUrls: [appCoreConfigApiUrl],
      sendAccessToken: true
    }
  }
  : null;

/**
 * Опции размера страницы.
 * @type {number[]}
 */
export const appCoreConfigPageSizeOptions = [10, 25, 50, 100, 250];
