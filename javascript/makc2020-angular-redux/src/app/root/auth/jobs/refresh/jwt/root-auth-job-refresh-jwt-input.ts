// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Задания. Обновление. JWT. Ввод. */
export class AppRootAuthJobRefreshJwtInput {

  /**
   * Токен данных.
   * @type {?string}
   */
  dataToken?: string;

  /**
   * Конструктор.
   * @param {?string} dataToken Токен данных.
   */
  constructor(dataToken?: string) {
    if (dataToken) {
      this.dataToken = dataToken;
    }
  }
}
