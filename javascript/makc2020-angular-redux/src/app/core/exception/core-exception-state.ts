// //Author Maxim Kuzmin//makc//

import {AppCoreCommonState} from '@app/core/common/core-common-state';
import {AppCoreExceptionEnumActions} from './enums/core-exception-enum-actions';

/** Ядро. Исключение. Состояние. */
export class AppCoreExceptionState extends AppCoreCommonState<AppCoreExceptionEnumActions> {

  /**
   * Ошибка.
   * @type {any}
   */
  error: any;

  /**
   * Сообщение.
   * @type {string}
   */
  message: string;
}
