// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreNavigationDefault} from './core-navigation-default';
import {Router} from '@angular/router';

/** Ядро. Навигация. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreNavigationService {

  /**
   * Конструктор.
   * @param {AppCoreNavigationDefault} appNavigationDefault Умолчание навигации.
   * @param {Router} extRouter Маршрутизатор.
   */
  constructor(
    private appNavigationDefault: AppCoreNavigationDefault,
    private extRouter: Router
  ) {
  }

  /**
   * Создать абсолютный URL хоста.
   * @param {string} suffix Суффикс.
   * @returns {string} Абсолютный URL.
   */
  createAbsoluteUrlOfHost(suffix: string): string {
    if (suffix && suffix.startsWith('/')) {
      suffix = suffix.substring(1);
    }
    return `${this.appNavigationDefault.hostUrl}${suffix}`;
  }

  /**
   * Создать абсолютный URL API.
   * @param {string} suffix Суффикс.
   * @returns {string} Абсолютный URL.
   */
  createAbsoluteUrlOfApi(suffix: string): string {
    return `${this.appNavigationDefault.apiUrl}${suffix}`;
  }


  /**
   * Создать URL маршрутизатора.
   * @param {any[]} commands Команды.
   * @returns {string} URL.
   */
  createRouterUrl(commands: any[]): string {
    return this.extRouter.serializeUrl(this.extRouter.createUrlTree(commands));
  }
}
