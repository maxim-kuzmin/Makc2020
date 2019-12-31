// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Модуль. Задания. Элемент. Получить. Ввод. */
export class AppCoreCommonModJobItemGetInput {

  /**
   * Идентификатор данных.
   * @type {?number}
   */
  dataId?: number;

  /**
   * Конструктор.
   * @param {?number} dataId Идентификатор данных.
   */
  constructor(dataId?: number) {
    if (dataId) {
      this.dataId = dataId;
    }
  }
}
