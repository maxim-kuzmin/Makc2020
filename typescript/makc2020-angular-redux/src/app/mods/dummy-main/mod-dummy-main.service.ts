// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModDummyMainSettings} from './mod-dummy-main-settings';

/** Мод "DummyMain". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainService {

  /**
   * Настройки.
   * @type {AppModDummyMainSettings}
   */
  settings = new AppModDummyMainSettings();
}
