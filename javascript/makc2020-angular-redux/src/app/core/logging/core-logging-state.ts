// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreLoggingEnumActions} from './enums/core-logging-enum-actions';

/** Ядро. Логирование. Состояние. */
export class AppCoreLoggingState extends AppCoreCommonState<AppCoreLoggingEnumActions> {

  /**
   * Отладочное сообщение.
   * @type {string}
   */
  debugMessage: string;

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
   * @type {string}
   */
  errorMessage: string;

  /**
   * Сообщение об успехе.
   * @type {string}
   */
  successMessage: string;

  /**
   * Предупреждающее сообщение.
   * @type {string}
   */
  warningMessage: string;
}
