// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Модуль. Задания. Список. Получить. Вывод. */
export interface AppCoreCommonModJobListGetOutput<TItem> {

  /**
   * Элементы.
   * @type {TItem[]}
   */
  items: TItem[];

  /**
   * Общее число элементов.
   * @type {number}
   */
  totalCount: number;
}
