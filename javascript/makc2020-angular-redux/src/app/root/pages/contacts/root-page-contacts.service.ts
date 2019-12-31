// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppRootPageContactsSettings} from './root-page-contacts-settings';

/** Корень. Страницы. Контакты. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppRootPageContactsService {

  /**
   * Настройки.
   * @type {AppRootPageContactsSettings}
   */
  settings = new AppRootPageContactsSettings();
}
