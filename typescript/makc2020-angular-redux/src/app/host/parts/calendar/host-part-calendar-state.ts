// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostPartCalendarEnumActions} from './enums/host-part-calendar-enum-actions';

/** Хост. Часть "Calendar". Состояние. */
export class AppHostPartCalendarState extends AppCoreCommonState<AppHostPartCalendarEnumActions> {

  /**
   * Ключ языка.
   * @type {string}
   */
  languageKey: string;
}
