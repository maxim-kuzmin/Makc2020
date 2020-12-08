// //Author Maxim Kuzmin//makc//

import {AppHostPartRouteDataPage} from '@app/host/parts/route/data/host-part-route-data-page';

/** Хост. Часть "Route". Данные.  */
export interface AppHostPartRouteData {

  /**
   * Страница.
   * @type {string}
   */
  page: AppHostPartRouteDataPage;
}

/** Хост. Часть "Route". Данные. Создать. */
export function appHostPartRouteDataCreate(): AppHostPartRouteData {
  return {} as AppHostPartRouteData;
}
