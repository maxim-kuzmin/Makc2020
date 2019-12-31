// //Author Maxim Kuzmin//makc//

/** Хост. Аутентификация. Общее. Задания. Регистрация. Ввод. */
export class AppHostAuthCommonJobRegisterInput {

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
   * Полное имя данных.
   * @type {?string}
   */
  dataFullName?: string;

  /**
   * Конструктор.
   * @param {?string} dataUserName Имя пользователя данных.
   * @param {?string} dataEmail Адрес электронной почты данных.
   * @param {?string} dataPassword Пароль данных.
   * @param {?string} dataFullName Полное имя данных.
   */
  constructor(
    dataUserName?: string,
    dataEmail?: string,
    dataPassword?: string,
    dataFullName?: string
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

    if (dataFullName) {
      this.dataFullName = dataFullName;
    }
  }
}
