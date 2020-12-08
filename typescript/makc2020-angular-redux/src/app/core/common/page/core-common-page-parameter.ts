// //Author Maxim Kuzmin//makc//

/**
 * Ядро. Общее. Страница. Параметр.
 * @param <TValue> Тип значения.
 */
export class AppCoreCommonPageParameter<TValue> {

  /** @type {string} */
  private _name: string;

  /**
   * Значение.
   * @type {?TValue}
   */
  value?: TValue;

  /**
   * Имя.
   * @type {string}
   */
  get name(): string {
    return this._name;
  }

  /**
   * Конструктор.
   * @param {string} name Имя.
   * @param {string} index Индекс.
   */
  constructor(name: string, index: string) {
    if (index) {
      name += index;
    }

    this._name = name;
  }

  /**
   * Проверить, различается ли значение.
   * @param {?TValue} value Значение.
   * @returns {boolean} Результат проверки.
   */
  isValueDiffer(value?: TValue): boolean {
    return this.value !== null
      &&
      typeof this.value !== 'undefined'
      &&
      value !== this.value
      &&
      (
        typeof this.value !== 'string'
        ||
        !!this.value
      );
  }
}
