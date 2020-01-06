// //Author Maxim Kuzmin//makc//

import {environment} from '../../environments/environment';
import {appCoreConfigApiUrl, appCoreConfigPageSizeOptions} from './core-config';
import {AppCoreAuthEnumTypes} from '@app/core/auth/enums/core-auth-enum-types';

/** Ядро. Настройки. */
export class AppCoreSettings {

  /**
   * API. URL.
   * @type {string}
   */
  get apiUrl() {
    return appCoreConfigApiUrl;
  }

  /**
   * Аутентификация. Тип.
   * @type {AppCoreAuthEnumTypes}
   */
  get authType(): AppCoreAuthEnumTypes {
    return environment.authTypeOidcIsEnabled
      ? AppCoreAuthEnumTypes.Oidc
      : AppCoreAuthEnumTypes.Jwt;
  }

  /**
   * Аутентификация. Тип "OIDC". Сервер. URL.
   * @type {string}
   */
  get authTypeOidcServerUrl() {
    return environment.identityServerUrl;
  }

  /**
   * Хост. Порт.
   * @type {string}
   */
  get hostPort() {
    return environment.hostPort;
  }

  /**
   * Хост. URL.
   * @type {string}
   */
  get hostUrl() {
    return environment.hostUrl;
  }

  /**
   * Размер страницы.
   * @type {string}
   */
  get pageSize() {
    return 10;
  }

  /**
   * Опции размера страницы.
   * @type {number[]}
   */
  get pageSizeOptions() {
    return appCoreConfigPageSizeOptions;
  }

  /**
   * Направление сортировки.
   * @type {string}
   */
  get sortDirection() {
    return 'desc';
  }

  /**
   * Задержка поиска в миллисекундах.
   * @type {number}
   */
  get searchDelayMilliseconds() {
    return 150;
  }
}

/** Ядро. Настройки. Экземпляр. */
export const appCoreSettings = new AppCoreSettings();
