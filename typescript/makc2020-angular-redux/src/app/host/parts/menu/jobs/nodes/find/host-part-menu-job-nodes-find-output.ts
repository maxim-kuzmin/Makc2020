// //Author Maxim Kuzmin//makc//

import {AppHostPartMenuDataNode} from '@app/host/parts/menu/data/host-part-menu-data-node';

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Вывод. */
export interface AppHostPartMenuJobNodesFindOutput {

  /**
   * Узлы.
   * @type {AppHostPartMenuDataNode[]}
   */
  nodes: AppHostPartMenuDataNode[];
}

/** Хост. Часть "Menu". Задания. Узлы. Поиск. Вывод. Создать. */
export function appHostPartMenuJobTreeGetOutputCreate(): AppHostPartMenuJobNodesFindOutput {
  return {} as AppHostPartMenuJobNodesFindOutput;
}
