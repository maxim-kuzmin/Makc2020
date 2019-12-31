// //Author Maxim Kuzmin//makc//

/** Ядро. Хранилище. Базовое. */
export class AppCoreStorageBase {

  /**
   * Конструктор.
   * @param {Storage} storage Хранилище.
   */
  constructor(
    private storage: Storage
  ) { }

  /**
   * Получить.
   * @param {string} key Ключ.
   * @returns {string} Значение.
   */
  get(key: string): string {
    return this.storage.getItem(key);
  }

  /**
   * Установить.
   * @param {string} key Ключ.
   * @param {string} value Значение.
   */
  set(key: string, value: string) {
    this.storage.setItem(key, value);
  }

  /**
   * Удалить.
   * @param {string} key Ключ.
   */
  remove(key: string) {
    this.storage.removeItem(key);
  }

  /** Очистить. */
  clear() {
    this.storage.clear();
  }
}
