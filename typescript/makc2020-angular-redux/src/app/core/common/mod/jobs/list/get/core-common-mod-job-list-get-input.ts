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
   * Направление сортировки.
   * @type {?string}
   */
  sortDirection?: string;

  /**
   * Поле сортировки.
   * @type {?string}
   */
  sortField?: string;

  /**
   * Конструктор.
   * @param {?number} pageNumber Номер страницы.
   * @param {?number} pageSize Размер страницы.
   * @param {?string} sortDirection Направление сортировки.
   * @param {?string} sortField Поле сортировки.
   */
  constructor(
    pageNumber?: number,
    pageSize?: number,
    sortDirection?: string,
    sortField?: string
  ) {
    if (pageNumber) {
      this.pageNumber = pageNumber;
    }

    if (pageSize) {
      this.pageSize = pageSize;
    }

    if (sortDirection) {
      this.sortDirection = sortDirection;
    }

    if (sortField) {
      this.sortField = sortField;
    }
  }
}
