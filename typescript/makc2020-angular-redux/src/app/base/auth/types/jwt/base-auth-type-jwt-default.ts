// //Author Maxim Kuzmin//makc//

import {AppCoreAuthTypeJwtDefault} from '@app/core/auth/types/jwt/core-auth-type-jwt-default';
import {Inject} from '@angular/core';
import {appBaseDiTokenSessionStorage} from '../../../base-di';

/** Основа. Аутентификация. Типы. JWT. Умолчание. */
export class AppBaseAuthTypeJwtDefault extends AppCoreAuthTypeJwtDefault {

  /**
   * Конструктор.
   * @param {Storage} sessionStorage Сессионное хранилище.
   */
  constructor(
    @Inject(appBaseDiTokenSessionStorage) private sessionStorage: Storage
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @param { string } key Ключ токена.
   * @returns {?string } Токен.
   */
  getToken(key: string): string {
    return this.sessionStorage.getItem(key);
  }

  /**
   * @inheritDoc
   * @param {string} key Ключ токена.
   * @param {string} value Значение токена.
   */
  setToken(key: string, value: string) {
    this.sessionStorage.setItem(key, value);
  }

  /**
   * @inheritDoc
   * @param {string} key Ключ токена.
   */
  removeToken(key: string) {
    this.sessionStorage.removeItem(key);
  }
}
