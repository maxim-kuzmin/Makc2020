// //Author Maxim Kuzmin//makc//

/** Мод "Auth". Страницы. Перенаправление. Вид. */
export abstract class AppModAuthPageRedirectView {

  /**
   * Признак того, что данные загружены.
   * @type {boolean}
   */
  isDataLoaded = false;

  /**
   * Сообщения об ошибках отклика.
   * @type {string[]}
   */
  responseErrorMessages: string[] = [];

  /**
   * Сообщения об успехах отклика.
   * @type {string[]}
   */
  responseSuccessMessages: string[] = [];

  /** Спрятать спиннер загрузки. */
  abstract hideLoadingSpinner();

  /**
   * Инициализировать спиннер загрузки.
   * @param {() => void} callback Функция обратного вызова.
   */
  abstract initLoadingSpinner(callback: () => void);

  /** Показать спиннер загрузки. */
  abstract showLoadingSpinner();
}
