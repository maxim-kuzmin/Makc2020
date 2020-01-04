// //Author Maxim Kuzmin//makc//

/** Хост. Часть "Menu". Вариант.  */
export interface AppHostPartMenuOption {

  /**
   * Иконка.
   * @type {string}
   */
  icon?: string;

  /**
   * Признак необходимости удаления.
   * @type {boolean}
   */
  isNeededToRemove: boolean;

  /**
   * Ссылка маршрутизатора.
   * @type {any[]}
   */
  routerLink?: any[];

  /**
   * Заголовок. Ресурс. Ключ.
   * @type {string}
   */
  titleResourceKey?: string;

  /**
   * URL.
   * @type {string}
   */
  url?: string;
}
