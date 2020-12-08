// //Author Maxim Kuzmin//makc//

/** Ядро. Аутентификация. Типы. OIDC. Задания. Вход в систему. Ввод. */
export class AppCoreAuthTypeOidcJobLoginInput {

  /**
   * URL возврата.
   * @type {string}
   */
  returnUrl: string;

  /**
   * Конструктор.
   * @param {?string} returnUrl URL возврата.
   */
  constructor(
    returnUrl?: string
  ) {
    if (returnUrl) {
      this.returnUrl = returnUrl;
    }
  }
}
