// //Author Maxim Kuzmin//makc//

/** Ядро. Аутентификация. Типы. OIDC. Задания. Запуск. Ввод. */
export class AppCoreAuthTypeOidcJobStartInput {

  /**
   * URL перенаправления после входа в систему.
   * @type {string}
   */
  redirectUrl: string;

  /**
   * Конструктор.
   * @param {?string} redirectUrl URL перенаправления после входа в систему.
   */
  constructor(
    redirectUrl?: string
  ) {
    if (redirectUrl) {
      this.redirectUrl = redirectUrl;
    }
  }
}
