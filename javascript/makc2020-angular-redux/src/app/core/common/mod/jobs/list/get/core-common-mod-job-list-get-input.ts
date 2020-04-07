// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Модуль. Задания. Список. Получить. Ввод. */
export class AppCoreCommonModJobListGetInput {

  /**
   * Номер страницы.
   * @type {?number}
   */
  pageNumber?: number;

  /**
   * Размер страницы.
   * @type {?number}
   */
  pageSize?: number;

  /**
   * Поле сортировки.
   * @type {?string}
   */
  sortField?: string;

  /**
   * Направление сортировки.
   * @type {?string}
   */
  sortDirection?: string;

  /**
   * Конструктор.
   * @param {?number} pageNumber Номер страницы.
   * @param {?number} pageSize Размер страницы.
   * @param {?string} sortField Поле сортировки.
   * @param {?string} sortDirection Направление сортировки.
   */
  constructor(
    pageNumber?: number,
    pageSize?: number,
    sortField?: string,
    sortDirection?: string
  ) {
    if (pageNumber) {
      this.pageNumber = pageNumber;
    }

    if (pageSize) {
      this.pageSize = pageSize;
    }

    if (sortField) {
      this.sortField = sortField;
    }

    if (sortDirection) {
      this.sortDirection = sortDirection;
    }
  }
}
