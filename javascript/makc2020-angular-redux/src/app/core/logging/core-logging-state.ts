// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreLoggingEnumActions} from './enums/core-logging-enum-actions';

/** Ядро. Логирование. Состояние. */
export class AppCoreLoggingState extends AppCoreCommonState<AppCoreLoggingEnumActions> {

  /**
   * Отладочные сообщения.
   * @type {string[]}
   */
  debugMessages: string[];

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
   * Сообщения об ошибках.
   * @type {string[]}
   */
  errorMessages: string[];

  /**
   * Сообщения об успехах.
   * @type {string[]}
   */
  successMessages: string[];

  /**
   * Предупреждающие сообщения.
   * @type {string[]}
   */
  warningMessages: string[];
}
