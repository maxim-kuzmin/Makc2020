// //Author Maxim Kuzmin//makc//

/** Мод "DummyTree". Задания. Список. Получение. Ввод. */
export class AppModDummyTreeJobListDeleteInput {

  /**
   * Конструктор.
   * @param {number[]} dataIds Данные: идентификаторы.
   * @param {string[]} dataNames Данные: наименования.
   */
  constructor(
    public dataIds: number[],
    public dataNames: string[]
    ) {
  }
}
