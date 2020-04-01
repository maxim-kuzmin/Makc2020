// //Author Maxim Kuzmin//makc//

import {Injectable} from '@angular/core';
import {AppModDummyTreeSettings} from './mod-dummy-tree-settings';

/** Мод "DummyTree". Сервис. */
@Injectable({
  providedIn: 'root'
})
export class AppModDummyTreeService {

  /**
   * Настройки.
   * @type {AppModDummyTreeSettings}
   */
  settings = new AppModDummyTreeSettings();
}
