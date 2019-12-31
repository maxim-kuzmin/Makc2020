// //Author Maxim Kuzmin//makc//

import {AppCoreCommonModJobListGetInput} from '@app/core/common/mod/jobs/list/get/core-common-mod-job-list-get-input';

/** Мод "DummyMain". Задания. Список. Получение. Ввод. */
export class AppModDummyMainJobListGetInput extends AppCoreCommonModJobListGetInput {

  /**
   * Имя объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {?string}
   */
  dataObjectDummyOneToManyName?: string;

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
   * @param {?number} dataPageNumber Номер страницы данных.
   * @param {?number} dataPageSize Размер страницы данных.
   * @param {?string} dataSortField Поле сортировки данных.
   * @param {?string} dataSortDirection Направление сортировки данных.
   * @param {?string} dataObjectDummyOneToManyName Имя объекта, где хранятся данные сущности "DummyOneToMany".
   * @param {?number} dataObjectDummyOneToManyId Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
   * @param {?string} dataObjectDummyOneToManyIdsString Строка идентификаторов объектов, где хранятся данные сущности "DummyOneToMany".
   * @param {?string} dataName Имя данных.
   * @param {?string} dataIdsString Строка идентификаторов данных.
   */
  constructor(
    dataPageNumber?: number,
    dataPageSize?: number,
    dataSortField?: string,
    dataSortDirection?: string,
    dataObjectDummyOneToManyName?: string,
    dataObjectDummyOneToManyId?: number,
    dataObjectDummyOneToManyIdsString?: string,
    dataName?: string,
    dataIdsString?: string
  ) {
    super(
      dataPageNumber,
      dataPageSize,
      dataSortField,
      dataSortDirection
    );

    if (dataObjectDummyOneToManyName) {
      this.dataObjectDummyOneToManyName = dataObjectDummyOneToManyName;
    }

    if (dataObjectDummyOneToManyId) {
      this.dataObjectDummyOneToManyId = dataObjectDummyOneToManyId;
    }

    if (dataObjectDummyOneToManyIdsString) {
      this.dataObjectDummyOneToManyIdsString = dataObjectDummyOneToManyIdsString;
    }

    if (dataName) {
      this.dataName = dataName;
    }

    if (dataIdsString) {
      this.dataIdsString = dataIdsString;
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
      && this.dataPageNumber === other.dataPageNumber
      && this.dataPageSize === other.dataPageSize
      && this.dataSortDirection === other.dataSortDirection
      && this.dataSortField === other.dataSortField;
  }
}
