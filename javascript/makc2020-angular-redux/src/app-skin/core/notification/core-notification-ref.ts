// //Author Maxim Kuzmin//makc//

import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {MessageService} from 'primeng/api';

/** Ядро. Извещение. Ссылка. */
export class AppSkinCoreNotificationRef implements AppCoreCommonDisposable {

  /**
   * Конструктор.
   * @param {MessageService} extMessage Сообщение.
   */
  constructor(
    private extMessage: MessageService
  ) {
  }

  /** @inheritDoc */
  dispose() {
    this.extMessage.clear();
  }
}
