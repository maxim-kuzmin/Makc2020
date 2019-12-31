// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppRootPageAdministrationSettings} from './root-page-administration-settings';

/** Корень. Страницы. Администрирование. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageAdministrationService {

  /**
   * Настройки.
   * @type {AppRootPageAdministrationSettings}
   */
  settings = new AppRootPageAdministrationSettings();
}
