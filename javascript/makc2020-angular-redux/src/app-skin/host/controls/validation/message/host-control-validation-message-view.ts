// //Author Maxim Kuzmin//makc//

import {AbstractControl} from '@angular/forms';
import {AppHostControlValidationMessageView} from '@app/host/controls/validation/message/host-control-validation-message-view';

/** Хост. Элементы управления. Валидация. Сообщение. Вид. */
export class AppSkinHostControlValidationMessageView extends AppHostControlValidationMessageView {

  /**
   * CSS-класс.
   * @type {any}
   */
  get cssClass() {
    return {
      'validation-message__box_right': this.offsetRight
    };
  }

  /** @inheritDoc */
  get minLength(): number {
    const {minlength} = this.control.errors;

    return minlength ? minlength.requiredLength : 0;
  }

  /**
   * Конструктор.
   * @param {AbstractControl} control Элемент управления.
   * @param {string} label Метка.
   * @param {string} messagePatternText Текст сообщения о несоответствии паттерну.
   * @param {boolean} offsetRight Признак необходимости отступа справа.
   * @param {boolean} requiredTrue Признак необходимости наличия значения в элементе управления.
   */
  constructor(
    private control: AbstractControl,
    public label: string,
    public messagePatternText: string,
    public offsetRight: boolean,
    public requiredTrue: boolean
  ) {
    super(
      label,
      messagePatternText,
      offsetRight,
      requiredTrue
    );
  }

  /** @inheritDoc */
  hasError(errorCode: string): boolean {
    return this.control.dirty && this.control.hasError(errorCode);
  }
}
