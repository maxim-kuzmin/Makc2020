// //Author Maxim Kuzmin//makc//

import {AppCoreNotificationView} from '@app/core/notification/core-notification-view';
import {AppSkinCoreNotificationRef} from './core-notification-ref';

/** Ядро. Извещение. Вид. */
export class AppSkinCoreNotificationView extends AppCoreNotificationView {

  /**
   * Ссылка на сообщение.
   * @type {AppSkinCoreNotificationRef}
   */
  messageRef: AppSkinCoreNotificationRef;

  /**
   * Конструктор.
   * @param {string[]} messages Сообщения.
   * @param {string} cssClass Класс CSS.
   */
  constructor(
    messages: string[],
    public cssClass: string
  ) {
    super(
      messages
    );
  }
}
