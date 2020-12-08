// //Author Maxim Kuzmin//makc//

import {AppSkinCoreNotificationRef} from './core-notification-ref';

/** Ядро. Извещение. Данные. */
export class AppSkinCoreNotificationData {

  /**
   * Ссылка на сообщение.
   * @type {AppSkinCoreNotificationRef}
   */
  messageRef: AppSkinCoreNotificationRef;

  /**
   * Конструктор.
   * @param {string[]} messages Сообщения.
   */
  constructor(
    public messages: string[]
  ) {
  }
}
