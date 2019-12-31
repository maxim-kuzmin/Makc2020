// //Author Maxim Kuzmin//makc//

/** Хост. Меню. Вариант.  */
export interface AppHostMenuOption {

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
