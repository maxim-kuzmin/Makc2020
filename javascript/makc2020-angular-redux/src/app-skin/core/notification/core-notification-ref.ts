// //Author Maxim Kuzmin//makc//

import {MessageService} from 'primeng/api';
import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';

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
