// //Author Maxim Kuzmin//makc//

import {AppCoreDialogAlertSettingButtons} from './settings/core-dialog-alert-setting-buttons';

/** Ядро. Диалог. Предупреждение. Настройки. */
export class AppCoreDialogAlertSettings {

  /**
   * Заголовок.
   * @type {string}
   */
  title = 'Предупреждение';

  /**
   * Кнопки.
   * @type {AppCoreDialogAlertSettingButtons}
   */
  buttons = new AppCoreDialogAlertSettingButtons();
}
