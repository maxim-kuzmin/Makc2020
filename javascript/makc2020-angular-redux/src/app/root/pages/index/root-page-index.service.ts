// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppRootPageIndexSettings} from './root-page-index-settings';

/** Корень. Страницы. Начало. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageIndexService {

  /**
   * Настройки.
   * @type {AppRootPageIndexSettings}
   */
  settings = new AppRootPageIndexSettings();
}
