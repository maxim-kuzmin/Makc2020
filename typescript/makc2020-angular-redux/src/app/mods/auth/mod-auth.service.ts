// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModAuthSettings} from './mod-auth-settings';

/** Мод "Auth". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModAuthService {

  /**
   * Настройки.
   * @type {AppModAuthSettings}
   */
  settings = new AppModAuthSettings();
}
