// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';

/** Мод "DummyMain". Задания. Список. Получение. Ввод. */
export class AppModDummyMainJobListGetInput extends AppCoreCommonModJobListGetInput {

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
   * Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {?number}
   */
  dataObjectDummyOneToManyId?: number;

  /**
   * Строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
   * @type {?string}
   */
  dataObjectDummyOneToManyIdsString?: string;

  /**
   * Имя объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {?string}
   */
  dataObjectDummyOneToManyName?: string;

  /**
   * Конструктор.
   * @param {?number} pageNumber Номер страницы.
   * @param {?number} pageSize Размер страницы.
   * @param {?string} sortField Поле сортировки.
   * @param {?string} sortDirection Направление сортировки.
   * @param {?string} dataIdsString Данные: строка идентификаторов.
   * @param {?string} dataName Данные: имя.
   * @param {?number} dataObjectDummyOneToManyId
   * Данные: Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
   * @param {?string} dataObjectDummyOneToManyIdsString
   * Данные: строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
   * @param {?string} dataObjectDummyOneToManyName
   * Данные: имя объекта, где хранятся данные сущности "DummyOneToMany".
   */
  constructor(
    pageNumber?: number,
    pageSize?: number,
    sortField?: string,
    sortDirection?: string,
    dataIdsString?: string,
    dataName?: string,
    dataObjectDummyOneToManyId?: number,
    dataObjectDummyOneToManyIdsString?: string,
    dataObjectDummyOneToManyName?: string
  ) {
    super(
      pageNumber,
      pageSize,
      sortField,
      sortDirection
    );

    if (dataIdsString) {
      this.dataIdsString = dataIdsString;
    }

    if (dataName) {
      this.dataName = dataName;
    }

    if (dataObjectDummyOneToManyId) {
      this.dataObjectDummyOneToManyId = dataObjectDummyOneToManyId;
    }

    if (dataObjectDummyOneToManyIdsString) {
      this.dataObjectDummyOneToManyIdsString = dataObjectDummyOneToManyIdsString;
    }

    if (dataObjectDummyOneToManyName) {
      this.dataObjectDummyOneToManyName = dataObjectDummyOneToManyName;
    }
  }

  /**
   * Равно другому.
   * @param {AppModDummyMainJobListGetInput} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModDummyMainJobListGetInput): boolean {
    return other
      && this.dataIdsString === other.dataIdsString
      && this.dataName === other.dataName
      && this.dataObjectDummyOneToManyId === other.dataObjectDummyOneToManyId
      && this.dataObjectDummyOneToManyIdsString === other.dataObjectDummyOneToManyIdsString
      && this.dataObjectDummyOneToManyName === other.dataObjectDummyOneToManyName
      && this.pageNumber === other.pageNumber
      && this.pageSize === other.pageSize
      && this.sortDirection === other.sortDirection
      && this.sortField === other.sortField;
  }
}
