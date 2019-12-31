// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModAuthPageIndexSettings} from './mod-auth-page-index-settings';

/** Мод "Auth". Страницы. Начало. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModAuthPageIndexService {

  /**
   * Настройки.
   * @type {AppModAuthPageIndexSettings}
   */
  settings = new AppModAuthPageIndexSettings();
}
