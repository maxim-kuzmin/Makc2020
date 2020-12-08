// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModAuthPageLogonSettings} from './mod-auth-page-logon-settings';

/** Мод "Auth". Страницы. Вход в систему. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModAuthPageLogonService {

  /**
   * Настройки.
   * @type {AppModAuthPageLogonSettings}
   */
  settings = new AppModAuthPageLogonSettings();

  /**
   * URL.
   * @type {string}.
   */
  get url(): string {
    return this.settings.path;
  }
}
