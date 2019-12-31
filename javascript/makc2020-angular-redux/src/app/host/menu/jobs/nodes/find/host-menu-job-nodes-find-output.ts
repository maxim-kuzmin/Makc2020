// //Author Maxim Kuzmin//makc//

import {AppHostMenuDataNode} from '@app/host/menu/data/host-menu-data-node';

/** Хост. Меню. Задания. Узлы. Поиск. Вывод. */
export interface AppHostMenuJobNodesFindOutput {

  /**
   * Узлы.
   * @type {AppHostMenuDataNode[]}
   */
  nodes: AppHostMenuDataNode[];
}

/** Хост. Меню. Задания. Узлы. Поиск. Вывод. Создать. */
export function appRootMenuJobTreeGetOutputCreate(): AppHostMenuJobNodesFindOutput {
  return {} as AppHostMenuJobNodesFindOutput;
}
