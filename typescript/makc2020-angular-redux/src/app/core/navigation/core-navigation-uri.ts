// //Author Maxim Kuzmin//makc//

import {HttpParams} from '@angular/common/http';

/** Ядро. Навигация. URI. */
export class AppCoreNavigationUri {

  private queryParams = new HttpParams();
  private readonly prefix: string;
  private readonly suffix: string;

  /**
   * Конструктор.
   * @param {?string} url URL.
   */
  constructor(url?: string) {
    if (url) {
      const suffixParts = url.split('#');

      if (suffixParts.length > 0) {
        this.suffix = suffixParts[1];
      }

      const prefix = suffixParts[0];

      if (prefix) {
        const prefixParts = prefix.split('?');

        this.prefix = prefixParts[0];

        const qs = prefixParts.length > 0 ? prefixParts[1] : '';

        if (qs) {
          const qsParts = qs.split('&');

          for (const qsPart of qsParts) {
            const qsPartItems = qsPart.split('=');

            const qsParamName = decodeURIComponent(qsPartItems[0]);
            const qsParamValue = qsPartItems.length > 0 ? decodeURIComponent(qsPartItems[1]) : '';

            this.queryParams = this.queryParams.append(qsParamName, qsParamValue);
          }
        }
      }
    }
  }

  /**
   * Присоединить параметр запроса.
   * @param {string} name Имя.
   * @param {string} value Значение.
   * @returns {AppCoreNavigationUri} URI.
   */
  appendQueryParam(name: string, value: string): AppCoreNavigationUri {
    this.queryParams = this.queryParams.append(name, value);

    return this;
  }

  /**
   * Установить параметр запроса.
   * @param {string} name Имя.
   * @param {string} value Значение.
   * @returns {AppCoreNavigationUri} URI.
   */
  setQueryParam(name: string, value: string): AppCoreNavigationUri {
    this.queryParams = this.queryParams.set(name, value);

    return this;
  }

  /**
   * Преобразовать к строке.
   * @returns {string} Строка.
   */
  toString(): string {
    let result = '';

    if (this.prefix) {
      result = this.prefix;
    }

    if (this.queryParams.keys().length > 0) {
      result += '?' + this.queryParams.toString();
    }

    if (this.suffix) {
      result += '#' + this.suffix;
    }

    return result;
  }
}
