// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Модуль. Задания. Список. Получить. Ввод. */
export class AppCoreCommonModJobListGetInput {

  /**
   * Номер страницы данных.
   * @type {?number}
   */
  dataPageNumber?: number;

  /**
   * Размер страницы данных.
   * @type {?number}
   */
  dataPageSize?: number;

  /**
   * Поле сортировки данных.
   * @type {?string}
   */
  dataSortField?: string;

  /**
   * Направление сортировки данных.
   * @type {?string}
   */
  dataSortDirection?: string;

  /**
   * Конструктор.
   * @param {?number} dataPageNumber Номер страницы данных.
   * @param {?number} dataPageSize Размер страницы данных.
   * @param {?string} dataSortField Поле сортировки данных.
   * @param {?string} dataSortDirection Направление сортировки данных.
   */
  constructor(
    dataPageNumber?: number,
    dataPageSize?: number,
    dataSortField?: string,
    dataSortDirection?: string
  ) {
    if (dataPageNumber) {
      this.dataPageNumber = dataPageNumber;
    }

    if (dataPageSize) {
      this.dataPageSize = dataPageSize;
    }

    if (dataSortField) {
      this.dataSortField = dataSortField;
    }

    if (dataSortDirection) {
      this.dataSortDirection = dataSortDirection;
    }
  }
}
