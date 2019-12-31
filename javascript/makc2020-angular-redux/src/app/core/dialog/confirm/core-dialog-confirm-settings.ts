// //Author Maxim Kuzmin//makc//

import {AppCoreDialogConfirmSettingButtons} from './settings/core-dialog-confirm-setting-buttons';

/** Ядро. Диалог. Подтверждение. Настройки. */
export class AppCoreDialogConfirmSettings {

    /**
     * Заголовок.
     * @type {string}
     */
    titleResourceKey = 'Подтверждение';

    /**
     * Кнопки.
     * @type {AppCoreDialogConfirmSettingButtons}
     */
    buttons = new AppCoreDialogConfirmSettingButtons();
}
