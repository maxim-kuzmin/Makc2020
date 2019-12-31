// //Author Maxim Kuzmin//makc//

import {AppHostRouteDataPage} from '@app/host/route/data/host-route-data-page';

/** Хост. Маршрут. Данные.  */
export interface AppHostRouteData {

  /**
   * Страница.
   * @type {string}
   */
  page: AppHostRouteDataPage;
}

/** Хост. Маршрут. Данные. Создать. */
export function appHostRouteDataCreate(): AppHostRouteData {
  return {} as AppHostRouteData;
}
