// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';

/** Мод "DummyTree". Задания. Список. Получение. Ввод. */
export class AppModDummyTreeJobListGetInput extends AppCoreCommonModJobListGetInput {

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Строка идентификаторов.
   * @type {?string}
   */
  dataIdsString?: string;

  /**
   * Конструктор.
   * @param {?number} pageNumber Номер страницы данных.
   * @param {?number} pageSize Размер страницы данных.
   * @param {?string} sortField Поле сортировки данных.
   * @param {?string} sortDirection Направление сортировки данных.
   * @param {?string} dataName Имя данных.
   * @param {?string} dataIdsString Строка идентификаторов данных.
   */
  constructor(
    pageNumber?: number,
    pageSize?: number,
    sortField?: string,
    sortDirection?: string,
    dataName?: string,
    dataIdsString?: string
  ) {
    super(
      pageNumber,
      pageSize,
      sortDirection,
      sortField,
    );

    if (dataName) {
      this.dataName = dataName;
    }

    if (dataIdsString) {
      this.dataIdsString = dataIdsString;
    }
  }

  /**
   * Равно другому.
   * @param {AppModDummyTreeJobListGetInput} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModDummyTreeJobListGetInput): boolean {
    return other
      && this.dataIdsString === other.dataIdsString
      && this.dataName === other.dataName
      && this.pageNumber === other.pageNumber
      && this.pageSize === other.pageSize
      && this.sortDirection === other.sortDirection
      && this.sortField === other.sortField;
  }
}
