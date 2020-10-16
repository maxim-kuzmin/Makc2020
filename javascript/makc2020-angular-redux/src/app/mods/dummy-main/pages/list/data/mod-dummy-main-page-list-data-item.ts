// //Author Maxim Kuzmin//makc//

/** Мод "DummyMain". Страницы. Список. Данные. Элемент. */
export class AppModDummyMainPageListDataItem {

  /**
   * Конструктор.
   * @param {number} id Идентификатор.
   * @param {string} name Имя.
   * @param {string} objectDummyOneToManyName Имя объекта сущности "DummyOneToMany".
   */
  constructor(
    public id: number,
    public name: string,
    public objectDummyOneToManyName: string
  ) {
  }
}
