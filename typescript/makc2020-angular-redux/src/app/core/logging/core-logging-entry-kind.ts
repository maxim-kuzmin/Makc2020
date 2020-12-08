// //Author Maxim Kuzmin//makc//

/** Ядро. Логирование. Вид записи в журнале. Значение. */
export type AppCoreLoggingEntryKindValue = 'info' | 'debug' | 'error';

/** Ядро. Логирование. Вид записи в журнале. */
export class AppCoreLoggingEntryKind {

  /**
   * Информация.
   * @type {AppCoreLoggingEntryKindValue}
   */
  info: AppCoreLoggingEntryKindValue = 'info';

  /**
   * Отладочная информация.
   * @type {AppCoreLoggingEntryKindValue}
   */
  debug: AppCoreLoggingEntryKindValue = 'debug';

  /**
   * Ошибка.
   * @type {AppCoreLoggingEntryKindValue}
   */
  error: AppCoreLoggingEntryKindValue = 'error';
}

/** Ядро. Логирование. Вид записи в журнале. */
export const appCoreLoggingEntryKind = new AppCoreLoggingEntryKind();
