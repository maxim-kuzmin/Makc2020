// //Author Maxim Kuzmin//makc//

/** Ядро. Общее. Мод. Задания. Список. Получить. Вывод. */
export interface AppCoreCommonModJobOptionsGetOutputItem<TValue> {

  /**
   * Имя.
   * @type {string}
   */
  name: string;

  /**
   * Значение.
   * @type {TValue}
   */
  value: TValue;
}
