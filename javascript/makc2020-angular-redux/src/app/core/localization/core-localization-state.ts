// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreLocalizationEnumActions} from './enums/core-localization-enum-actions';

/** Хост. Часть "Workday". Состояние. */
export class AppCoreLocalizationState extends AppCoreCommonState<AppCoreLocalizationEnumActions> {

  /**
   * Ключ языка.
   * @type {string}
   */
  languageKey: string;
}
