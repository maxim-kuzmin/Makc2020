// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostMenuEnumActions} from './enums/host-menu-enum-actions';
import {AppHostMenuOption} from './host-menu-option';

/** Хост. Меню. Состояние.  */
export class AppHostMenuState extends AppCoreCommonState<AppHostMenuEnumActions> {

  /**
   * Ключ узла меню.
   * @type {string}
   */
  menuNodeKey: string;

  /**
   * Поиск варианта по ключу узла меню.
   * @type {[key: string]: AppHostMenuOption}
   */
  lookupOptionByMenuNodeKey: {[key: string]: AppHostMenuOption};
}
