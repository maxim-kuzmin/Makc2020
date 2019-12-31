// //Author Maxim Kuzmin//makc//

/** Ядро. Навигация. Умолчание. */
export abstract class AppCoreNavigationDefault {

  /**
   * Конструктор.
   * @param {string} apiUrl URL API: тот, с которого должен начинаться абсолютный URL API.
   * @param {string} basePath Базовый путь: тот, что указан в атрибуте href тэга base.
   * @param {string} hostUrl URL хоста: тот, с которого должен начинаться абсолютный URL хоста.
   */
  protected constructor(
    public apiUrl: string,
    public basePath: string,
    public hostUrl: string
  ) {
  }
}
