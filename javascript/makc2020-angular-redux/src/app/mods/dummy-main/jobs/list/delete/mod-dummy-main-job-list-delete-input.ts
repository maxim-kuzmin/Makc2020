// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Задания. Список. Получение. Ввод. */
export class AppModDummyMainJobListDeleteInput {

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

  /**
   * Равно другому.
   * @param {AppModDummyMainJobListDeleteInput} other Другое.
   * @returns {boolean} Результат сравнения с другим.
   */
  equals(other: AppModDummyMainJobListDeleteInput): boolean {
    return other
      &&
      (
        !this.dataIds && !other.dataIds
        ||
        this.dataIds && other.dataIds && this.dataIds.join(',') === other.dataIds.join(',')
      )
      &&
      (
        !this.dataNames && !other.dataNames
        ||
        this.dataNames && other.dataNames && this.dataNames.join(',') === other.dataNames.join(',')
      );
  }
}
