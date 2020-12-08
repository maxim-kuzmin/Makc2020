// //Author Maxim Kuzmin//makc//

/** Хост. Часть "Route". Данные. Страница.  */
export interface AppHostPartRouteDataPage {

  /**
   * Ключ.
   * @type {string}
   */
  key: string;
}

/** Хост. Часть "Route". Данные. Создать. */
export function appHostRouteDataPageCreate(): AppHostPartRouteDataPage {
  return {} as AppHostPartRouteDataPage;
}
