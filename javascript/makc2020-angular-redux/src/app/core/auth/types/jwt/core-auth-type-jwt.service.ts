// //Author Maxim Kuzmin//makc//

// tslint:disable:no-bitwise

import {Injectable} from '@angular/core';
import {appCoreConfigAuthType} from '@app/core/core-config';
import {AppCoreAuthEnumTypes} from '../../enums/core-auth-enum-types';
import {AppCoreAuthTypeJwtDefault} from './core-auth-type-jwt-default';

/** Ядро. Аутентификация. Типы. JWT. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreAuthTypeJwtService {

  /** @type {number} */
  private readonly expirationOffsetSeconds: number;

  /**
   * Признак включенности.
   * @type {boolean}
   */
  get isEnabled(): boolean {
    return appCoreConfigAuthType === AppCoreAuthEnumTypes.Jwt;
  }

  /**
   * Конструктор.
   * @param {AppCoreAuthTypeJwtDefault} appAuthJwtTypeDefault Умолчание аутентификации типа JWT.
   */
  constructor(
    private appAuthJwtTypeDefault: AppCoreAuthTypeJwtDefault
  ) {
    this.expirationOffsetSeconds = this.appAuthJwtTypeDefault.expirationOffsetSeconds;

    if (this.expirationOffsetSeconds > 0) {
      this.expirationOffsetSeconds = -this.expirationOffsetSeconds;
    }
  }

  /**
   * Получить токен доступа.
   * @returns {string} Токен доступа.
   */
  getAccessToken(): string {
    return this.appAuthJwtTypeDefault.getToken(this.appAuthJwtTypeDefault.keyOfAccessToken);
  }

  /**
   * Установить токен доступа.
   * @param {string} value Значение.
   */
  setAccessToken(value: string) {
    this.appAuthJwtTypeDefault.setToken(this.appAuthJwtTypeDefault.keyOfAccessToken, value);
  }

  /**
   * Получить токен обновления.
   * @returns {string} Токен обновления.
   */
  getRefreshToken(): string {
    return this.appAuthJwtTypeDefault.getToken(this.appAuthJwtTypeDefault.keyOfRefreshToken);
  }

  /**
   * Установить токен обновления.
   * @param {string} value Значение.
   */
  setRefreshToken(value: string) {
    this.appAuthJwtTypeDefault.setToken(this.appAuthJwtTypeDefault.keyOfRefreshToken, value);
  }

  /** Удалить токен доступа. */
  removeAccessToken() {
    this.appAuthJwtTypeDefault.removeToken(this.appAuthJwtTypeDefault.keyOfAccessToken);
  }

  /** Удалить токен обновления. */
  removeRefreshToken() {
    this.appAuthJwtTypeDefault.removeToken(this.appAuthJwtTypeDefault.keyOfRefreshToken);
  }

  /**
   * Декодировать строку, закодированную по стандарту Base64.
   * @param {string} str Закодированная строка.
   * @returns {string} Декодированная строка.
   */
  urlBase64Decode(str: string): string {
    let output = str.replace(/-/g, '+').replace(/_/g, '/');
    switch (output.length % 4) {
      case 0: {
        break;
      }
      case 2: {
        output += '==';
        break;
      }
      case 3: {
        output += '=';
        break;
      }
      default: {
        throw new Error('Illegal base64url string!');
      }
    }
    return this.base64DecodeUnicode(output);
  }

  /**
   * Декодировать токен.
   * @param {string} token Закодированный токен.
   * @returns {any} Декодированный токен.
   */
  decodeToken(token: string): any {
    if (token === null) {
      return null;
    }

    const parts = token.split('.');

    if (parts.length !== 3) {
      throw new Error('The inspected token doesn appear to be a JWT.');
    }

    const decoded = this.urlBase64Decode(parts[1]);

    if (!decoded) {
      throw new Error('Cannot decode the token.');
    }

    return JSON.parse(decoded);
  }

  /**
   * Получить дату истечения времени действия токена.
   * @param {string} token Токен.
   * @returns {Date | null} Дата истечения времени действия токена.
   */
  getTokenExpirationDate(token: string): Date | null {
    const decoded = this.decodeToken(token);

    if (!decoded.hasOwnProperty('exp')) {
      return null;
    }

    const date = new Date(0);

    date.setUTCSeconds(decoded.exp);

    return date;
  }

  /**
   * Проверить, истекло ли время действия токена.
   * @param {string} token Токен.
   * @returns {boolean} Результат проверки.
   */
  isTokenExpired(token: string): boolean {
    if (!token) {
      return true;
    }

    const date = this.getTokenExpirationDate(token);

    if (!date) {
      return true;
    }

    return !(date.valueOf() > new Date().valueOf() + this.expirationOffsetSeconds * 1000);
  }

  /**
   * credits for decoder goes to https://github.com/atk
   * @param {string} str
   * @returns {string}
   */
  private base64Decode(str: string): string {
    const chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';
    let output = '';

    str = String(str).replace(/=+$/, '');

    if (str.length % 4 === 1) {
      throw new Error('atob failed: The string to be decoded is not correctly encoded.');
    }

    for (
      // initialize result and counters
      let bc = 0, bs: any, buffer: any, idx = 0;
      // get next character
      (buffer = str.charAt(idx++));
      // character found in table? initialize bit storage and add its ascii value;
      ~buffer &&
      (
        (bs = bc % 4 ? bs * 64 + buffer : buffer),
          // and if not first of each 4 characters,
          // convert the first 8 bits to one ascii character
        bc++ % 4
      )
        ? (output += String.fromCharCode(255 & (bs >> ((-2 * bc) & 6))))
        : 0
    ) {
      // try to find character in table (0-63, not found => -1)
      buffer = chars.indexOf(buffer);
    }
    return output;
  }

  /**
   * @param {string} str
   * @returns {string}
   */
  private base64DecodeUnicode(str: string) {
    return decodeURIComponent(
      Array.prototype.map
        .call(this.base64Decode(str), (c: any) => {
          return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join('')
    );
  }
}
