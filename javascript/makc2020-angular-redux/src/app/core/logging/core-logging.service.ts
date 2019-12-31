// //Author Maxim Kuzmin//makc//

import {Inject, Injectable} from '@angular/core';
import {AppCoreLoggingDefault} from './core-logging-default';
import {appCoreLoggingEntryKind} from './core-logging-entry-kind';
import {appCoreLoggingDiTokenLoggerName} from './core-logging-di';
import {AppCoreLoggingStore} from '@app/core/logging/core-logging-store';

/** Ядро. Логирование. Сервис. */
@Injectable()
export class AppCoreLoggingService {

  /**
   * Конструктор.
   * @param {string} loggerName Имя регистратора.
   * @param {AppCoreLoggingDefault} appLoggerDefault Умолчание регистратора.
   * @param {AppCoreLoggingStore} appStore Хранилище состояния.
   */
  constructor(
    @Inject(appCoreLoggingDiTokenLoggerName) private loggerName: string,
    private appLoggerDefault: AppCoreLoggingDefault,
    private appStore: AppCoreLoggingStore
  ) {
  }

  /**
   * Зарегистрировать информацию.
   * @param {string} message Сообщение.
   * @param {?any} data Данные.
   */
  logInfo(message: string, data?: any) {
    this.appLoggerDefault.log(appCoreLoggingEntryKind.info, this.transformMessage(message), data);
  }

  /**
   * Зарегистрировать отладочную информацию.
   * @param {string} message Сообщение.
   * @param {?any} data Данные.
   */
  logDebug(message: string, data?: any) {
    this.appLoggerDefault.log(appCoreLoggingEntryKind.debug, this.transformMessage(message), data);
  }

  /**
   * Зарегистрировать ошибку.
   * @param {boolean} errorIsUnhandled Признак того, что ошибка не обработана.
   * @param {string} message Сообщение.
   * @param {?any} data Данные.
   */
  logError(errorIsUnhandled: boolean, message: string, data?: any) {
    this.appStore.runActionLogError(errorIsUnhandled, message, data);

    this.appLoggerDefault.log(appCoreLoggingEntryKind.error, this.transformMessage(message), data);
  }

  /**
   * @param {string} message
   * @returns {string}
   */
  private transformMessage(message: string): string {
    return message ? `${this.loggerName}: ${message}` : this.loggerName;
  }
}
