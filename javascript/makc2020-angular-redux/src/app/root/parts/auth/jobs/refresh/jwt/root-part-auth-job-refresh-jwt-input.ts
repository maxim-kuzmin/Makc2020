// //Author Maxim Kuzmin//makc//

/** Корень. Часть "Auth". Задания. Обновление. JWT. Ввод. */
export class AppRootPartAuthJobRefreshJwtInput {

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
