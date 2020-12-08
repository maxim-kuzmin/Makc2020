// //Author Maxim Kuzmin//makc//

import {AppCoreCommonPageParameter} from '@app/core/common/page/core-common-page-parameter';

/** Ядро. Общее. Страница. Параметры. */
export class AppCoreCommonPageParameters {

  /** @type {string} */
  private readonly _index: string;

  /**
   * Параметр "Метка времени".
   * @type {number}
   */
  private _paramTimestamp = new AppCoreCommonPageParameter<number>('@', '');

  /**
   * Индекс.
   * @type {string}
   */
  get index(): string {
    return this._index;
  }

  /**
   * Конструктор.
   * @param {string} index Индекс.
   */
  constructor(index: string) {
    this._index = index;

    if (this._index === undefined || this._index === null) {
      this._index = '';
    }

    this._paramTimestamp.value = new Date().getTime();
  }

  /**
   * Создать строку запроса.
   * @returns {any} Строка запроса.
   */
  createQueryString(): any {
    const result = {};

    result[this._paramTimestamp.name] = this._paramTimestamp.value;

    return result;
  }
}
