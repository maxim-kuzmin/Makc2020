// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostPartMenuEnumActions} from './enums/host-part-menu-enum-actions';
import {AppHostPartMenuOption} from './host-part-menu-option';

/** Хост. Часть "Menu". Состояние.  */
export class AppHostPartMenuState extends AppCoreCommonState<AppHostPartMenuEnumActions> {

  /**
   * Ключ узла меню.
   * @type {string}
   */
  menuNodeKey: string;

  /**
   * Поиск варианта по ключу узла меню.
   * @type {[key: string]: AppHostMenuOption}
   */
  lookupOptionByMenuNodeKey: {[key: string]: AppHostPartMenuOption};
}
