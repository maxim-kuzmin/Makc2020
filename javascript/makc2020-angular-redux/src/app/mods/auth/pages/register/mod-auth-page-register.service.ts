// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModAuthPageRegisterSettings} from './mod-auth-page-register-settings';

/** Мод "Auth". Страницы. Регистрация. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModAuthPageRegisterService {

  /**
   * Настройки.
   * @type {AppModAuthPageRegisterSettings}
   */
  settings = new AppModAuthPageRegisterSettings();

  /**
   * URL.
   * @type {string}.
   */
  get url(): string {
    return this.settings.path;
  }
}
