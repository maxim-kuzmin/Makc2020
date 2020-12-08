// //Author Maxim Kuzmin//makc//

/** Ядро. Аутентификация. Типы. JWT. Умолчание. */
export class AppCoreAuthTypeJwtDefault {

  /**
   * Схема аутентификации.
   * @type {string}
   */
  get authScheme(): string {
    return 'Bearer';
  }

  /**
   * Получить чёрный список маршрутов.
   * @returns {string[] | RegExp[]} Чёрный список маршрутов.
   */
  get blacklistedRoutes(): null | Array<string | RegExp> {
    return [];
  }
  /**
   * Смещение в секундах при определении истечения времени действия токена.
   * @type {number}
   */
  get expirationOffsetSeconds(): number {
    return -2;
  }

  /**
   * Имя заголовка.
   * @type {string}
   */
  get headerName(): string {
    return 'Authorization';
  }

  /**
   * Ключ токена доступа.
   * @type {string}
   */
  get keyOfAccessToken(): string {
    return 'access_token';
  }

  /**
   * Ключ токена обновления.
   * @type {string}
   */
  get keyOfRefreshToken(): string {
    return 'refresh_token';
  }

  /**
   * Получить белый список доменов.
   * @returns {string[] | RegExp[]} Белый список доменов.
   */
  get whitelistedDomains(): null | Array<string | RegExp> {
    return [];
  }

  /**
   * Получить токен.
   * @param {string} key Ключ токена.
   * @returns {?string} Токен.
   */
  getToken(key: string): null | string {
    return null;
  }

  /**
   * Установить токен.
   * @param {string} key Ключ токена.
   * @param {string} value Значение токена.
   */
  setToken(key: string, value: string) {  }

  /**
   * Удалить токен.
   * @param {string} key Ключ токена.
   */
  removeToken(key: string) {  }
}
