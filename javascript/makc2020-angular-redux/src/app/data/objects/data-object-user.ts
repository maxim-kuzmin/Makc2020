// //Author Maxim Kuzmin//makc//

/** Данные. Объекты. Сущность "User". */
export interface AppDataObjectUser {

  /**
   * Идентификатор.
   * @type {number}
   */
  id: number;

  /**
   * Имя пользователя.
   * @type {string}
   */
  userName: string;

  /**
   * Адрес электронной почты.
   * @type {string}
   */
  email: string;

  /**
   * Полное имя.
   * @type {?string}
   */
  fullName?: string;
}
