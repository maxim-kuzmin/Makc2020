// //Author Maxim Kuzmin//makc//

/** Ядро. Настройки. */
export class AppCoreSettings {

  /**
   * Размер страницы.
   * @type {string}
   */
  pageSize = 10;

  /**
   * Опции размера страницы.
   * @type {number[]}
   */
  pageSizeOptions = [10, 25, 50, 100, 250];

  /**
   * Направление сортировки.
   * @type {string}
   */
  sortDirection = 'desc';

  /**
   * Задержка поиска в миллисекундах.
   * @type {number}
   */
  searchDelayMilliseconds = 150;
}
