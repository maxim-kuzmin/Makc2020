// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModDummyMainPageIndexSettings} from './mod-dummy-main-page-index-settings';

/** Мод "DummyMain". Страницы. Начало. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyMainPageIndexService {

  /**
   * Настройки.
   * @type {AppModDummyMainPageIndexSettings}
   */
  settings = new AppModDummyMainPageIndexSettings();
}
