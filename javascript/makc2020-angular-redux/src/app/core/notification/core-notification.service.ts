// //Author Maxim Kuzmin//makc//

import {AppCoreCommonDisposable} from '../common/core-common-disposable';

/** Ядро. Извещение. Сервис. */
export abstract class AppCoreNotificationService {

  /**
   * Показать сообщения об ошибках.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showError(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать информационные сообщения.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showInfo(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать сообщения об успехе.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showSuccess(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать предупреждающие сообщения.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showWarn(messages: string[]): AppCoreCommonDisposable;
}
