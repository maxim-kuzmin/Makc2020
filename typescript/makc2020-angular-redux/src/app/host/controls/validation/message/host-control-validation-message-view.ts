// //Author Maxim Kuzmin//makc//

/** Хост. Элементы управления. Валидация. Сообщение. Вид. */
export abstract class AppHostControlValidationMessageView {

  /**
   * Минимальная длина.
   * @type {number}
   */
  abstract get minLength(): number;

  /**
   * Конструктор.
   * @param {string} label Метка.
   * @param {string} messagePatternText Текст сообщения о несоответствии паттерну.
   * @param {boolean} offsetRight Признак необходимости отступа справа.
   * @param {boolean} requiredTrue Признак необходимости наличия значения в элементе управления.
   */
  protected constructor(
    public label: string,
    public messagePatternText: string,
    public offsetRight: boolean,
    public requiredTrue: boolean,
  ) {
  }

  /**
   * Содержит ошибку.
   * @param {string} errorCode Код ошибки.
   * @returns {boolean}
   */
  abstract hasError(errorCode: string): boolean;
}
