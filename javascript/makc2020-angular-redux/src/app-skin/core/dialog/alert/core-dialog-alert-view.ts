// //Author Maxim Kuzmin//makc//

import {AppCoreDialogView} from '@app/core/dialog/core-dialog-view';
import {DynamicDialogRef} from 'primeng';


/** Ядро. Диалог. Подтверждение. Вид. */
export class AppSkinCoreDialogAlertView extends AppCoreDialogView {

  /**
   * Конструктор.
   * @param {string} message Сообщение.
   * @param {DynamicDialogRef} extDialogRef Ссылка на диалог.
   */
  constructor(
    message: string,
    private extDialogRef: DynamicDialogRef
  ) {
    super(message);
  }

  /** Обработчик события нажатия на кнопку "Принять". */
  onButtonAcceptClick() {
    this.extDialogRef.close();
  }
}
