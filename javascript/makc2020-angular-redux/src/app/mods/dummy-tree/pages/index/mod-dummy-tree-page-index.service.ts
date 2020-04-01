// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModDummyTreePageIndexSettings} from './mod-dummy-tree-page-index-settings';

/** Мод "DummyTree". Страницы. Начало. Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreePageIndexService {

  /**
   * Настройки.
   * @type {AppModDummyTreePageIndexSettings}
   */
  settings = new AppModDummyTreePageIndexSettings();
}
