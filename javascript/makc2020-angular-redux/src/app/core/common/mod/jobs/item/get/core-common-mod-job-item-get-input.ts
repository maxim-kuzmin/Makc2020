// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Модуль. Задания. Элемент. Получить. Ввод. */
export class AppCoreCommonModJobItemGetInput {

  /**
   * Данные: идентификатор.
   * @type {?number}
   */
  dataId?: number;

  /**
   * Конструктор.
   * @param {?number} dataId Данные: идентификатор.
   */
  constructor(dataId?: number) {
    if (dataId) {
      this.dataId = dataId;
    }
  }
}
