// //Author Maxim Kuzmin//makc//

/** Хост. Часть "Auth". Общее. Задания. Вход в систему. Ввод. */
export class AppHostPartAuthCommonJobLoginInput {

  /**
   * Имя пользователя данных.
   * @type {?string}
   */
  dataUserName?: string;

  /**
   * Адрес электронной почты данных.
   * @type {?string}
   */
  dataEmail?: string;

  /**
   * Пароль данных.
   * @type {?string}
   */
  dataPassword?: string;

  /**
   * Конструктор.
   * @param {?string} dataUserName Имя пользователя данных.
   * @param {?string} dataEmail Адрес электронной почты данных.
   * @param {?string} dataPassword Пароль данных.
   */
  constructor(
    dataUserName?: string,
    dataEmail?: string,
    dataPassword?: string
  ) {
    if (dataUserName) {
      this.dataUserName = dataUserName;
    }

    if (dataEmail) {
      this.dataEmail = dataEmail;
    }

    if (dataPassword) {
      this.dataPassword = dataPassword;
    }
  }
}
