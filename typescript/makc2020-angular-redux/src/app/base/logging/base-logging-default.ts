// //Author Maxim Kuzmin//makc//

import {Inject} from '@angular/core';
import {AppCoreLoggingDefault} from '@app/core/logging/core-logging-default';
import {appCoreLoggingEntryKind, AppCoreLoggingEntryKindValue} from '@app/core/logging/core-logging-entry-kind';
import {appBaseDiTokenConsole} from '../base-di';

/** Основа. Логирование. Умолчание. */
export class AppBaseLoggingDefault extends AppCoreLoggingDefault {

  /**
   * Конструктор.
   * @param {Console} appConsole Консоль.
   */
  constructor(
    @Inject(appBaseDiTokenConsole) private appConsole: Console
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @param {string} entryKind Вид записи.
   * @param {string} message Сообщение.
   * @param {?any} data Данные.
   */
  log(entryKind: AppCoreLoggingEntryKindValue, message: string, data?: any) {
    /** @type {Function} */
    let func;

    switch (entryKind) {
      case appCoreLoggingEntryKind.info:
        func = this.appConsole.info;
        break;
      case appCoreLoggingEntryKind.debug:
        func = this.appConsole.debug;
        break;
      case appCoreLoggingEntryKind.error:
        func = this.appConsole.error;
        break;
      default:
        func = this.appConsole.log;
        break;
    }

    if (data) {
      func(message, data);
    } else {
      func(message);
    }
  }
}
