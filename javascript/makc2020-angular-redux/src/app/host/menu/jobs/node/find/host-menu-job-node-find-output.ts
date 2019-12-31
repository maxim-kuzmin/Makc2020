// //Author Maxim Kuzmin//makc//

import {AppHostMenuDataNode} from '@app/host/menu/data/host-menu-data-node';

/** Хост. Меню. Задания. Узел. Поиск. Вывод. */
export interface AppHostMenuJobNodeFindOutput {

  /**
   * Элементы.
   * @type {AppHostMenuDataNode}
   */
  node: AppHostMenuDataNode;
}

/** Хост. Меню. Задания. Узел. Поиск. Вывод. Создать. */
export function appRootMenuJobListGetOutputCreate(): AppHostMenuJobNodeFindOutput {
  return {} as AppHostMenuJobNodeFindOutput;
}
