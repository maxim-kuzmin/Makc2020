// //Author Maxim Kuzmin//makc//

import {AppCoreCommonDisposable} from '@app/core/common/core-common-disposable';
import {MessageService} from 'primeng/api';

/** Хост. Разметка. Общее. Сообщение. Ссылка. */
export class AppSkinHostLayoutCommonMessageRef implements AppCoreCommonDisposable {

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
