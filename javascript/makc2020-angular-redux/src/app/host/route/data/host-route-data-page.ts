// //Author Maxim Kuzmin//makc//

/** Хост. Маршрут. Данные. Страница.  */
export interface AppHostRouteDataPage {

  /**
   * Ключ.
   * @type {string}
   */
  key: string;
}

/** Хост. Маршрут. Данные. Создать. */
export function appHostRouteDataPageCreate(): AppHostRouteDataPage {
  return {} as AppHostRouteDataPage;
}
