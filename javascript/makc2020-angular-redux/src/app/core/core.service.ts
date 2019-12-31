// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppCoreSettings} from './core-settings';

/** Ядро. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppCoreService {

  /**
   * Настройки.
   * @type {AppCoreSettings}
   */
  settings = new AppCoreSettings();
}
