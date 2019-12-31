// //Author Maxim Kuzmin//makc//

import {AppCoreLoggingEntryKindValue} from './core-logging-entry-kind';

/** Ядро. Логирование. Умолчание. */
export abstract class AppCoreLoggingDefault {

  /**
   * Зарегистрировать.
   * @param {AppCoreLoggingEntryKindValue} entryKind Вид записи.
   * @param {string} message Сообщение.
   * @param {any} data Данные.
   */
  abstract log(entryKind: AppCoreLoggingEntryKindValue, message: string, data: any);
}
