// //Author Maxim Kuzmin//makc//

import {AppHostPartMenuDataItem} from './host-part-menu-data-item';
import {AppCoreTreeNode, appCoreTreeNodeCreate} from '@app/core/tree/core-tree-node';

/** Хост. Часть "Menu". Данные. Узел. */
export interface AppHostPartMenuDataNode extends AppCoreTreeNode<AppHostPartMenuDataItem> {
}

/**
 * Хост. Меню. Данные. Узел. Создать.
 * @param {string} key Ключ.
 * @param {AppHostPartMenuDataItem} data Данные.
 * @param {string} parentKey Ключ родителя.
 * @param {number} level Уровень.
 * @param {number} childCount Количество детей.
 * @param {number} descendantCount Количество потомков.
 * @param {AppHostPartMenuDataNode[]} children Дети.
 * @returns {AppHostPartMenuDataNode} Узел.
 */
export function appHostMenuDataNodeCreate(
  key: string,
  data: AppHostPartMenuDataItem,
  parentKey: string,
  level: number = null,
  childCount: number = null,
  descendantCount: number = null,
  children: AppHostPartMenuDataNode[] = null
): AppHostPartMenuDataNode {
  return appCoreTreeNodeCreate<AppHostPartMenuDataItem>(
    key,
    data,
    parentKey,
    level,
    childCount,
    descendantCount,
    children
  ) as AppHostPartMenuDataNode;
}
