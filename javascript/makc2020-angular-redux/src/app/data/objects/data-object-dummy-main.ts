// //Author Maxim Kuzmin//makc//

/** Данные. Объекты. Сущность "DummyMain". */
export interface AppDataObjectDummyMain {

  /**
   * Идентификатор.
   * @type {number}
   */
  id: number;

  /**
   * Имя.
   * @type {string}
   */
  name: string;

  /**
   * Идентификатор объекта, где хранятся данные сущности "DummyOneToMany".
   * @type {number}
   */
  objectDummyOneToManyId: number;

  /**
   * Свойство, содержащее логическое значение.
   * @type {boolean}
   */
  propBoolean: boolean;

  /**
   * Свойство, содержащее логическое значение или NULL.
   * @type {?boolean}
   */
  propBooleanNullable?: boolean;

  /**
   * Свойство, содержащее дату.
   * @type {Date}
   */
  propDate: Date;

  /**
   * Свойство, содержащее дату или NULL.
   * @type {?Date}
   */
  propDateNullable?: Date;

  /**
   * Свойство, содержащее дату и время с часовым поясом.
   * @type {Date}
   */
  propDateTimeOffset: Date;

  /**
   * Свойство, содержащее дату и время с часовым поясом или NULL.
   * @type {?Date}
   */
  propDateTimeOffsetNullable?: Date;

  /**
   * Свойство, содержащее десятичную дробь.
   * @type {number}
   */
  propDecimal: number;

  /**
   * Свойство, содержащее десятичную дробь или NULL.
   * @type {?number}
   */
  propDecimalNullable?: number;

  /**
   * Свойство, содержащее целое 32-разрядное число.
   * @type {number}
   */
  propInt32: number;

  /**
   * Свойство, содержащее целое 32-разрядное число или NULL.
   * @type {?number}
   */
  propInt32Nullable?: number;

  /**
   * Свойство, содержащее целое 64-разрядное число.
   * @type {number}
   */
  propInt64: number;

  /**
   * Свойство, содержащее целое 64-разрядное число или NULL.
   * @type {?number}
   */
  propInt64Nullable?: number;

  /**
   * Свойство, содержащее строку.
   * @type {string}
   */
  propString: string;

  /**
   * Свойство, содержащее строку или NULL.
   * @type {?string}
   */
  propStringNullable?: string;
}

/** Данные. Объекты. Сущность "DummyMain". Создать. */
export function appDataObjectDummyMainCreate(): AppDataObjectDummyMain {
  return {} as AppDataObjectDummyMain;
}
