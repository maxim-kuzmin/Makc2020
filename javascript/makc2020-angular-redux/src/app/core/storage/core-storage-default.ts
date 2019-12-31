// //Author Maxim Kuzmin//makc//

/** Ядро. Хранилище. Умолчание. */
export abstract class AppCoreStorageDefault {

  /**
   * Получить локальное хранилище.
   * @returns {Storage} Хранилище.
   */
  abstract getLocalStorage(): Storage;

  /**
   * Получить сессионное хранилище.
   * @returns {Storage} Хранилище.
   */
  abstract getSessionStorage(): Storage;
}
