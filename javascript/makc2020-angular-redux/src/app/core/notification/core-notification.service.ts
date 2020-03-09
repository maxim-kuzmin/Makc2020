// //Author Maxim Kuzmin//makc//

import {AppCoreCommonDisposable} from '../common/core-common-disposable';

/** Ядро. Извещение. Сервис. */
export abstract class AppCoreNotificationService {

  /**
   * Показать ошибку.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showError(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать информацию.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showInfo(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать успех.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showSuccess(messages: string[]): AppCoreCommonDisposable;

  /**
   * Показать предупреждение.
   * @param {string[]} messages Сообщения.
   * @returns {AppCoreCommonDisposable} То, что позволит удалить показанное.
   */
  abstract showWarning(messages: string[]): AppCoreCommonDisposable;
}
