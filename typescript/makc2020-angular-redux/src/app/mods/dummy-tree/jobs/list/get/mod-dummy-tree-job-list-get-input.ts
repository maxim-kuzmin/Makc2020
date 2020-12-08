// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';

/** Мод "DummyTree". Задания. Список. Получение. Ввод. */
export class AppModDummyTreeJobListGetInput extends AppCoreCommonModJobListGetInput {

  /**
   * Строка идентификаторов.
   * @type {?string}
   */
  dataIdsString?: string;

  /**
   * Имя.
   * @type {?string}
   */
  dataName?: string;

  /**
   * Конструктор.
   * @param {?number} pageNumber Номер страницы.
   * @param {?number} pageSize Размер страницы.
   * @param {?string} sortDirection Направление сортировки.
   * @param {?string} sortField Поле сортировки.
   * @param {?string} dataIdsString Данные: строка идентификаторов.
   * @param {?string} dataName Данные: имя.
   */
  constructor(
    pageNumber?: number,
    pageSize?: number,
    sortDirection?: string,
    sortField?: string,
    dataIdsString?: string,
    dataName?: string
  ) {
    super(
      pageNumber,
      pageSize,
      sortDirection,
      sortField,
    );

    if (dataIdsString) {
      this.dataIdsString = dataIdsString;
    }

    if (dataName) {
      this.dataName = dataName;
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
