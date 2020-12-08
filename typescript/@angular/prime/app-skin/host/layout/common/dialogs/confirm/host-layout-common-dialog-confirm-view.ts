// //Author Maxim Kuzmin//makc//

import {AppCoreDialogView} from '@app/core/dialog/core-dialog-view';
import {DynamicDialogRef} from 'primeng/api';

/** Хост. Разметка. Диалоги. Подтверждение. Вид. */
export class AppSkinHostLayoutCommonDialogConfirmView extends AppCoreDialogView {

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

  /** Обработчик события нажатия на кнопку "Нет". */
  onButtonNoClick() {
    this.extDialogRef.close(false);
  }

  /** Обработчик события нажатия на кнопку "Да". */
  onButtonYesClick() {
    this.extDialogRef.close(true);
  }
}
