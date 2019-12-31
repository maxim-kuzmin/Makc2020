// //Author Maxim Kuzmin//makc//

import {AppCoreNotificationView} from '@app/core/notification/core-notification-view';

/** Хост. Разметка. Общее. Сообщение. Вид. */
export class AppSkinHostLayoutCommonMessageView extends AppCoreNotificationView {

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
