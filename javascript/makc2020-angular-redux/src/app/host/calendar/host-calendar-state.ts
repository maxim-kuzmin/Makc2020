// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppHostCalendarEnumActions} from './enums/host-calendar-enum-actions';

/** Хост. Календарь. Состояние. */
export class AppHostCalendarState extends AppCoreCommonState<AppHostCalendarEnumActions> {

  /**
   * Ключ языка.
   * @type {string}
   */
  languageKey: string;
}
