// //Author Maxim Kuzmin//makc//

import {HttpClient, HttpParams} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';

/** Ядро. HTTP. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreHttpService {

  /**
   * Конструктор.
   * @param {HttpClient} http HTTP.
   */
  constructor(
    private http: HttpClient
  ) {
  }

  /**
   * Выполнить запрос методом "DELETE".
   * @param {string} url URL.
   * @param {?any} data Данные.
   * @returns {Observable<T>} Поток отклика.
   */
  delete<T>(url: string, data?): Observable<T> {
    const params = this.createParams(data);

    return params
      ? this.http.delete<T>(url, {params})
      : this.http.delete<T>(url);
  }

  /**
   * Выполнить запрос методом "GET" для получения JSON.
   * @param {string} url URL.
   * @param {?any} data Данные.
   * @returns {Observable<T>} Поток отклика.
   */
  get<T>(url: string, data?): Observable<T> {
    const params = this.createParams(data);

    return params
      ? this.http.get<T>(url, {params})
      : this.http.get<T>(url);
  }

  /**
   * Выполнить запрос методом "GET" для получения текста.
   * @param {string} url URL.
   * @param {?any} data Данные.
   * @returns {Observable<string>} Поток отклика.
   */
  getText(url: string, data?): Observable<string> {
    const params = this.createParams(data);

    return this.http.get(url, {
      params,
      responseType: 'text'
    });
  }

  /**
   * Выполнить запрос методом "GET".
   * @param {string} url URL.
   * @param {any} data Данные.
   * @returns {Observable<T>} Поток отклика.
   */
  post<T>(url: string, data): Observable<T> {
    return this.http.post<T>(url, data);
  }

  /**
   * Выполнить запрос методом "PUT".
   * @param {string} url URL.
   * @param {any} data Данные.
   * @returns {Observable<T>} Поток отклика.
   */
  put<T>(url: string, data): Observable<T> {
    return this.http.put<T>(url, data);
  }

  /**
   * Создать опции.
   * @param {<any>} data Данные.
   * @returns {any} Опции.
   */
  private createParams(data: any) {
    let result: HttpParams = null;

    if (typeof data !== 'undefined' && data != null) {
      result = new HttpParams();

      Object.keys(data).forEach(key => {
        const val = data[key];
        if (typeof val !== 'undefined' && val != null) {
          result = result.set(key, data[key].toString());
        }
      });
    }

    return result;
  }
}
