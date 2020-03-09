// //Author Maxim Kuzmin//makc//

import {Inject, Injectable} from '@angular/core';
import {AppCoreLoggingDefault} from './core-logging-default';
import {appCoreLoggingDiTokenLoggerName} from './core-logging-di';
import {appCoreLoggingEntryKind} from './core-logging-entry-kind';

/** Ядро. Логирование. Сервис. */
@Injectable()
export class AppCoreLoggingService {

  /**
   * Конструктор.
   * @param {string} loggerName Имя регистратора.
   * @param {AppCoreLoggingDefault} appLoggerDefault Умолчание регистратора.
   */
  constructor(
    @Inject(appCoreLoggingDiTokenLoggerName) private loggerName: string,
    private appLoggerDefault: AppCoreLoggingDefault
  ) {
  }

  /**
   * Зарегистрировать ошибку.
   * @param {string[]} messages Сообщения.
   * @param {any} error Ошибка.
   */
  logError(messages: string[], error: any) {
    this.appLoggerDefault.log(appCoreLoggingEntryKind.error, this.createMessage(messages), error);
  }

  /**
   * Зарегистрировать успех.
   * @param {string[]} messages Сообщения.
   */
  logSuccess(messages: string[]) {
    this.appLoggerDefault.log(appCoreLoggingEntryKind.info, this.createMessage(messages));
  }

  /**
   * Зарегистрировать предупреждение.
   * @param {string[]} messages Сообщения.
   */
  logWarning(messages: string[]) {
    const message = this.createMessage(messages);

    this.appLoggerDefault.log(appCoreLoggingEntryKind.info, this.createMessage(messages));
  }

  /**
   * @param {string[]} messages
   * @returns {string}
   */
  private createMessage(messages: string[]): string {
    const message =  messages.join('. ');

    return message ? `${this.loggerName}: ${message}` : this.loggerName;
  }
}
