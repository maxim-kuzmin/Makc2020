// //Author Maxim Kuzmin//makc//

import {AppHostMenuDataItem} from './host-menu-data-item';
import {AppCoreTreeNode, appCoreTreeNodeCreate} from '@app/core/tree/core-tree-node';

/** Хост. Меню. Данные. Узел. */
export interface AppHostMenuDataNode extends AppCoreTreeNode<AppHostMenuDataItem> {
}

/**
 * Хост. Меню. Данные. Узел. Создать.
 * @param {string} key Ключ.
 * @param {AppHostMenuDataItem} data Данные.
 * @param {string} parentKey Ключ родителя.
 * @param {number} level Уровень.
 * @param {number} childCount Количество детей.
 * @param {number} descendantCount Количество потомков.
 * @param {AppHostMenuDataNode[]} children Дети.
 * @returns {AppHostMenuDataNode} Узел.
 */
export function appHostMenuDataNodeCreate(
  key: string,
  data: AppHostMenuDataItem,
  parentKey: string,
  level: number = null,
  childCount: number = null,
  descendantCount: number = null,
  children: AppHostMenuDataNode[] = null
): AppHostMenuDataNode {
  return appCoreTreeNodeCreate<AppHostMenuDataItem>(
    key,
    data,
    parentKey,
    level,
    childCount,
    descendantCount,
    children
  ) as AppHostMenuDataNode;
}
