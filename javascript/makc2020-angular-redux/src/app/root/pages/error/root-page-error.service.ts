// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppRootPageErrorSettings} from './root-page-error-settings';

/** Корень. Страницы. Ошибка. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageErrorService {

  /**
   * Настройки.
   * @type {AppRootPageErrorSettings}
   */
  settings = new AppRootPageErrorSettings();
}
