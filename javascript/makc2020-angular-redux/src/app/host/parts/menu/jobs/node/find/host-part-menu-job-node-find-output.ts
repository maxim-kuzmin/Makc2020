// //Author Maxim Kuzmin//makc//

import {AppHostPartMenuDataNode} from '@app/host/parts/menu/data/host-part-menu-data-node';

/** Хост. Часть "Menu". Задания. Узел. Поиск. Вывод. */
export interface AppHostPartMenuJobNodeFindOutput {

  /**
   * Элементы.
   * @type {AppHostPartMenuDataNode}
   */
  node: AppHostPartMenuDataNode;
}

/** Хост. Часть "Menu". Задания. Узел. Поиск. Вывод. Создать. */
export function appHostPartMenuJobListGetOutputCreate(): AppHostPartMenuJobNodeFindOutput {
  return {} as AppHostPartMenuJobNodeFindOutput;
}
