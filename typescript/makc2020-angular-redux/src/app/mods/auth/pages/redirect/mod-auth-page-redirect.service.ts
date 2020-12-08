// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModAuthPageRedirectSettings} from './mod-auth-page-redirect-settings';

/** Мод "Auth". Страницы. Перенаправление. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModAuthPageRedirectService {

  /**
   * Настройки.
   * @type {AppModAuthPageRedirectSettings}
   */
  settings = new AppModAuthPageRedirectSettings();
}
