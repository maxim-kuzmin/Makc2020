// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreLoggingEnumActions} from './enums/core-logging-enum-actions';

/** Ядро. Логирование. Состояние. */
export class AppCoreLoggingState extends AppCoreCommonState<AppCoreLoggingEnumActions> {

  /**
   * Данные ошибки.
   * @type {any}
   */
  errorData: any;

  /**
   * Признак того, что ошибка необработана.
   * @type {boolean}
   */
  errorIsUnhandled: boolean;

  /**
   * Сообщение об ошибке.
   * @type {any}
   */
  errorMessage: string;
}
