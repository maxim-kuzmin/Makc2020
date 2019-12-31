// //Author Maxim Kuzmin//makc//

import {OAuthModuleConfig} from 'angular-oauth2-oidc';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';

const appCoreConfigAuthIsOidcTypeEnabled = false;

/**
 * Ядро. Конфигурация. API. URL.
 * @type {string}
 */
export const appCoreConfigApiUrl = `http://localhost:5002/api/`;

/**
 * Ядро. Конфигурация. Аутентификация. OIDC. Модуль.
 * @type {OAuthModuleConfig}
 */
export const appCoreConfigAuthOidcModule: OAuthModuleConfig = appCoreConfigAuthIsOidcTypeEnabled
  ? {
    resourceServer: {
      allowedUrls: [appCoreConfigApiUrl],
      sendAccessToken: true
    }
  }
  : null;

/**
 * Ядро. Конфигурация. Аутентификация. Тип.
 * @type {AppCoreAuthEnumTypes}
 */
export const appCoreConfigAuthType: AppCoreAuthEnumTypes = appCoreConfigAuthIsOidcTypeEnabled
  ? AppCoreAuthEnumTypes.Oidc
  : AppCoreAuthEnumTypes.Jwt;

/**
 * Ядро. Конфигурация. Аутентификация. OIDC. Сервер. URL.
 * @type {string}
 */
export const appCoreConfigAuthOidcServerUrl = `http://localhost:6002`;

/**
 * Ядро. Конфигурация. Хост. Порт.
 * @type {number}
 */
export const appCoreConfigHostPort = 4203;

/**
 * Ядро. Конфигурация. Хост. URL без базового пути.
 * @type {string}
 */
export const appCoreConfigHostUrlWithoutBasePath = `http://localhost:${appCoreConfigHostPort}`;
