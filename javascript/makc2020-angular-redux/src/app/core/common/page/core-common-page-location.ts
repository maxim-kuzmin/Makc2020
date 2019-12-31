// //Author Maxim Kuzmin//makc//

import {ParamMap} from '@angular/router';

/**
 * Ядро. Общее. Страница. Местоположение.
 * @param <TParameters> Тип параметров.
 */
export abstract class AppCoreCommonPageLocation<TParameters> {

  /**
   * Параметры.
   * @type {TParameters}
   */
  parameters: TParameters;

  /**
   * Ключ страницы.
   * @type {string}
   */
  pageKey: string;

  /**
   * Параметры маршрута.
   * @type {ParamMap}
   */
  paramMap: ParamMap;

  /**
   * Путь.
   * @type {string}
   */
  path: string;
}
