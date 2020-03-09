// //Author Maxim Kuzmin//makc//

import {Inject} from '@angular/core';
import {AppCoreLoggingDefault} from '@app/core/logging/core-logging-default';
import {appCoreLoggingEntryKind, AppCoreLoggingEntryKindValue} from '@app/core/logging/core-logging-entry-kind';
import {appBaseDiTokenWindow} from '../base-di';

/** Основа. Логирование. Умолчание. */
export class AppBaseLoggingDefault extends AppCoreLoggingDefault {

  /**
   * Конструктор.
   * @param {Window} appWindow Окно.
   */
  constructor(
    @Inject(appBaseDiTokenWindow) private appWindow: Window
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
        func = this.appWindow.console.info;
        break;
      case appCoreLoggingEntryKind.debug:
        func = this.appWindow.console.debug;
        break;
      case appCoreLoggingEntryKind.error:
        func = this.appWindow.console.error;
        break;
      default:
        func = this.appWindow.console.log;
        break;
    }

    if (data) {
      func(message, data);
    } else {
      func(message);
    }
  }
}
