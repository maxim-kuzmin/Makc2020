// //Author Maxim Kuzmin//makc//

import {appCoreLoggingEntryKind, AppCoreLoggingEntryKindValue} from '@app/core/logging/core-logging-entry-kind';
import {AppCoreLoggingDefault} from '@app/core/logging/core-logging-default';
import {Inject} from '@angular/core';
import {appBaseDiTokenWindow} from '../base-di';

/** Основа. Логирование. Умолчание. */
export class AppBaseLoggingDefault extends AppCoreLoggingDefault {

  /**
   * Конструктор.
   * @param {Window} window Окно.
   */
  constructor(
    @Inject(appBaseDiTokenWindow) private window: Window
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @param {string} entryKind Вид записи.
   * @param {string} message Сообщение.
   * @param {any} data Данные.
   */
  log(entryKind: AppCoreLoggingEntryKindValue, message: string, data: any) {
    /** @type {Function} */
    let func;

    switch (entryKind) {
      case appCoreLoggingEntryKind.info:
        func = this.window.console.info;
        break;
      case appCoreLoggingEntryKind.debug:
        func = this.window.console.debug;
        break;
      case appCoreLoggingEntryKind.error:
        func = this.window.console.error;
        break;
      default:
        func = this.window.console.log;
        break;
    }

    if (data) {
      func(message, data);
    } else {
      func(message);
    }
  }
}
