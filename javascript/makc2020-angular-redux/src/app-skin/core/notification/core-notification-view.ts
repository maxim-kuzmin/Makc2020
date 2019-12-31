// //Author Maxim Kuzmin//makc//

import {AppCoreNotificationView} from '@app/core/notification/core-notification-view';

/** Ядро. Извещение. Вид. */
export class AppSkinCoreNotificationView extends AppCoreNotificationView {

  /**
   * Конструктор.
   * @param {string} cssStyle Стиль CSS.
   */
  constructor(
    public cssStyle: any
  ) {
    super(
      []
    );
  }
}
