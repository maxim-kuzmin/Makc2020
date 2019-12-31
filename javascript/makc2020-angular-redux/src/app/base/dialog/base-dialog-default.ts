// //Author Maxim Kuzmin//makc//

import {AppCoreDialogDefault} from '@app/core/dialog/core-dialog-default';
import {Inject} from '@angular/core';
import {appBaseDiTokenWindow} from '../base-di';

/** Основа. Диалог. Умолчание. */
export class AppBaseDialogDefault extends AppCoreDialogDefault {

  /**
   * Конструктор.
   * @param {Window} window Окно.
   */
  constructor(
    @Inject(appBaseDiTokenWindow) private window: Window
  ) {
    super();
  }

  /**
   * @inheritDoc
   * @param {?string} message Сообщение с предупреждением.
   */
  alert(message?: string) {
    this.window.alert(message);
  }

  /**
   * @inheritDoc
   * @param {?string} message Сообщение, поясняющее, что нужно подтвердить.
   * @returns {boolean} Результат подтверждения.
   */
  confirm(message?: string): boolean {
    return this.window.confirm(message);
  }
}
